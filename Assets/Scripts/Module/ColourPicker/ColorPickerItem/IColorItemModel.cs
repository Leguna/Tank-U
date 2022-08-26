using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.ColourPicker.ColorPickerItem
{
    public interface IColorItemModel : IBaseModel
    {
        Color Color { get; }
        int ColorIndex { get; }
        string PlayerName { get; }
        bool IsConfirm { get; }
    }
}