using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftetherAnalyze.SoftEtherLib
{
    internal class timeDepend
    {
        protected DateTime opened;
        protected DateTime closed;

        public DateTime GetOpened() { return opened; }
        public DateTime GetClosed() { return closed; }

        public bool GetComplete() 
        {
            if(closed == DateTime.MinValue) 
            { 
                return false;
            }
            else
            {
                return true;
            }
                
        }
    }
}
