using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingetonDesignPattern
{
    public sealed class SingeltonTemp
    {

        private static SingeltonTemp _instance;
        private static object _lockThis = new object();
        private SingeltonTemp()
        {
        }
        public static SingeltonTemp GetSingleton()
        {
            lock (_lockThis)
            {
                if (_instance == null) _instance = new SingeltonTemp();
            }
            return _instance;
        }
    }
}
