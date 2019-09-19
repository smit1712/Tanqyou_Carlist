using System;
using System.Collections.Generic;
using System.Text;

namespace CarList
{
   public class IOSDeviceService : IDeviceService 
    {
        public string GetDeviceOS()
        {
            return "IOS";
        }
    }
}
