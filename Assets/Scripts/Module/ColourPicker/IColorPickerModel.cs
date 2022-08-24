using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Module.ColourPicker.ColorPickerItem;

namespace TankU.Module.ColourPicker
{
    public interface IColorPickerModel : IBaseModel
    {
        List<ColorItemSubView> ListColorItemSubView { get; }
        ColorItemSubView ColorPickerViewTemplate { get; }
        List<ColorItemModel> ListColorItemModel { get; }

        bool IsPicking { get; }
    }
}