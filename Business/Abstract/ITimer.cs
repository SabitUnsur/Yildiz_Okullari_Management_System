using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITimer
    {
        void Start(Action<object> callback, object state, TimeSpan delay, TimeSpan period);
        void Stop();
    }
}
