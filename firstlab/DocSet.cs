using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstlab
{
    class DocSet : TabControl
    {
        private RecentDocList recent = new RecentDocList();
        public RecentDocList Recent { get { return recent; } }
        public void New()
        {
            Document page = new Document("Doc " + (this.TabCount + 1));
            this.TabPages.Add(page); 
        }
        public void Open()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filename = ofd.FileName;

                for (int i = 0; i < this.TabCount; i++)
                {
                    Document page = (Document)this.TabPages[i];
                    if (filename == page.path)
                    {
                        this.SelectedTab = this.TabPages[i];
                        return;
                    }
                }

                New();
                this.SelectedTab = this.TabPages[this.TabCount - 1];
                Document tmp = (Document)this.SelectedTab;
                tmp.Open(filename);
                Recent.Add(filename);
            }
        }
        public void Save()
        {
            if (this.TabPages.Count != 0)
            {
                Document tmp = (Document)this.SelectedTab;
                if (tmp.path == null & tmp.Modified)
                {
                    SaveAs();
                }
                else
                {
                    if (tmp.Modified)
                        tmp.Save();
                }
            }
            else
            {
                MessageBox.Show("Не открыт ни один файл!");
            }
        }
        public void SaveAs()
        {
            Document tmp = (Document)this.SelectedTab;
            if (this.TabPages.Count != 0)
            {
                if (tmp.Modified)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    DialogResult result = saveFileDialog1.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string pathName = saveFileDialog1.FileName;
                        tmp.SaveAs(pathName);
                        this.Recent.Add(pathName);
                    }
                }
            }
            else
            {
                MessageBox.Show("Не открыт ни один файл!");
            }
        }

        public void CloseDocument()
        {
            if (this.TabPages.Count != 0)
            {
                Document tmp = (Document)this.SelectedTab;
                if (tmp.Modified)
                {
                    string warn = "Сохранить файл :'" + tmp.Text + "' ?";

                    if (MessageBox.Show(warn, "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Save();
                }
                this.TabPages.Remove(this.SelectedTab);
            }
            else
            {
                MessageBox.Show("Не открыт ни один файл!");
            }
        }
        public void OpenAs(string FName)
        {
            try
            {
                for (int i = 0; i < this.TabCount; i++)
                {
                    Document page = (Document)this.TabPages[i];
                    if (FName == page.path)
                    {
                        this.SelectedTab = this.TabPages[i];
                        return;
                    }
                }
                this.New();
                Document tmp = (Document)this.TabPages[this.TabCount - 1];
                if (System.IO.File.Exists(FName))
                {
                    tmp.Open(FName);
                    Recent.Remove(FName);
                    Recent.Add(FName);
                }
                else
                    MessageBox.Show("Указанный файл не существует!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("По указанному пути не удалось открыть файл!");
            }
        }
    }
}
