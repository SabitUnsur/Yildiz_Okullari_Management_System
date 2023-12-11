using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TimerWrapper : ITimer
    {
        private System.Threading.Timer _timer;

        public TimerWrapper(){}

        public void Start(Action<object> callback, object state, TimeSpan delay, TimeSpan period)
        {
            _timer = new System.Threading.Timer(
                new TimerCallback(CallbackHandler),
                callback,
                delay,
                period);
        }

        private void CallbackHandler(object state)
        {
            var callback = state as Action<object>;
            callback?.Invoke(state);
        }

        public void Stop()
        {
            _timer?.Dispose();
        }
    }
}
