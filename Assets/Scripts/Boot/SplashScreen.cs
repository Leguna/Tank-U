﻿using Agate.MVC.Base;
using Agate.MVC.Core;

namespace TankU.Boot
{
    public class SplashScreen : BaseSplash<SplashScreen>
    {
        protected override IMain GetMain()
        {
            return GameMain.Instance;
        }

        protected override ILoad GetLoader()
        {
            return SceneLoader.Instance;
        }
    }
}