using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringAspNetCoreApps.Infrastructure
{
    public class UpTimeService
    {
        private Stopwatch timer = new Stopwatch();

        public long Uptime => timer.ElapsedMilliseconds;

        public UpTimeService()
        {
            timer.Start();
        }
    }
}
