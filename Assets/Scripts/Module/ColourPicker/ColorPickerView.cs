using Agate.MVC.Base;
using UnityEngine;

namespace TankU.Module.ColourPicker
{
    public class ColorPickerView : ObjectView<IColorPickerModel>
    {
        [SerializeField] public Transform colorPickerGroupTransform;
        [SerializeField] public Transform colorPickerTitle;

        protected override void InitRenderModel(IColorPickerModel model)
        {
        }

        protected override void UpdateRenderModel(IColorPickerModel model)
        {
            if (!model.IsPicking)
            {
                HideView();
                return;
            }

            colorPickerGroupTransform.gameObject.SetActive(true);
            colorPickerTitle.gameObject.SetActive(model.ListColorItemSubView.Count <= 0);

            if (model.ListColorItemSubView.Count == 0)
            {
                for (int i = 0; i < colorPickerGroupTransform.childCount; i++)
                {
                    Destroy(colorPickerGroupTransform.GetChild(i).gameObject);
                }
            }

            for (var i = 0; i < model.ListColorItemSubView.Count; i++)
            {
                model.ListColorItemSubView[i].SetModel(model.ListColorItemModel[i]);
            }
        }

        public void HideView()
        {
            colorPickerTitle.gameObject.SetActive(false);
            colorPickerGroupTransform.gameObject.SetActive(false);
        }
    }
}