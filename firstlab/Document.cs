using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstlab
{
    class Document : TabPage
    {
        TextBox textbox;
        public string name { get; }
        bool modified = false;
        public Document()
        {
            textbox = new TextBox();
            textbox.Parent = this;
            textbox.Multiline = true;
            textbox.Dock = DockStyle.Fill;
        }
        public void Load(string FName, string FPath)
        {

        }
        public void SaveAs(string FName)
        {

        }
        public void Save()
        {

        }
    }
}
