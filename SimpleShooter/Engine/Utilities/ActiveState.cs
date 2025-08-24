using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShooter.Engine.Utilities
{
    public class ActiveState
    {
        public bool is_active = false;
        int active_per_frame = 0;
        public Func<int, bool> activeState;
        public ActiveState(Func<int, bool> ActiveState)
        {
            this.activeState = ActiveState;
        }
        public void Deactivate()
        {
            is_active = false;
            active_per_frame = 0;
        }
        public void Activate()
        {
            is_active = true;
            active_per_frame = 0;
        }
        public void Update(bool Deactivate_if_false)
        {
            if (Deactivate_if_false == false)
            {
                is_active = false;
                active_per_frame = 0;
            }
            Update();
        }
        public void Update()
        {
            if (is_active)
            {
                active_per_frame++;
                is_active = activeState.Invoke(active_per_frame);
            }
        }

    }
    public class ActiveState<Type, Return>
    {
        public bool is_active = false;
        int active_per_frame = 0;
        public Func<Type, Return> func;
        public ActiveState(Func<Type, Return> func)
        {
            this.func = func;
        }
        public void Deactivate()
        {
            is_active = false;
            active_per_frame = 0;
        }
        public void Activate()
        {
            is_active = true;
        }
        public Return Update(Type data)
        {
            if (is_active)
            {
                active_per_frame++;
                return func.Invoke(data);
            }
            return default(Return);

        }

    }
}
