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
        public static string global_version = "9.1";

        public Form1()
        {
            InitializeComponent();
        }

        /*private void Btn_startInstall_Click(object sender, EventArgs e)
        {
            loadingLog.Clear();
            btn_startInstall.Enabled = false;
            var checkedBoxes = this.groupBox1.Controls.OfType<CheckBox>().Count(c => c.Checked);

            if (cb_uninstallwebsak.Checked)
            {
                IsProgramInstalled("ACOS Enkelsak 4.0.106", "yes");
                IsProgramInstalled("ACOS Møte", "yes");
                IsProgramInstalled("ACOS WebSak Admin-pakke 4.2.413", "yes");
                IsProgramInstalled("ACOS WebSak Appstarter", "yes");
                IsProgramInstalled("ACOS Websak Basis 6.8.9277", "yes");
                IsProgramInstalled("ACOS WebSak Trace 1.29", "yes");
                IsProgramInstalled("ACOS WebSak Tillegg for Office 4.2.478", "yes");
                IsProgramInstalled("ACOS Enkelsak for Outlook 4.0.72", "yes");
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
*//*            if (cb_acrobat.Checked)
            {
                InstallAcrobat();
            }*//*
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
                CreateShortcut("Websak DRIFT", "C:\\Program Files (x86)\\ACOS AS\\ACOS Websak Basis\\sak.exe", "Sakbehandlingssystem fra ACOS", "C:\\Program Files (x86)\\ACOS AS\\ACOS Websak Basis", "");
            }
            if (cb_ansettelse.Checked)
            {
                CreateShortcut("Websak Ansettelse", "C:\\Program Files (x86)\\ACOS AS\\ACOS Websak Basis\\Ansettelse.exe", "Ansettelse fra ACOS", "C:\\Program Files (x86)\\ACOS AS\\ACOS Websak Basis", "");
            }
            if (cb_trace.Checked)
            {
                CreateShortcut("ACOS Trace Server", "C:\\Program Files (x86)\\ACOS AS\\ACOS WebSak Trace\\Acos.WebSak.TraceServer.exe", "Ansettelse fra ACOS", "C:\\Program Files (x86)\\ACOS AS\\ACOS WebSak Trace", "");
                CreateShortcut("ACOS Trace Client", "C:\\Program Files (x86)\\ACOS AS\\ACOS WebSak Trace\\Acos.Websak.TraceViewer.StandAlone.exe", "Ansettelse fra ACOS", "C:\\Program Files (x86)\\ACOS AS\\ACOS WebSak Trace", "");
            }
            if (cb_chrome.Checked)
            {
                loadingLog.Text += "Starter installasjonen av Chrome \r\n";
                RunInstallMSI("msi\\Chrome.msi", "Google Chrome");
            }
            if (cb_citrix.Checked)
            {
                InstallCitrix("msi\\CitrixWorkspaceApp.exe", "Citrix Workspace");
            }
            if (cb_apen.Checked)
            {
                CreateShortcut("Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application", "http://10.10.10.13/Citrix/AccessPlatform/auth/login.aspx");
                CreateShortcut("Ny Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application", "https://vak-citrixadm.andoy.kommune.no/Citrix/KommuneApplikasjonerWeb/");
            }
            if (cb_offisiellaapen.Checked)
            {
                CreateShortcut("Offisiell Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "Offisiell Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application", "https://sone.andoy.kommune.no/Citrix/RADCXStoreWeb/");
            }
            if (cb_forticlientems.Checked)
            {
                loadingLog.Text += "Starter installasjonen av Forticlient EMS \r\n";
                RunInstallMSI("msi\\ForticlientEMS.msi", "Forticlient EMS");
            }
            *//*if (cb_checkforticlient.Checked)
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
            btn_startInstall.Enabled = true;*//*
        }*/

        public void RunInstallMSI(string filename, string appname)
        {
            ProcessStartInfo p = new ProcessStartInfo
            {
                Arguments = "/q",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = filename
            };
            var InstallProcess = Process.Start(p);
            InstallProcess.WaitForExit();
            loadingLog.Text += "Installert " + appname + " \r\n";
        }

        public void InstallCitrix(string filename, string appname)
        {
            try
            {
                loadingLog.Text += "Starter installasjon av " + appname + "\r\n";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    Arguments = "/silent",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = filename,
                    UseShellExecute = false
                };
                var started = Process.Start(psi);

                started.WaitForExit();

                if (started.ExitCode == 0)
                {
                    loadingLog.Text += "Installert " + appname + "\r\n";
                    btn_newinstall.Enabled = true;
                }
            }
            catch (Exception e)
            {
                loadingLog.Text += "Error: " + e.Message + "\r\n";
            }
        }

        public void IsProgramInstalled(string displayName, string proceed)
        {
            string uninstallKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
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
                            // loadingLog.Text += skName + "\r\n";

                            // Name of application
                            // loadingLog.Text += Application + "\r\n";
                            
                            if (proceed == "yes")
                            {
                                UninstallSoftware(skName, Application.ToString());
                            }
                        }
                    }
                }
            }
        }

        public void UninstallSoftware(string filename, string appname)
        {
            Process p = new Process();
            p.StartInfo.FileName = "msiexec.exe";
            p.StartInfo.Arguments = "/x" + filename + " /qn";
            p.Start();
            p.WaitForExit();
            loadingLog.Text += "Avinstallert " + appname + "\r\n";
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            // set version
            version.Text = "v" + global_version;

            Addapplication("ACOS Websak-pakke", "Installer Andøy Kommunes sakssystem"); // 0
            Addapplication("Avinstaller Websak-pakke", "Avinstaller Andøy Kommunes sakssystem"); // 1
            Addapplication("CosDoc 12", "Installer Andøy Kommunes journalsystem"); // 2
            Addapplication("Websak sjekk", "Sjekk register for databasestring"); // 3

            Addapplication("ACOS Websak snarvei", "Opprett snarvei for ACOS Websak"); // 4
            Addapplication("ACOS Ansettelse snarvei", "Opprett snarvei for ACOS Ansettelse"); // 5
            Addapplication("ACOS Trace snarvei", "Opprett snarvei for ACOS Trace (feilsøking server/client)"); // 6

            Addapplication("Åpen Sone", "Opprett snarvei til 10.10.10.13"); // 7
            Addapplication("Ny Åpen Sone", "Opprett snarvei til 10.10.10.7"); // 8
            Addapplication("Offisiell Åpen Sone", "Opprett snarvei til sone.andoy.kommune.no"); // 9

            Addapplication("Chrome x64", "Installasjon for Chrome 64-biters"); // 10
            Addapplication("Firefox x64", "Installasjon for Firefox 64-biters"); // 11
            Addapplication("Forticlient EMS", "Installasjon for Forticlient EMS"); // 12
            Addapplication("Citrix Workspace", "Installasjon for Citrix Workspace"); // 13

            // Add applications to group
            // ACOS
            listviewinstalls.Items[0].Group = listviewinstalls.Groups[0]; // .Groups[0] er ACOS programmer
            listviewinstalls.Items[1].Group = listviewinstalls.Groups[0];
            listviewinstalls.Items[2].Group = listviewinstalls.Groups[0];
            listviewinstalls.Items[3].Group = listviewinstalls.Groups[0];

            // Snarveier
            listviewinstalls.Items[4].Group = listviewinstalls.Groups[1];
            listviewinstalls.Items[5].Group = listviewinstalls.Groups[1];
            listviewinstalls.Items[6].Group = listviewinstalls.Groups[1];
            listviewinstalls.Items[7].Group = listviewinstalls.Groups[1];
            listviewinstalls.Items[8].Group = listviewinstalls.Groups[1];
            listviewinstalls.Items[9].Group = listviewinstalls.Groups[1];

            // Applikasjoner
            listviewinstalls.Items[10].Group = listviewinstalls.Groups[2];
            listviewinstalls.Items[11].Group = listviewinstalls.Groups[2];
            listviewinstalls.Items[12].Group = listviewinstalls.Groups[2];
            listviewinstalls.Items[13].Group = listviewinstalls.Groups[2];
        }

        private void Btn_newinstall_Click(object sender, EventArgs e)
        {
            // websak pakke
            if (listviewinstalls.Items[0].Checked)
            {
                loadingLog.Text += "Installerer ACOS programmer \r\n";
                RunInstallMSI("msi\\Enkelsak.msi", "ACOS Enkelsak");
                RunInstallMSI("msi\\EnkelsakOutlook.msi", "ACOS Enkelsak Outlook");
                RunInstallMSI("msi\\Admin.msi", "ACOS Admin");
                RunInstallMSI("msi\\Appstarter.msi", "ACOS Appstarter");
                RunInstallMSI("msi\\Basis.msi", "ACOS Drift");
                RunInstallMSI("msi\\OfficeTillegg.msi", "ACOS Office Tillegg");
                RunInstallMSI("msi\\AcosTrace.msi", "ACOS Trace"); // Acos.CosDoc.Basis12.msi
                ConfigureWindowsRegistry();
            }

            // avinstaller
            if (listviewinstalls.Items[1].Checked)
            {
                IsProgramInstalled("ACOS Enkelsak 4.0.106", "yes");
                IsProgramInstalled("ACOS Møte", "yes");
                IsProgramInstalled("ACOS WebSak Admin-pakke 4.2.413", "yes");
                IsProgramInstalled("ACOS WebSak Appstarter", "yes");
                IsProgramInstalled("ACOS Websak Basis 6.8.9277", "yes");
                IsProgramInstalled("ACOS WebSak Trace 1.29", "yes");
                IsProgramInstalled("ACOS WebSak Tillegg for Office 4.2.478", "yes");
                IsProgramInstalled("ACOS Enkelsak for Outlook 4.0.72", "yes");
                loadingLog.Text += "Avinstallering fullført.";
            }

            // websak pakke
            if (listviewinstalls.Items[2].Checked)
            {
                loadingLog.Text += "Installerer CosDoc 12 Basis \r\n";
                RunInstallMSI("msi\\Acos.CosDoc.Basis12.msi", "CosDoc 12 Basis");
                ConfigureWindowsRegistry();
            }

            // websak sjekk
            if (listviewinstalls.Items[3].Checked)
            {
                ConfigureWindowsRegistry();
            }

            // websak snarvei
            if (listviewinstalls.Items[4].Checked)
            {
                CreateShortcut("Websak DRIFT", "C:\\Program Files (x86)\\ACOS AS\\ACOS Websak Basis\\sak.exe", "Sakbehandlingssystem fra ACOS", "C:\\Program Files (x86)\\ACOS AS\\ACOS Websak Basis", "");
            }

            // ansettelse snarvei
            if (listviewinstalls.Items[5].Checked)
            {
                CreateShortcut("Websak Ansettelse", "C:\\Program Files (x86)\\ACOS AS\\ACOS Websak Basis\\Ansettelse.exe", "Ansettelse fra ACOS", "C:\\Program Files (x86)\\ACOS AS\\ACOS Websak Basis", "");
            }

            // trace snarvei
            if (listviewinstalls.Items[6].Checked)
            {
                CreateShortcut("ACOS Trace Server", "C:\\Program Files (x86)\\ACOS AS\\ACOS WebSak Trace\\Acos.WebSak.TraceServer.exe", "Ansettelse fra ACOS", "C:\\Program Files (x86)\\ACOS AS\\ACOS WebSak Trace", "");
                CreateShortcut("ACOS Trace Client", "C:\\Program Files (x86)\\ACOS AS\\ACOS WebSak Trace\\Acos.Websak.TraceViewer.StandAlone.exe", "Ansettelse fra ACOS", "C:\\Program Files (x86)\\ACOS AS\\ACOS WebSak Trace", "");
            }

            // åpen sone snarvei
            if (listviewinstalls.Items[7].Checked)
            {
                CreateShortcut("Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application", "http://10.10.10.13/Citrix/AccessPlatform/auth/login.aspx");
            }

            // åpen sone snarvei
            if (listviewinstalls.Items[8].Checked)
            {
                CreateShortcut("Ny Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application", "https://vak-citrixadm.andoy.kommune.no/Citrix/KommuneApplikasjonerWeb/");
            }

            // offisiell åpen sone snarvei
            if (listviewinstalls.Items[9].Checked)
            {
                CreateShortcut("Offisiell Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "Offisiell Åpen Sone", "C:\\Program Files (x86)\\Google\\Chrome\\Application", "https://sone.andoy.kommune.no/Citrix/RADCXStoreWeb/");
            }

            // chrome x64
            if (listviewinstalls.Items[10].Checked)
            {
                loadingLog.Text += "Starter installasjonen av Chrome \r\n";
                RunInstallMSI("msi\\Chrome.msi", "Google Chrome");
            }

            // firefox x64
            if (listviewinstalls.Items[11].Checked)
            {
                loadingLog.Text += "Installerer Firefox";
                RunInstallMSI("msi\\Firefox.msi", "Firefox");
            }

            // forticlient
            if (listviewinstalls.Items[12].Checked)
            {
                loadingLog.Text += "Starter installasjonen av Forticlient EMS \r\n";
                RunInstallMSI("msi\\ForticlientEMS.msi", "Forticlient EMS");
            }

            // citrix
            if (listviewinstalls.Items[13].Checked)
            {
                InstallCitrix("msi\\CitrixWorkspaceApp.exe", "Citrix Workspace");
            }
        }

        public void Addapplication(string applicationname, string description)
        {
            string[] row1 = { description };
            listviewinstalls.Items.Add(applicationname).SubItems.AddRange(row1);
        }

        public void CreateShortcut(string shortcutName, string shortcutPath, string shortcutDescription, string directory, string shortcutArguments)
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
                loadingLog.Text += "Oppdatert registernøkler \r\n";
            }
        }
    }
}
