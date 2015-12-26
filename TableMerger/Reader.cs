using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMerger
{
    class Reader
    {
        public Reader()
        {
        }
        public List<string> fulllist = new List<string>();
        public void TableCompiler(string filename, int tn)
        {
            int lng = File.ReadAllLines(filename).Length - 1;
            string[] lines = new string[lng];
            int i = 0;
            foreach (string eline in File.ReadAllLines(filename).Skip(1))
            {
                lines[i++] = eline;
            }
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (tn == 1)
                {
                    CSVTable element1 = new CSVTable();
                    StringBuilder sb1 = new StringBuilder();
                    int id = StringChecker(parts[0]);
                    if (id >= 0)
                    {
                        string[] oline = fulllist[id].Split(';');
                        element1.ID = oline[0];
                        element1.Descr = oline[1];
                        element1.Essen = Convert.ToInt32(oline[2]) + Convert.ToInt32(parts[2]);
                        element1.Rhg = 0;
                        element1.SWS = 0;
                        sb1.Append(element1.ID).Append(';').Append(element1.Descr).Append(';').Append(element1.Essen).Append(';').Append(element1.Rhg).Append(';').Append(element1.SWS);
                        fulllist[id] = sb1.ToString();
                    }
                    if (id == -1)
                    {
                        element1.ID = parts[0];
                        element1.Descr = parts[1];
                        element1.Essen = Convert.ToInt32(parts[2]);
                        element1.Rhg = 0;
                        element1.SWS = 0;
                        sb1.Append(element1.ID).Append(';').Append(element1.Descr).Append(';').Append(element1.Essen).Append(';').Append(element1.Rhg).Append(';').Append(element1.SWS);
                        fulllist.Add(sb1.ToString());
                    }
                }
                if (tn == 2)
                {
                    CSVTable element2 = new CSVTable();
                    StringBuilder sb2 = new StringBuilder();
                    int id = StringChecker(parts[0]);
                    if (id >= 0)
                    {
                        string[] oline = fulllist[id].Split(';');
                        element2.ID = oline[0];
                        element2.Descr = oline[1];
                        element2.Essen = Convert.ToInt32(oline[2]);
                        element2.Rhg = Convert.ToInt32(oline[3]) + Convert.ToInt32(parts[2]);
                        element2.SWS = 0;
                        sb2.Append(element2.ID).Append(';').Append(element2.Descr).Append(';').Append(element2.Essen).Append(';').Append(element2.Rhg).Append(';').Append(element2.SWS);
                        fulllist[id] = sb2.ToString();
                    }
                    if (id == -1)
                    {
                        element2.ID = parts[0];
                        element2.Descr = parts[1];
                        element2.Essen = 0;
                        element2.Rhg = Convert.ToInt32(parts[2]);
                        element2.SWS = 0;
                        sb2.Append(element2.ID).Append(';').Append(element2.Descr).Append(';').Append(element2.Essen).Append(';').Append(element2.Rhg).Append(';').Append(element2.SWS);
                        fulllist.Add(sb2.ToString());
                    }
                }
                if (tn == 3)
                {
                    CSVTable element3 = new CSVTable();
                    StringBuilder sb3 = new StringBuilder();
                    int id = StringChecker(parts[0]);
                    if (id >= 0)
                    {
                        string[] oline = fulllist[id].Split(';');
                        element3.ID = oline[0];
                        element3.Descr = oline[1];
                        element3.Essen = Convert.ToInt32(oline[2]);
                        element3.Rhg = Convert.ToInt32(oline[3]);
                        element3.SWS = Convert.ToInt32(oline[4]) + Convert.ToInt32(parts[2]);
                        sb3.Append(element3.ID).Append(';').Append(element3.Descr).Append(';').Append(element3.Essen).Append(';').Append(element3.Rhg).Append(';').Append(element3.SWS);
                        fulllist[id] = sb3.ToString();
                    }
                    if (id == -1)
                    {
                        element3.ID = parts[0];
                        element3.Descr = parts[1];
                        element3.Essen = 0;
                        element3.Rhg = 0;
                        element3.SWS = Convert.ToInt32(parts[2]);
                        sb3.Append(element3.ID).Append(';').Append(element3.Descr).Append(';').Append(element3.Essen).Append(';').Append(element3.Rhg).Append(';').Append(element3.SWS);
                        fulllist.Add(sb3.ToString());
                    }
                }
            }
        }
        public int StringChecker(string inpstr)
        {
            int nmb = 0;
            if (fulllist.Count == 0)
            {
                nmb = -1;
            }
            else
            {
                foreach (string elem in fulllist)
                {
                    if (elem.Contains(inpstr) == true)
                    {
                        nmb = fulllist.IndexOf(elem);
                        break;
                    }
                    else
                    {
                        nmb = -1;
                    }
                }
            }
            return (nmb);
        }
        public void SortList()
        {
            fulllist.Sort();
        }

        public void CreateHeader()
        {
            string header = "Artikelnummer;Beschreibung;Essen;Rathausgasse;Scwarzwaldstrasse";
            fulllist.Insert(0, header);
        }
        public void FileWriter(string outname)
        {
            File.WriteAllLines(outname, fulllist);
        }
    }
}
