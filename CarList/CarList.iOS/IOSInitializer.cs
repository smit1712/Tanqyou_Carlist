using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism;
using Foundation;
using UIKit;
using Prism.Ioc;

namespace CarList.iOS
{
    class IOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register(typeof(IDeviceService), typeof(IOSDeviceService));
        }
    }
}