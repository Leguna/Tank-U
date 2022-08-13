using Agate.MVC.Base;

namespace Leguna.ExampleMVC.Module.ClickGame
{
    public interface IClickGameModel : IBaseModel
    {
        public int Coin { get; }
    }
}