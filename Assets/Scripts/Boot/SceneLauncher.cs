using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using TankU.Main;
using TankU.Setting;

namespace TankU.Boot
{
    public abstract class SceneLauncher<TLauncher, TView> : BaseLauncher<TLauncher, TView>
        where TLauncher : BaseLauncher<TLauncher, TView>
        where TView : View
    {
        protected override ILoad GetLoader()
        {
            return SceneLoader.Instance;
        }

        protected override IMain GetMain()
        {
            return GameMain.Instance;
        }

        protected override ISplash GetSplash()
        {
            return SplashScreen.Instance;
        }
    }
}