using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Reflection;
using SharpPcap;
using ICSharpCode.SharpZipLib.BZip2;

namespace OwSniff
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Set console title */
            Console.Title = "OwSniff - CS:GO Overwatch Demo Sniffer";

            /* Log status message */
            Console.WriteLine("Successfully loaded OwSniff and started listening on all network interfaces.");

            /* Get list of all network interfaces */
            CaptureDeviceList networkInterfaces = CaptureDeviceList.Instance;

            /* If no network interfaces are available */
            if (networkInterfaces.Count < 1)
            {
                Console.WriteLine("There are no available network interfaces.");
                Console.ReadKey();
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

        private static void packetReceived(object sender, CaptureEventArgs packet)
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

                /* Log response to the console */
                Console.WriteLine("Sniffed HTTP request to a Valve replay server.");
                Console.WriteLine("URL: http://{0}{1}", domain, file);   

                /* Declare variables to store the filename to be used used on the local filesystem and it's full path */
                string localFileName = file.Replace("/730/", "");
                string localFile = Path.GetTempPath() + localFileName;

                /* Check if the file already exists */
                if (File.Exists(localFile))
                {
                    File.Delete(localFile);
                }

                /* Download the compressed demo file */
                Console.WriteLine("Downloading compressed demo file...");
                new WebClient().DownloadFile(
                    /* Build the download URL */
                    String.Format("http://{0}{1}", domain, file),

                    /* Path to store the downloaded file */
                    localFile
                    );

                /* Log response to the console */
                Console.WriteLine("Download completed.");
                Console.WriteLine("Decompressing demo file...");

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
                Console.WriteLine("Successfully decompressed demo file.");
                Console.WriteLine("Saved to: {0}", finalPath);

                Console.ReadKey();
                Environment.Exit(0);
            }  
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }
    }
}
