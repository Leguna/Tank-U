using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.ColourPicker.ColorPickerItem
{
    public class ColorItemModel : BaseModel, IColorItemModel
    {
        public ColorItemModel(string playerName, Color color)
        {
            PlayerName = playerName;
            Color = color;
        }

        public ColorItemModel()
        {
            PlayerName = "Player 1";
            Color = Color.cyan;
        }

        public void ChangeColor(Color color)
        {
            Color = color;
        }

        public void ChangeName(string name)
        {
            PlayerName = name;
        }

        public Color Color { get; private set; }
        public string PlayerName { get; private set; }
    }
}