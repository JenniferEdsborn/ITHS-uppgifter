
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Tidsrapportering
{
    internal class Worker
    {        
        string WorkerID { get; set; }
        string Work { get; set; }
        DateTime Workdate { get; set; }

        public Worker(string workerID, string work, DateTime workdate)
        {
            if(workerID == "" || work == "")
            {
                throw new Exception("Någonting gick fel");
            }

            this.WorkerID = workerID;
            this.Work = work;
            this.Workdate = workdate;
        }

        public override string ToString()
        {
            return $"{WorkerID} {Workdate} {Work}";
        }
    }
}
