using System;
using System.Collections.Generic;
using System.Text;

namespace CarList
{
   public class AndroidDeviceService : IDeviceService
    {
        public string GetDeviceOS()
        {
            return "Android";
        }
    }
}
