using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace OwSniff
{
    static class Program
    {
        public static frmMain main;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /* Load embedded assemblies */
            EmbeddedAssembly.Load("OwSniff.SharpPcap.dll", "SharpPcap.dll");
            EmbeddedAssembly.Load("OwSniff.ICSharpCode.SharpZipLib.dll", "ICSharpCode.SharpZipLib.dll");
            EmbeddedAssembly.Load("OwSniff.PacketDotNet.dll", "PacketDotNet.dll");
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }
    }
}
