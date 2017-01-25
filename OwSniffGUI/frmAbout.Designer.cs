namespace OwSniff
{
    partial class frmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lnkSharpPcap = new System.Windows.Forms.LinkLabel();
            this.lnkPacketNet = new System.Windows.Forms.LinkLabel();
            this.lnkSharpZipLib = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(179, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "OwSniff";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(307, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Created by aequabit.";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(426, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = " Overwatch demo sniffer for Counter-Strike: Global Offensive";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 60);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tamir Gal - \r\nChris Morgan - \r\nicsharpcode - ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Credits";
            // 
            // lnkSharpPcap
            // 
            this.lnkSharpPcap.AutoSize = true;
            this.lnkSharpPcap.LinkColor = System.Drawing.Color.Red;
            this.lnkSharpPcap.Location = new System.Drawing.Point(91, 125);
            this.lnkSharpPcap.Name = "lnkSharpPcap";
            this.lnkSharpPcap.Size = new System.Drawing.Size(79, 20);
            this.lnkSharpPcap.TabIndex = 5;
            this.lnkSharpPcap.TabStop = true;
            this.lnkSharpPcap.Text = "SharpPcap";
            this.lnkSharpPcap.VisitedLinkColor = System.Drawing.Color.Red;
            this.lnkSharpPcap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSharpPcap_LinkClicked);
            // 
            // lnkPacketNet
            // 
            this.lnkPacketNet.AutoSize = true;
            this.lnkPacketNet.LinkColor = System.Drawing.Color.Red;
            this.lnkPacketNet.Location = new System.Drawing.Point(115, 144);
            this.lnkPacketNet.Name = "lnkPacketNet";
            this.lnkPacketNet.Size = new System.Drawing.Size(79, 20);
            this.lnkPacketNet.TabIndex = 6;
            this.lnkPacketNet.TabStop = true;
            this.lnkPacketNet.Text = "Packet.Net";
            this.lnkPacketNet.VisitedLinkColor = System.Drawing.Color.Red;
            this.lnkPacketNet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPacketNet_LinkClicked);
            // 
            // lnkSharpZipLib
            // 
            this.lnkSharpZipLib.AutoSize = true;
            this.lnkSharpZipLib.LinkColor = System.Drawing.Color.Red;
            this.lnkSharpZipLib.Location = new System.Drawing.Point(107, 165);
            this.lnkSharpZipLib.Name = "lnkSharpZipLib";
            this.lnkSharpZipLib.Size = new System.Drawing.Size(89, 20);
            this.lnkSharpZipLib.TabIndex = 7;
            this.lnkSharpZipLib.TabStop = true;
            this.lnkSharpZipLib.Text = "SharpZipLib";
            this.lnkSharpZipLib.VisitedLinkColor = System.Drawing.Color.Red;
            this.lnkSharpZipLib.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSharpZipLib_LinkClicked);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 194);
            this.Controls.Add(this.lnkSharpZipLib);
            this.Controls.Add(this.lnkPacketNet);
            this.Controls.Add(this.lnkSharpPcap);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.Text = "About OwSniff";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lnkSharpPcap;
        private System.Windows.Forms.LinkLabel lnkPacketNet;
        private System.Windows.Forms.LinkLabel lnkSharpZipLib;
    }
}