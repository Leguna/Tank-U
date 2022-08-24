using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.ColourPicker.ColorPickerItem
{
    public interface IColorItemModel : IBaseModel
    {
        Color Color { get; }
        string PlayerName { get; }
    }
}