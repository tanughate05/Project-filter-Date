using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Report_Filter
{
    class Invoice
    {
        //public Invoice(int Logicalref,string  date,string ficheno,string fichetype,string code,string definition,double netTotal)
        //{
        //    this.LOGICALREF = Logicalref;
        //    this.DATE_ = date;
        //    this.FICHENO = ficheno;
        //    this.FICHETYPE = fichetype;
        //    this.CODE = code;
        //    this.DEFINITION_ = definition;
        //    this.NETTOTAL = netTotal;
        //}
        public int LOGICALREF { get; set; }

        public string DATE_ { get; set; }
        

        public string FICHENO  { get; set; }

        public string FICHETYPE { get; set; }

        public string CODE { get; set; }

        public string DEFINITION_ { get; set; }

        public double NETTOTAL { get; set; }

        //public int getLOGICALREF()
        //{
        //    return this.LOGICALREF;
        //}
        //public string getDATE_()
        //{
        //    return this.DATE_;
        //}

        //public string getFICHENO()
        //{
        //    return this.FICHENO.ToString();
        //}
        //public string getFICHETYPE()
        //{
        //    return this.FICHETYPE;
        //}
        //public string getCODE()
        //{
        //    return this.CODE;
        //}
        //public string getDEFINITION()
        //{
        //    return this.DEFINITION_;
        //}
        //public double getNETTOTAL()
        //{
        //    return this.NETTOTAL;
        //}
    }
}
