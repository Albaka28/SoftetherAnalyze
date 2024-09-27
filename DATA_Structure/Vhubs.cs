using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SoftetherAnalyze.DATA_Structure
{
    internal class Vhubs
    {
        readonly string name;
        private int ID_lasttimeWindows;
        private Dictionary<int, timeWindow> ID_timeWindow;
        private Dictionary<int, List<Connection>> TimeWindowID_ConnectionList;

        public Vhubs(string loc_name) 
        { 
            name = loc_name;
        }

        public bool addConnection(Connection toHandle)
        {
            bool result = false;

            int loc_timeWindowCtr = ID_lasttimeWindows;

            int loc_lastFit = -1;

            //the timewindows get scanned from newest to oldest to sort the connection to the corresponding timestamp
            while (loc_timeWindowCtr > 0)
            {
                //if Timewindow is incomplete it will be tested if its theoreticly fitting depending on that it will be applied or not
                if (ID_timeWindow[loc_timeWindowCtr].GetComplete())
                {
                    //checking if its theoreticly  fitting
                    if(toHandle.GetOpened().Ticks > ID_timeWindow[loc_timeWindowCtr].GetOpened().Ticks) 
                    {
                        loc_lastFit = loc_timeWindowCtr;
                    }
                    //if not, last state will be checked, if not null it will be applied, and loop get ended
                    else if(toHandle.GetOpened().Ticks < ID_timeWindow[loc_timeWindowCtr].GetOpened().Ticks)
                    {
                        //if laststate not null it gets applied
                        if (loc_lastFit != -1) 
                        {
                            TimeWindowID_ConnectionList[loc_lastFit].Add(toHandle);
                            result = true;
                        }
                        //if null: exeption
                        else 
                        {
                            throw new Exception();
                        }
                    }
                    //anything sus? error gets thrown
                    else
                    { 
                        throw new Exception(); 
                    }
                }
                
                //if the timewindow is Completed and its the correct one the connection will be added. The loop will be exited
                else if (toHandle.GetOpened().Ticks > ID_timeWindow[loc_timeWindowCtr].GetOpened().Ticks && toHandle.GetOpened().Ticks < ID_timeWindow[loc_timeWindowCtr].GetClosed().Ticks && ID_timeWindow[loc_timeWindowCtr].GetComplete())
                {
                    TimeWindowID_ConnectionList[loc_timeWindowCtr].Add(toHandle);
                    result = true;
                    loc_timeWindowCtr = 0;
                }
                
                //if the timeWindow isnt the right one the nextone will be tested
                else if (ID_timeWindow[loc_timeWindowCtr].GetComplete())
                {
                    loc_timeWindowCtr--;
                }

                //anything sus?: error gets thrown
                else
                {
                    //Todo: React to unnormal behavior 
                    throw new Exception();
                }
            }

            return result;
        }
    }

    internal class timeWindow : SoftEtherLib.timeDepend
    {
        private bool state;

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

    internal class Connection : SoftEtherLib.timeDepend
    {
        private string con_SID;

        private IPAddress con_HostIP;
        private int con_Port;
        private string con_HName;

        readonly int con_HID;
    }
}
