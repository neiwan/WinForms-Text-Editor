using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstlab
{
    class RecentDocList
    {
        List<string> recentFiles = new List<string>();
        private string RDL = "C:\\Users\\v8950\\source\\repos\\newLabs\\firstlab\\firstlab\\recent.txt";
        public delegate void ChangeHandler();
        public event ChangeHandler Change;
        public void Remove(string s)
        {
            recentFiles.Remove(s);
        }
        public void SaveData()
        {
            StreamWriter sw = new StreamWriter(RDL, false);
            foreach (string file in recentFiles)
                sw.WriteLine(file);
            sw.Close();
        }
        public void LoadData()
        {        
            string line = "";
            StreamReader sr = new StreamReader(RDL);
            while (line != null)
            {
                line = sr.ReadLine();
                if (line != null)
                    recentFiles.Add(line);
            }
            sr.Close();
            Change?.Invoke();
        }
        public void Add(string filePath)
        {
            if (recentFiles.Count == 8)
            {
                recentFiles.RemoveAt(0);
            }
            recentFiles.Add(filePath);
            Change?.Invoke();
        }
        public string this[int i]
        {
            get
            {
                if (i < Count && i >= 0)
                {
                    return recentFiles[i];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        public int Count { get { return recentFiles.Count; } }
    }
}
