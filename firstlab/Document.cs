using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstlab
{
    class Document : TabPage
    {
        TextBox textbox;
        public bool Modified = false;
        public string path; 
        public Document(string docName)
        {
            textbox = new TextBox();
            textbox.Parent = this;
            textbox.Multiline = true;
            textbox.Dock = DockStyle.Fill;
            textbox.TextChanged += OnModify;
            this.Text = docName;
        }
        private void OnModify(object sender, EventArgs e)
        {
            Modified = true;
            if (!this.Text.Contains("(*)"))
                this.Text += "(*)";
        }
        public void Open(string FName)
        {
            this.path = FName;
            string text = File.ReadAllText(FName);
            this.textbox.Text = text;
            if (FName.Contains("\\"))     
                this.Text = FName.Substring(FName.LastIndexOf("\\")).Trim('\\');
            else
                this.Text = FName;

            Modified = false;
        }
        public void SaveAs(string FName)
        {
            try
            {
                System.IO.File.WriteAllText(FName, this.textbox.Text);
                this.Text = FName.Substring(FName.LastIndexOf("\\")).Trim('\\');
                this.path = FName;
                Modified = false;
                if (this.Text.Contains("(*)"))
                    this.Text = this.Text.Remove(this.Text.Length - 3);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Не удалось сохранить файл!");
            }
        }
        public void Save()
        {
            SaveAs(this.path);
        }
    }
}
