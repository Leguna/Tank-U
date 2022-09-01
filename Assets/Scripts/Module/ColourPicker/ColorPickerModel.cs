using System.Collections.Generic;
using System.Linq;
using Agate.MVC.Base;
using TankU.Module.Base;
using TankU.Module.ColourPicker.ColorPickerItem;
using UnityEngine;

namespace TankU.Module.ColourPicker
{
    public class ColorPickerModel : BaseModel, IColorPickerModel
    {
        public ColorPickerModel()
        {
            ListInputLayout = new List<InputLayout>();
            IsPicking = false;
            ListColorItemModel = new List<ColorItemModel>();
            ListColorItemSubView = new List<ColorItemSubView>();
            ColorPickerViewTemplate = Resources.Load<ColorItemSubView>("Prefabs/ColourPicker/ColorPickerItemView");
        }

        public List<int> ColorUnlocked { get; private set; }

        public List<ColorItemSubView> ListColorItemSubView { get; private set; }
        public List<ColorItemModel> ListColorItemModel { get; private set; }
        public List<InputLayout> ListInputLayout { get; private set; }

        public int GetIndexInputLayout(InputLayout inputLayout) => ListInputLayout.IndexOf(inputLayout);
        public bool IsPicking { get; private set; }


        public void StartPicking()
        {
            IsPicking = true;
            ListColorItemModel = new List<ColorItemModel>();
            ListColorItemSubView = new List<ColorItemSubView>();
            ListInputLayout = new List<InputLayout>();
            SetDataAsDirty();
        }

        public ColorItemSubView ColorPickerViewTemplate { get; }


        public void ConfirmColor(InputLayout inputLayout)
        {
            if (GetPickedColor().Contains(ListColorItemModel[GetIndexInputLayout(inputLayout)].ColorIndex)) return;
            ListColorItemModel[GetIndexInputLayout(inputLayout)].Confirm();
            SetDataAsDirty();
        }

        public void AddItem(ColorItemSubView itemSubView, ColorItemModel newModel, InputLayout inputLayout)
        {
            ListColorItemSubView.Add(itemSubView);
            ListColorItemModel.Add(newModel);
            ListInputLayout.Add(inputLayout);
            SetDataAsDirty();
        }

        public void FinishPicking()
        {
            IsPicking = false;
            SetDataAsDirty();
        }

        public List<int> GetPickedColor()
        {
            return (from t in ListColorItemModel where t.IsConfirm select t.ColorIndex).ToList();
        }

        public void CancelPick(InputLayout inputLayout)
        {
            var indexInput = GetIndexInputLayout(inputLayout);
            if (ListInputLayout.Contains(inputLayout))
            {
                if (ListColorItemModel[indexInput].IsConfirm)
                {
                    ListColorItemModel[indexInput].Cancel();
                }
                else
                {
                    Object.Destroy((ListColorItemSubView[indexInput].gameObject));
                    ListColorItemSubView.RemoveAt(indexInput);
                    ListColorItemModel.RemoveAt(indexInput);
                    ListInputLayout.RemoveAt(indexInput);
                }
            }

            SetDataAsDirty();
        }

        public void SetColorUnlocked(int[] allColorUnlocked)
        {
            for (int i = 0; i < ListColorItemModel.Count; i++)
            {
                ListColorItemModel[i].SetColorUnlocked(allColorUnlocked[i]);
            }
        }
    }
}