using System.Collections.Generic;
using Agate.MVC.Base;
using TankU.Module.ColourPicker.ColorPickerItem;
using UnityEngine;

namespace TankU.Module.ColourPicker
{
    public class ColorPickerModel : BaseModel, IColorPickerModel
    {
        public ColorPickerModel()
        {
            IsPicking = false;
            ListColorItemModel = new List<ColorItemModel>();
            ListColorItemSubView = new List<ColorItemSubView>();
            ColorPickerViewTemplate = Resources.Load<ColorItemSubView>("Prefabs/ColourPicker/ColorPickerItemView");
        }

        public List<ColorItemSubView> ListColorItemSubView { get; private set; }
        public List<ColorItemModel> ListColorItemModel { get; private set; }
        public bool IsPicking { get; private set; }

        public void StartPicking()
        {
            IsPicking = true;
            ListColorItemModel = new List<ColorItemModel>();
            ListColorItemSubView = new List<ColorItemSubView>();
            SetDataAsDirty();
        }

        public ColorItemSubView ColorPickerViewTemplate { get; }

        public void AddItem(ColorItemSubView itemSubView, ColorItemModel newModel)
        {
            ListColorItemSubView.Add(itemSubView);
            ListColorItemModel.Add(newModel);
            SetDataAsDirty();
        }

        public void FinishPicking()
        {
            IsPicking = false;
            SetDataAsDirty();
        }

        public List<Color> GetPickedColor()
        {
            return new List<Color>();
        }
    }
}