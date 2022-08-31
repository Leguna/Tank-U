using Agate.MVC.Base;
using TankU.Module.Base;
using UnityEngine;

namespace TankU.Module.ColourPicker.ColorPickerItem
{
    public class ColorItemModel : BaseModel, IColorItemModel
    {
        public ColorItemModel(string playerName, Color color, bool isConfirm)
        {
            PlayerName = playerName;
            Color = color;
            IsConfirm = isConfirm;
        }

        public ColorItemModel()
        {
            IsConfirm = false;
            PlayerName = "Player 1";
            Color = BaseColor.PlayerColors[0];
        }

        public void ChangeColor(Color color)
        {
            Color = color;
            SetDataAsDirty();
        }

        public void ChangeName(string name)
        {
            PlayerName = name;
            SetDataAsDirty();
        }

        public void NextColor()
        {
            ColorIndex++;
            if (ColorIndex == BaseColor.PlayerColors.Count)
                ColorIndex = 0;
            Color = BaseColor.PlayerColors[ColorIndex % BaseColor.PlayerColors.Count];
            SetDataAsDirty();
        }

        public void PrevColor()
        {
            ColorIndex--;
            if (ColorIndex == -1)
                ColorIndex = BaseColor.PlayerColors.Count - 1;
            Color = BaseColor.PlayerColors[ColorIndex % BaseColor.PlayerColors.Count];
            SetDataAsDirty();
        }

        public Color Color { get; private set; }
        public int ColorIndex { get; private set; }
        public string PlayerName { get; private set; }
        public bool IsConfirm { get; private set; }

        public void Confirm()
        {
            IsConfirm = true;
            SetDataAsDirty();
        }

        public void Cancel()
        {
            IsConfirm = false;
            SetDataAsDirty();
        }
    }
}