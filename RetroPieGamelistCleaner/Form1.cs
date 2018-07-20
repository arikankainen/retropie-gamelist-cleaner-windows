using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RetroPieGamelistCleaner
{
    public partial class Form1 : Form
    {
        private List<string> list = new List<string>();
        private List<string> gamesToDelete = new List<string>();
        private List<string> filesToDelete = new List<string>();
        private RunAction runAction;

        private string host;
        private string username;
        private string password;
        private string remoteDirectory;
        private string emulatorDirectory;
        private string localDirectory;

        private bool logErrors = false;
        private int justifyLength = 40;

        private enum RunAction
        {
            Refresh,
            Check,
            Delete
        }

        private Settings settings = new Settings();

        public Form1()
        {
            InitializeComponent();

            Assembly assem = Assembly.GetEntryAssembly();
            AssemblyName assemName = assem.GetName();
            Version ver = assemName.Version;

            this.Text = "RetroPie Gamelist Cleaner v" + ver.Major + "." + ver.Minor;
            InitWorker();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtHost.Text = settings.LoadSetting("Host", Settings.Type.String, "retropie");
            txtUsername.Text = settings.LoadSetting("Username", Settings.Type.String, "pi");
            txtPassword.Text = settings.LoadSetting("Password", Settings.Type.String, "raspberry");
            txtDirectory.Text = settings.LoadSetting("Directory", Settings.Type.String, "/home/pi/RetroPie/roms");

            btnRefreshEmulators.PerformClick();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.SaveSetting("Host", txtHost.Text);
            settings.SaveSetting("Username", txtUsername.Text);
            settings.SaveSetting("Password", txtPassword.Text);
            settings.SaveSetting("Directory", txtDirectory.Text);
            if (comboEmulators.Text != "") settings.SaveSetting("Emulator", comboEmulators.Text);
        }

        // *******************************************************

        private void btnRefreshEmulators_Click(object sender, EventArgs e)
        {
            RunRefresh();
        }

        private void RunRefresh()
        {
            if (ReadTextFields(true))
            {
                DisableControls();
                RunWork(RunAction.Refresh);
            }
        }

        private void RunRefreshAsync()
        {
            GetEmulatorlist();
        }

        private void RunRefreshCompleted()
        {
            comboEmulators.Items.Clear();

            foreach (string dir in list)
            {
                comboEmulators.Items.Add(dir);
            }

            Log("");
            EnableControls();
            if (comboEmulators.Items.Contains(settings.LoadSetting("Emulator"))) comboEmulators.Text = settings.LoadSetting("Emulator");
        }

        // *******************************************************

        private void btnGo_Click(object sender, EventArgs e)
        {
            RunCheck();
        }

        private void RunCheck()
        {
            if (ReadTextFields())
            {
                DisableControls();
                RunWork(RunAction.Check);
            }
        }

        private void RunCheckAsync()
        {
            do
            {
                if (!GetFilelist()) break;
                if (!DownloadFile()) break;
                if (!ProcessXML()) break;
                //if (!DeleteFiles()) break;
                if (!RenameFile()) break;
                if (!UploadFile()) break;

            } while (false);
        }

        private void RunCheckCompleted()
        {
            Log("");

            if (filesToDelete.Count > 0)
            {
                FormPrompt form = new FormPrompt();
                form.FileList = filesToDelete;
                form.ShowDialog();
                filesToDelete = form.FilesToDelete;
                form.Dispose();
            }

            RunDelete();
        }

        // *******************************************************

        private void RunDelete()
        {
            RunWork(RunAction.Delete);
        }

        private void RunDeleteAsync()
        {
            DeleteFiles();
        }

        private void RunDeleteCompleted()
        {
            EnableControls();
        }

        // *******************************************************

        private bool ReadTextFields(bool emulators = false)
        {
            host = txtHost.Text;
            username = txtUsername.Text;
            password = txtPassword.Text;
            remoteDirectory = txtDirectory.Text;
            localDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            if (comboEmulators.Text != "") emulatorDirectory = Path.Combine(remoteDirectory, comboEmulators.Text).Replace(@"\", "/");
            else emulatorDirectory = "";

            if (host != "" && username != "" && password != "" && remoteDirectory != "" && localDirectory != "" && (emulatorDirectory != "" || emulators)) return true;
            else return false;
        }

        private bool GetEmulatorlist()
        {
            LogAsync("Retrieving list of emulators...", true, true);

            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {
                    list.Clear();

                    sftp.Connect();
                    var files = sftp.ListDirectory(remoteDirectory);
                    sftp.Disconnect();

                    foreach (var file in files)
                    {
                        if (file.IsDirectory && file.Name != "." && file.Name != "..") list.Add(file.Name);
                    }

                    LogAsync("OK", false);
                    LogAsync("Emulator directories found:", true, true);
                    LogAsync(list.Count().ToString(), false);
                    return true;
                }

                catch (Exception ex)
                {
                    LogAsync("ERROR", false);
                    LogErrorAsync(ex.Message + ex.StackTrace);
                    return false;
                }
            }
        }

        private bool GetFilelist()
        {
            LogAsync("Retrieving list of game files...", true, true);

            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {
                    list.Clear();

                    sftp.Connect();
                    var files = sftp.ListDirectory(emulatorDirectory);
                    sftp.Disconnect();

                    foreach (var file in files)
                    {
                        if (file.IsRegularFile) list.Add(file.Name);
                    }

                    LogAsync("OK", false);
                    return true;
                }

                catch (Exception ex)
                {
                    LogAsync("ERROR", false);
                    LogErrorAsync(ex.Message + ex.StackTrace);
                    return false;
                }
            }
        }

        private bool DownloadFile()
        {
            LogAsync("Downloading gamelist.xml...", true, true);

            string filename = "gamelist.xml";

            string remoteFile = Path.Combine(emulatorDirectory, filename).Replace(@"\", "/");
            string localFile = Path.Combine(localDirectory, filename);

            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {
                    sftp.Connect();

                    if (File.Exists(localFile)) File.Delete(localFile);

                    using (Stream stream = File.OpenWrite(localFile))
                    {
                        sftp.DownloadFile(remoteFile, stream);
                    }

                    sftp.Disconnect();

                    LogAsync("OK", false);
                    return true;
                }

                catch (Exception ex)
                {
                    LogAsync("ERROR", false);
                    LogErrorAsync(ex.Message + ex.StackTrace);
                    return false;
                }
            }
        }

        private bool UploadFile()
        {
            LogAsync("Uploading gamelist.xml...", true, true);

            string filename = "gamelist.xml";

            string remoteFile = Path.Combine(emulatorDirectory, filename).Replace(@"\", "/");
            string localFile = Path.Combine(localDirectory, filename);

            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {
                    sftp.Connect();

                    using (Stream stream = File.OpenRead(localFile))
                    {
                        sftp.UploadFile(stream, remoteFile);
                    }

                    sftp.Disconnect();

                    LogAsync("OK", false);
                    return true;
                }

                catch (Exception ex)
                {
                    LogAsync("ERROR", false);
                    LogErrorAsync(ex.Message + ex.StackTrace);
                    return false;
                }
            }
        }

        private bool RenameFile()
        {
            string filename = "gamelist.xml";
            string filenameOld = "gamelist_old_" + DateTime.Now.ToString("yyyy-MM-dd-H-mm-ss") + ".xml";

            string remoteFile = Path.Combine(emulatorDirectory, filename).Replace(@"\", "/");
            string remoteFileOld = Path.Combine(emulatorDirectory, filenameOld).Replace(@"\", "/");
            string localFile = Path.Combine(localDirectory, filename);

            LogAsync("Renaming old gamelist.xml...", true, true);

            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {
                    sftp.Connect();

                    sftp.RenameFile(remoteFile, remoteFileOld);

                    sftp.Disconnect();

                    LogAsync("OK", false);
                    return true;
                }

                catch (Exception ex)
                {
                    LogAsync("ERROR", false);
                    LogErrorAsync(ex.Message + ex.StackTrace);
                    return false;
                }
            }
        }

        private bool DeleteFiles()
        {
            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {
                    sftp.Connect();

                    foreach (string file in filesToDelete)
                    {
                        string path = file;
                        if (path.Substring(0, 2) == "./") path = path.Substring(2);
                        string path2 = Path.Combine(emulatorDirectory, path).Replace(@"\", "/");

                        if (sftp.Exists(path2))
                        {
                            LogAsync("Deleting: " + Path.GetFileName(path2), true, true);

                            try
                            {
                                sftp.DeleteFile(path2);
                                LogAsync("OK", false);
                            }

                            catch
                            {
                                LogAsync("ERROR", false);
                            }
                        }
                    }

                    sftp.Disconnect();
                    Log("");
                    return true;
                }

                catch (Exception ex)
                {
                    LogErrorAsync(ex.Message + ex.StackTrace);
                    return false;
                }
            }
        }

        private bool ProcessXML()
        {
            int countSaved = 0, countDeleted = 0;
            filesToDelete.Clear();

            string filename = "gamelist.xml";
            string filepath = Path.Combine(localDirectory, filename);

            LogAsync("Processing gamelist.xml...", true, true);

            try
            {
                XmlDocument doc = new XmlDocument();

                if (File.Exists(filepath))
                {
                    doc.Load(filepath);
                    if (File.Exists(filepath)) File.Delete(filepath);

                    XmlNodeList nodes = doc.DocumentElement.SelectNodes("/gameList/game");

                    for (int i = nodes.Count - 1; i >= 0; i--)
                    {
                        string path = null, name = null, image = null, video = null, marquee = null;

                        try { path = nodes[i].SelectSingleNode("path").InnerText; } catch { }
                        try { name = nodes[i].SelectSingleNode("name").InnerText; } catch { }
                        try { image = nodes[i].SelectSingleNode("image").InnerText; } catch { }
                        try { video = nodes[i].SelectSingleNode("video").InnerText; } catch { }
                        try { marquee = nodes[i].SelectSingleNode("marquee").InnerText; } catch { }

                        if (list.Contains(Path.GetFileName(path)))
                        {
                            countSaved++;
                        }

                        else
                        {
                            countDeleted++;
                            nodes[i].ParentNode.RemoveChild(nodes[i]);

                            if (name != null) gamesToDelete.Add(name);
                            else gamesToDelete.Add(path);

                            if (image != null) filesToDelete.Add(image);
                            if (video != null) filesToDelete.Add(video);
                            if (marquee != null) filesToDelete.Add(marquee);
                        }
                    }

                    LogAsync("OK", false);

                    LogAsync("");

                    LogAsync("Games in gamelist.xml:", true, true);
                    LogAsync((countSaved + countDeleted).ToString(), false);

                    LogAsync("Game files found:", true, true);
                    LogAsync(countSaved.ToString(), false);

                    LogAsync("Game files missing:", true, true);
                    LogAsync(countDeleted.ToString(), false);

                    LogAsync("");

                    if (countDeleted > 0)
                    {
                        LogAsync("Updating gamelist.xml...", true, true);
                        doc.Save(filepath);
                        LogAsync("OK", false);
                        return true;
                    }

                    else
                    {
                        LogAsync("No changes made to gamelist.xml.");
                        return false;
                    }
                }

                else
                {
                    LogAsync("Cannot find gamelist.xml.");
                    return false;
                }
            }

            catch (Exception ex)
            {
                LogAsync("ERROR", false);
                LogErrorAsync(ex.Message + ex.StackTrace);
                return false;
            }
        }

        // ******************************************************************

        public void LogErrorAsync(string txt, bool newLine = true)
        {
            Action action = () => LogError(txt, newLine);
            this.Invoke(action);
        }

        private void LogError(string txt, bool newLine = true)
        {
            if (logErrors)
            {
                Log("");
                Log(txt, newLine);
            }
        }

        public void LogAsync(string txt, bool newLine = true, bool justify = false)
        {
            Action action = () => Log(txt, newLine, justify);
            this.Invoke(action);
        }

        private void Log(string txt, bool newLine = true, bool justify = false)
        {
            if (newLine && txtLog.Text != "") txtLog.AppendText(Environment.NewLine);
            txtLog.AppendText(txt);

            if (justify)
            {
                int len = justifyLength - txt.Length;
                if (len < 0) len = 0;
                txtLog.AppendText(new String(' ', len));
            }

            Application.DoEvents();
        }

        private void DisableControls()
        {
            txtHost.Enabled = false;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            txtDirectory.Enabled = false;
            comboEmulators.Enabled = false;
            btnGo.Enabled = false;
            btnRestoreHost.Enabled = false;
            btnRestoreUsername.Enabled = false;
            btnRestorePassword.Enabled = false;
            btnRestoreRom.Enabled = false;
            btnRefreshEmulators.Enabled = false;
            btnClose.Enabled = false;
        }

        private void EnableControls()
        {
            txtHost.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            txtDirectory.Enabled = true;
            comboEmulators.Enabled = true;
            btnGo.Enabled = true;
            btnRestoreHost.Enabled = true;
            btnRestoreUsername.Enabled = true;
            btnRestorePassword.Enabled = true;
            btnRestoreRom.Enabled = true;
            btnRefreshEmulators.Enabled = true;
            btnClose.Enabled = true;
        }

        private void btnRestoreHost_Click(object sender, EventArgs e)
        {
            txtHost.Text = "retropie";
        }

        private void btnRestoreUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "pi";
        }

        private void btnRestorePassword_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "raspberry";
        }

        private void btnRestoreRom_Click(object sender, EventArgs e)
        {
            txtDirectory.Text = @"/home/pi/RetroPie/roms";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
