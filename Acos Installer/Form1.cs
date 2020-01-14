using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acos_Installer
{
    public partial class Form1 : Form
    {
        public static string global_version = "7.0";

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_startInstall_Click(object sender, EventArgs e)
        {

            if (cb_uninstallwebsak.Checked == false && cb_variables.Checked == false && cb_ansettelse.Checked == false && cb_apen.Checked == false && cb_chrome.Checked == false && cb_citrix.Checked == false && cb_trace.Checked == false && cb_websak.Checked == false)
            {
                MessageBox.Show("Du har ikke valgt noe", "Advarsel");
            }
            if (cb_uninstallwebsak.Checked)
            {
                IsProgramInstalled("ACOS Enkelsak 4.0.106");
                IsProgramInstalled("ACOS Møte");
                IsProgramInstalled("ACOS WebSak Admin-pakke 4.2.413");
                IsProgramInstalled("ACOS WebSak Appstarter");
                IsProgramInstalled("ACOS Websak Basis 6.8.9277");
                IsProgramInstalled("ACOS WebSak Trace 1.29");
                IsProgramInstalled("ACOS WebSak Tillegg for Office 4.2.478");
                IsProgramInstalled("ACOS Enkelsak for Outlook 4.0.72");
                loadingLog.Text += "Ferdig med Avinnstaleringen \r\n";
            }

            if (cb_installwebsak.Checked)
            {
                    loadingLog.Text += "Installerer ACOS programmer \r\n";
                    RunInstallMSI("msi\\Enkelsak.msi", "ACOS Enkelsak");
                    RunInstallMSI("msi\\EnkelsakOutlook.msi", "ACOS Enkelsak Outlook");
                    RunInstallMSI("msi\\Admin.msi", "ACOS Admin");
                    RunInstallMSI("msi\\Appstarter.msi", "ACOS Appstarter");
                    RunInstallMSI("msi\\Basis.msi", "ACOS Drift");
                    RunInstallMSI("msi\\OfficeTillegg.msi", "ACOS Office Tillegg");
                    RunInstallMSI("msi\\AcosTrace.msi", "ACOS Trace");
                    ConfigureWindowsRegistry();
            }

            if (cb_variables.Checked)
            {
                ConfigureWindowsRegistry();
            }

            if (cb_websak.Checked)
            {
                createShortcut("Websak DRIFT", "C:\\Program Files (x86)\\ACOS AS\\ACOS Websak Basis\\sak.exe", "Sakbehandlingssystem fra ACOS", "C:\\Program Files (x86)\\ACOS AS\\ACOS Websak Basis", "");
            }

            if (cb_ansettelse.Checked)
            {
                createShortcut("Websak Ansettelse", "C:\\Program Files (x86)\\ACOS AS\\ACOS Websak Basis\\Ansettelse.exe", "Ansettelse fra ACOS", "C:\\Program Files (x86)\\ACOS AS\\ACOS Websak Basis", "");
            }

            if (cb_trace.Checked)
            {
                createShortcut("ACOS Trace Server", "C:\\Program Files (x86)\\ACOS AS\\ACOS WebSak Trace\\Acos.WebSak.TraceServer.exe", "Ansettelse fra ACOS", "C:\\Program Files (x86)\\ACOS AS\\ACOS WebSak Trace", "");
                createShortcut("ACOS Trace Client", "C:\\Program Files (x86)\\ACOS AS\\ACOS WebSak Trace\\Acos.Websak.TraceViewer.StandAlone.exe", "Ansettelse fra ACOS", "C:\\Program Files (x86)\\ACOS AS\\ACOS WebSak Trace", "");
            }

            if (cb_chrome.Checked)
            {
                loadingLog.Text += "Starter installasjonen av Chrome \r\n";
                RunInstallMSI("msi\\Chrome.msi", "Google Chrome");
            }
            if (cb_citrix.Checked)
            {
                loadingLog.Text += "Starter installasjonen av Citrix \r\n";
                RunInstallMSI("msi\\Citrix.msi", "Citrix Reciever");
            }
            if (cb_apen.Checked)
            {
                createShortcut("Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application", "10.10.10.13");
                createShortcut("Ny Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application", "https://sone.andoy.kommune.no/Citrix/RADCXStoreWeb/");
            }

            loadingLog.Text += "Ferdig med alt! \r\n";

        }

        public void RunInstallMSI(string filename, string appname)
        {
            ProcessStartInfo p = new ProcessStartInfo();
            p.Arguments = "/q";
            p.CreateNoWindow = true;
            p.WindowStyle = ProcessWindowStyle.Hidden;
            p.FileName = filename;
            var InstallProcess = Process.Start(p);
            InstallProcess.WaitForExit();
            loadingLog.Text += "Installert " + appname + " \r\n";
        }

        public void IsProgramInstalled(string displayName)
        {
            string uninstallKey = string.Empty;

            uninstallKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        if (sk.GetValue("DisplayName") != null && sk.GetValue("DisplayName").ToString().ToUpper().Equals(displayName.ToUpper()))
                        {
                            // loadingLog.Text += "Fant Nøkklene \r\n";
                            var Application = sk.GetValue("DisplayName");
                            loadingLog.Text += skName + "\r\n";
                            loadingLog.Text += Application + "\r\n";
                            uninstallSoftware(skName);
                        }
                    }
                }
            }
        }

        public void uninstallSoftware(string filename)
        {
            Process p = new Process();
            p.StartInfo.FileName = "msiexec.exe";
            p.StartInfo.Arguments = "/x" + filename + " /qn";
            p.Start();
            p.WaitForExit();
            loadingLog.Text += "Avinnstalert \r\n";
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            version.Text = "v" + global_version;
        }

        public void createShortcut(string shortcutName, string shortcutPath, string shortcutDescription, string directory, string shortcutArguments)
        {
            WshShell wsh = new WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + shortcutName + ".lnk") as IWshRuntimeLibrary.IWshShortcut;
            shortcut.Arguments = shortcutArguments;
            shortcut.TargetPath = shortcutPath; // c:\\app\\myftp.exe
                                                                                                  // not sure about what this is for
            shortcut.WindowStyle = 1;
            shortcut.Description = shortcutDescription; // my shortcut description
            shortcut.WorkingDirectory = directory; // c:\\app
                                                                                               // shortcut.IconLocation = "specify icon location"; // specify icon location
            shortcut.Save();
            loadingLog.Text += "Snarvei til " + shortcutName + "\r\n";
        }

        public void ConfigureWindowsRegistry()
        {
            RegistryKey CurrentUser = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64); //here you specify where exactly you want your entry

            var reg = CurrentUser.OpenSubKey("Software\\ACOS\\Websak\\Oppkoblinger", true);
            if (reg == null)
            {
                reg = CurrentUser.CreateSubKey("Software\\ACOS\\Websak\\Oppkoblinger");
            }

            if (reg.GetValue("oppkobling1") == null)
            {
                reg.SetValue("oppkobling1", "websakdb/websak");
                loadingLog.Text += "Registeret er endret \r\n";
            }
        }
    }
}
