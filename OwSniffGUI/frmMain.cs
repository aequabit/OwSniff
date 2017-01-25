using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using SharpPcap;
using ICSharpCode.SharpZipLib.BZip2;

namespace OwSniff
{
    public partial class frmMain : Form
    {
        private bool run = true;

        /* Get list of all network interfaces */
        CaptureDeviceList networkInterfaces = CaptureDeviceList.Instance;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /* Log status message */
            lstLog.Items.Add("Successfully loaded OwSniff and started listening on all network interfaces.");

            /* If no network interfaces are available */
            if (networkInterfaces.Count < 1)
            {
                lstLog.Items.Add("There are no available network interfaces.");
                return;
            }

            /* Loop through all interfaces */
            foreach (ICaptureDevice networkInterface in networkInterfaces)
            {
                /* Register eventhandler to fire when a packet is received */
                networkInterface.OnPacketArrival += new SharpPcap.PacketArrivalEventHandler(packetReceived);

                /* Listen to the main interface's traffic */
                networkInterface.Open(DeviceMode.Promiscuous, 1000);

                /* Start capturing network traffic */
                networkInterface.StartCapture();
            }
        }

        /* Method to append items to the log box from antoher thread safely */
        private void log(string txt)
        {
            this.Invoke((MethodInvoker)(() => lstLog.Items.Add(txt)));
        }

        private void packetReceived(object sender, CaptureEventArgs packet)
        {
            /* Check if sniff should run */
            if (run)
            {
                /* Store the packet in a string */
                string packetData = Encoding.UTF8.GetString(packet.Packet.Data);

                /* If the packet contains a compressed demo file */
                if (packetData.Contains(".valve.net") && packetData.Contains("/730/") && packetData.Contains(".dem.bz2"))
                {
                    /* Declare variables to store the domain and file URL */
                    string file = String.Empty;
                    string domain = String.Empty;

                    /* Extract the domain and the file name from the packet */
                    domain = packetData.Split(new[] { "Host: " }, StringSplitOptions.None)[1].Split(new[] { "Accept: " }, StringSplitOptions.None)[0].Replace(Environment.NewLine, "");
                    file = packetData.Split(new[] { "GET " }, StringSplitOptions.None)[1].Split(new[] { " HTTP" }, StringSplitOptions.None)[0];

                    /* Log response */
                    log("Sniffed HTTP request to a Valve replay server.");
                    log(String.Format("URL: http://{0}{1}", domain, file));

                    /* Declare variables to store the filename to be used used on the local filesystem and it's full path */
                    string localFileName = file.Replace("/730/", "");
                    string localFile = Path.GetTempPath() + localFileName;

                    /* Check if the file already exists */
                    if (File.Exists(localFile))
                    {
                        File.Delete(localFile);
                    }

                    /* Download the compressed demo file */
                    log("Downloading compressed demo file...");
                    new WebClient().DownloadFile(
                        /* Build the download URL */
                        String.Format("http://{0}{1}", domain, file),

                        /* Path to store the downloaded file */
                        localFile
                        );

                    /* Log response to the console */
                    log("Download completed.");
                    log("Decompressing demo file...");

                    /* Declare variable to store the final demo file */
                    string finalPath = String.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), localFileName.Replace(".bz2", ""));

                    /* Decompress the downloaded demo file */
                    FileInfo compressedDemo = new FileInfo(localFile);
                    using (FileStream decompressStream = compressedDemo.OpenRead())
                    {
                        using (FileStream writeStream = File.Create(finalPath))
                        {
                            try
                            {
                                BZip2.Decompress(decompressStream, writeStream, true);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }

                    /* Delete the compressed demo */
                    if (File.Exists(localFile))
                    {
                        File.Delete(localFile);
                    }

                    /* Log response to the console */
                    log("Successfully decompressed demo file.");
                    log(String.Format("Saved to: {0}", finalPath));

                    /* Disable the sniffer until the user restarts it */
                    run = false;
                }
            }
        }

        private void frmMain_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            new frmAbout().ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* Loop through all interfaces */
            foreach (ICaptureDevice networkInterface in networkInterfaces)
            {
                /* Stop caputing and close the network interface */
                networkInterface.StopCapture();
                networkInterface.Close();
            }
        }
    }
}
