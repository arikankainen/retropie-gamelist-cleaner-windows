using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroPieGamelistCleaner
{
    public partial class FormPrompt : Form
    {
        private List<string> filesToDelete = new List<string>();
        public List<string> FilesToDelete
        {
            get { return filesToDelete; }
        }

        private List<string> fileList = new List<string>();
        public List<string> FileList
        {
            set { fileList = value; }
        }

        public FormPrompt()
        {
            InitializeComponent();
        }

        private void FormPrompt_Load(object sender, EventArgs e)
        {
            if (fileList != null)
            {
                foreach (string file in fileList)
                {
                    ListViewItem item = new ListViewItem(file);
                    item.Checked = true;
                    listView1.Items.Add(item);
                }
            }
        }

        private void listView1_Layout(object sender, LayoutEventArgs e)
        {
            ResizeListView();
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            ResizeListView();
        }

        private void ResizeListView()
        {
            columnHeader1.Width = listView1.ClientRectangle.Width;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Selected = false;
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = true;
            }
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked) filesToDelete.Add(item.Text);
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            bool check = false;

            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked) check = true;
            }

            if (check) btnDelete.Enabled = true;
            else btnDelete.Enabled = false;
        }
    }
}
