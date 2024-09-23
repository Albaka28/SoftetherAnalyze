using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftetherAnalyze.DATA_Structure
{
    internal class Vhubs
    {
        readonly string name;
        private Dictionary<int, timeWindow> ID_timeWindow;






        public Vhubs(string loc_name) 
        { 
            name = loc_name;
        }
    }

    internal class timeWindow 
    {
        private DateTime opened;

        private bool state;

        private DateTime closed;



        public timeWindow(DateTime loc_open)
        {
            this.opened = loc_open;
            this.state = true;
        }

        public bool close(DateTime loc_close)
        {
            bool result;
            if (state)
            {
                this.closed = loc_close;
                state = false;
                result = true;
            }
            else 
            { 
                result = false;
            }
            return result;
        }




    }
}
