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
            Color = Color.cyan;
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
            Color = BaseColor.PlayerColors[ColorIndex % 4];
            SetDataAsDirty();
        }

        public void PrevColor()
        {
            ColorIndex--;
            if (ColorIndex == -1)
                ColorIndex = 3;
            Color = BaseColor.PlayerColors[ColorIndex % 4];
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