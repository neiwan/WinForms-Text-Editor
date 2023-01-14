using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstlab
{
    public partial class Form1 : Form
    {
        DocSet DS;
        public Form1()
        {
            InitializeComponent();
            DS = new DocSet();
            DS.Parent = this.panel2;
            DS.Dock = DockStyle.Fill;
            DS.Recent.Change += ChangeInRDL;
            DS.Recent.LoadData();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (DS.TabCount != 0)
            {
                DS.SelectedTab = DS.TabPages[0];
                DS.CloseDocument();
            }
            DS.Recent.SaveData();
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DS.Open();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DS.Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DS.SaveAs();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DS.New();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DS.CloseDocument();
        }
        private void ChangeInRDL()
        {
            recent.DropDownItems.Clear();
            for (int i = 0; i < DS.Recent.Count; i++)
            {
                ToolStripMenuItem menu = new ToolStripMenuItem();
                menu.Text = DS.Recent[i];
                recent.DropDownItems.Add(menu);
                menu.Click += Menu_Click;
            }
        }
        private void Menu_Click(object sender, EventArgs e)
        {
            DS.OpenAs(((ToolStripMenuItem)sender).Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            while (DS.TabCount != 0)
            {
                DS.SelectedTab = DS.TabPages[0];
                DS.CloseDocument();
            }
            DS.Recent.SaveData();
        }
    }
}
