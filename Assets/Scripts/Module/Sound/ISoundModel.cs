using Agate.MVC.Base;

namespace TankU.Sound
{
    public interface ISoundModel : IBaseModel
    {
        float BgmVolume { get; }
        float SfxVolume { get; }
    }
}
