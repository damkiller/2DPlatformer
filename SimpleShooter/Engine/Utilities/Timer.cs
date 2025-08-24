using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShooter.Engine.Utilities
{
    public class ActionTimer
    {

        public bool repeat_action = false;
        private int wait_time_in_millisecounds { get; set; }
        public ActionTimer()
        {
            wait_time_in_millisecounds = 0;
        }
        public ActionTimer(int wait_time_in_millisecounds)
        {
            this.wait_time_in_millisecounds = wait_time_in_millisecounds;
        }
        public void SetWaitTime(int wait_time_in_millisecounds)
        {
            this.wait_time_in_millisecounds = wait_time_in_millisecounds;
        }
        public async Task Start(Action action)
        {
            if (wait_time_in_millisecounds != 0)
            {
                await Task.Delay(wait_time_in_millisecounds);
                action();
                while (repeat_action)
                {
                    await Task.Delay(wait_time_in_millisecounds);
                    action();
                }

            }
            wait_time_in_millisecounds = 0;


        }
    }
    }
