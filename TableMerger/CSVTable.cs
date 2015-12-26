using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMerger
{
    public class CSVTable
    {
        private string id, descr;
        private int essen, rhg, sws;
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Descr
        {
            get
            {
                return descr;
            }
            set
            {
                descr = value;
            }
        }
        public int Essen
        {
            get
            {
                return essen;
            }
            set
            {
                essen = value;
            }
        }
        public int Rhg
        {
            get
            {
                return rhg;
            }
            set
            {
                rhg = value;
            }
        }
        public int SWS
        { 
            get
            {
                return sws;
            }
            set
            {
                sws = value;
            }
        }
    }
}
