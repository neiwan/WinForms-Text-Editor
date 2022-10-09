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
        public DocSet()
        {
            Document D = new Document();
            this.TabPages.Add(D);
            
        }
    }
}
