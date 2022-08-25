using Agate.MVC.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankU.Module.ColourPicker.ColorPickerItem
{
    public class ColorItemSubView : ModelView<IColorItemModel>
    {
        [SerializeField] private TMP_Text _playerText;
        [SerializeField] private Image _colorImage;
        [SerializeField] private GameObject confirmCheck;

        protected override void InitRenderModel(IColorItemModel model)
        {
        }

        protected override void UpdateRenderModel(IColorItemModel model)
        {
            _playerText.text = model.PlayerName;
            _colorImage.color = model.Color;
            confirmCheck.SetActive(model.IsConfirm);
        }
    }
}