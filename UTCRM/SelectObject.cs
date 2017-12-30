using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UTCRM
{
    public partial class SelectObject : Form
    {
        public SelectObject()
        {
            InitializeComponent();
        }

        private void SelectObject_Load(object sender, EventArgs e)
        {
            string[] titles = process.FindWindowTitle().Split('\t');
            foreach (string str in titles)
            {
                if (str.Replace(" ", "").Replace("\t", "").Length != 0 )
                    this.listBox1.Items.Add(str);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain.ObjectTitle = this.listBox1.SelectedItem.ToString();
            //MessageBox.Show(frmMain.ObjectTitle);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
