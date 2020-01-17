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
        public static string global_version = "8.3";

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_startInstall_Click(object sender, EventArgs e)
        {
            loadingLog.Clear();
            btn_startInstall.Enabled = false;
            var checkedBoxes = this.groupBox1.Controls.OfType<CheckBox>().Count(c => c.Checked);

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
            if (cb_acrobat.Checked)
            {
                InstallAcrobat();
            }
            if (cb_firefox.Checked)
            {
                loadingLog.Text += "Installerer Firefox";
                RunInstallMSI("msi\\Firefox.msi", "Firefox");
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
                createShortcut("Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application", "http://10.10.10.13/Citrix/AccessPlatform/auth/login.aspx");
                createShortcut("Ny Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application", "https://vak-citrixadm.andoy.kommune.no/Citrix/KommuneApplikasjonerWeb/");
            }
            if (cb_offisiellaapen.Checked)
            {
                createShortcut("Offisiell Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "Offisiell Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application", "https://sone.andoy.kommune.no/Citrix/RADCXStoreWeb/");
            }
            if (cb_forticlientems.Checked)
            {
                loadingLog.Text += "Starter installasjonen av Forticlient EMS \r\n";
                RunInstallMSI("msi\\ForticlientEMS.msi", "Forticlient EMS");
            }
            if (cb_checkforticlient.Checked)
            {
                int valueschanged = 0;
                loadingLog.Text += "Sjekker register mot Forticlient EMS \r\n";

                RegistryKey LocalMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                RegistryKey LocalMachine32 = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);

                var reg = LocalMachine.OpenSubKey("Software\\Fortinet\\FortiClient\\Sslvpn\\Tunnels\\Andøy Kommune", true);
                var reg32 = LocalMachine.OpenSubKey("Software\\Fortinet\\FortiClient\\Sslvpn\\Tunnels\\Andøy Kommune", true);

                if (reg == null)
                {
                    reg = LocalMachine.CreateSubKey("Software\\Fortinet\\FortiClient\\Sslvpn\\Tunnels\\Andøy Kommune");
                }

                if (reg.GetValue("Server") == null)
                {
                    reg.SetValue("Server", "vpn.andoy.kommune.no:10443");
                    loadingLog.Text += "Oppdatert verdi(Server) \r\n";
                    valueschanged += 1;
                }

                if (reg.GetValue("Description") == null)
                {
                    reg.SetValue("Description", "VPN tilkobling til Andøy Kommune");
                    loadingLog.Text += "Oppdatert verdi(Description) \r\n";
                    valueschanged += 1;
                }

                if (reg.GetValue("DATA3") == null)
                {
                    reg.SetValue("DATA3", "");
                    loadingLog.Text += "Oppdatert verdi(DATA3) \r\n";
                    valueschanged += 1;
                }

                if (reg.GetValue("ServerCert") == null)
                {
                    reg.SetValue("ServerCert", "1");
                    loadingLog.Text += "Oppdatert verdi(ServerCert) \r\n";
                    valueschanged += 1;
                }

                if (reg32.GetValue("promptcertificate") == null)
                {
                    reg.SetValue("promptcertificate", "0", RegistryValueKind.DWord); // Create 32-bit DWORD (for 0 or 1 values)
                    loadingLog.Text += "Oppdatert verdi(promptcertificate) \r\n";
                    valueschanged += 1;
                }

                if (reg32.GetValue("promptusername") == null)
                {
                    reg.SetValue("promptusername", "1", RegistryValueKind.DWord); // Create 32-bit DWORD (for 0 or 1 values)
                    loadingLog.Text += "Oppdatert verdi(promptusername) \r\n";
                    valueschanged += 1;
                }

                loadingLog.Text += "Fullført! " + valueschanged.ToString() + " nøkler endret.";

            }
            btn_startInstall.Enabled = true;
        }

        public void InstallAcrobat()
        {
           

            try
            {
                loadingLog.Text += "Installerer Acrobat Reader \r\n";

                var proc1 = new ProcessStartInfo();
                string Command;
                proc1.UseShellExecute = true;
                Command = @"cd msi\\readerdc_en_a_install.exe /msi EULA_ACCEPT=YES /qn";
                proc1.WorkingDirectory = @"C:\Windows\System32";
                proc1.FileName = @"C:\Windows\System32\cmd.exe";
                /// as admin = proc1.Verb = "runas";
                proc1.Arguments = "/c " + Command;
                proc1.WindowStyle = ProcessWindowStyle.Maximized;
                Process.Start(proc1);
            }
            catch (Exception o)
            {
                loadingLog.Text += "error: " + o.Message;
            }
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
