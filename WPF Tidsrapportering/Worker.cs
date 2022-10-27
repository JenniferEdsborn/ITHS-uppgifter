
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Tidsrapportering
{
    internal class Worker
    {
        public List<string> Times= new List<string>();
        public DateTime timestart = DateTime.Parse("00:00:00");
        public DateTime timeend = DateTime.Parse("23:45:00");

        string WorkerID { get; set; }
        string Work { get; set; }
        DateTime Workdate { get; set; }

        public Worker(string workerID, string work, DateTime workdate)
        {
            this.WorkerID = workerID;
            this.Work = work;
            this.Workdate = workdate;
        }

        public override string ToString()
        {
            return WorkerID + " " + Workdate.ToString() + " " + Work;
        }
    }
}
