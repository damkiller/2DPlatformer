using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShooter.Engine.Utilities

{
    public class DelayActionTimer<T>
    {
        public int delay_milisecounds = 0;
        public int timer = 0;
        Func<int,T> action;
        public DelayActionTimer(int delay, Func<int, T> action)
        {
            this.delay_milisecounds = delay;
            this.action = action;
        }
        public async Task<T> Update()
        {
            await Task.Delay(delay_milisecounds);
            timer += delay_milisecounds;
            return action(timer);
        }
    }
    public class DelayActionTimer
    {
        public int delay_milisecounds = 0;
        public int timer = 0;
        Action action;
        public DelayActionTimer(int delay, Action action)
        {
            this.delay_milisecounds = delay;
            this.action = action;
        }
        public async void Update()
        {
            await Task.Delay(delay_milisecounds);
            timer += delay_milisecounds;
            action();
        }
    }







}


