using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RetroPieGamelistCleaner
{
    public partial class Form1
    {
        BackgroundWorker backgroundWorker;

        private void InitWorker()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        }

        private void RunWork(RunAction action)
        {
            runAction = action;
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if      (runAction == RunAction.Check) RunCheckAsync();
            else if (runAction == RunAction.Delete) RunDeleteAsync();
            else if (runAction == RunAction.Refresh) RunRefreshAsync();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if      (runAction == RunAction.Check) RunCheckCompleted();
            else if (runAction == RunAction.Delete) RunDeleteCompleted();
            else if (runAction == RunAction.Refresh) RunRefreshCompleted();
        }
    }
}
