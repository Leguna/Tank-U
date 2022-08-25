using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Agate.MVC.Base;
using TankU.Message;
using TankU.Module.Base;
using TankU.Module.ColourPicker.ColorPickerItem;
using UnityEngine;

namespace TankU.Module.ColourPicker
{
    public class ColorPickerController : ObjectController<ColorPickerController, ColorPickerModel, IColorPickerModel,
        ColorPickerView>
    {
        private ColorSelectInput _colorSelectInput = new();

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _colorSelectInput.SelectColorKeyboardLeft.Enable();
            _colorSelectInput.SelectColorKeyboardRight.Enable();
            _colorSelectInput.SelectColorKeyboardGamepad.Enable();
            _colorSelectInput.SelectColorKeyboardLeft.Confirm.performed += _ => Confirm(InputLayout.KeyboardLeft);
            _colorSelectInput.SelectColorKeyboardRight.Confirm.performed += _ => Confirm(InputLayout.KeyboardRight);
            _colorSelectInput.SelectColorKeyboardGamepad.Confirm.performed += _ => Confirm(InputLayout.Gamepad);
            _colorSelectInput.SelectColorKeyboardLeft.Cancel.performed += _ => Cancel(InputLayout.KeyboardLeft);
            _colorSelectInput.SelectColorKeyboardRight.Cancel.performed += _ => Cancel(InputLayout.KeyboardRight);
            _colorSelectInput.SelectColorKeyboardGamepad.Cancel.performed += _ => Cancel(InputLayout.Gamepad);
            _colorSelectInput.SelectColorKeyboardLeft.Next.performed += _ => Next(InputLayout.KeyboardLeft);
            _colorSelectInput.SelectColorKeyboardLeft.Prev.performed += _ => Prev(InputLayout.KeyboardLeft);
            _colorSelectInput.SelectColorKeyboardRight.Next.performed += _ => Next(InputLayout.KeyboardRight);
            _colorSelectInput.SelectColorKeyboardRight.Prev.performed += _ => Prev(InputLayout.KeyboardRight);
            _colorSelectInput.SelectColorKeyboardGamepad.Next.performed += _ => Next(InputLayout.Gamepad);
            _colorSelectInput.SelectColorKeyboardGamepad.Prev.performed += _ => Prev(InputLayout.Gamepad);
        }

        private void Confirm(InputLayout inputLayout)
        {
            if (_model.ListInputLayout.Contains(inputLayout))
            {
                if (CheckAllPlayerPickColor())
                    FinishPickingCharacter();
                _model.ConfirmColor(inputLayout);
                Debug.Log($"Confirm {inputLayout}");
            }
            else AddColorPlayer(inputLayout);
        }

        private void Cancel(InputLayout inputLayout)
        {
            if (_model.ListInputLayout.Count == 0)
            {
                CancelPickingCharacter();
                return;
            }

            Debug.Log(_model);
        }

        private bool CheckAllPlayerPickColor()
        {
            return _model.ListColorItemModel.All(colorItemModel => colorItemModel.IsConfirm);
        }

        private void Prev(InputLayout inputLayout)
        {
            if (!_model.ListInputLayout.Contains(inputLayout)) return;
            var indexOf = _model.ListInputLayout.IndexOf(inputLayout);
            if (_model.ListColorItemModel[_model.GetIndexInputLayout(inputLayout)].IsConfirm) return;
            _model.ListColorItemModel[indexOf].PrevColor();
        }

        private void Next(InputLayout inputLayout)
        {
            if (!_model.ListInputLayout.Contains(inputLayout)) return;
            var indexOf = _model.ListInputLayout.IndexOf(inputLayout);
            if (_model.ListColorItemModel[_model.GetIndexInputLayout(inputLayout)].IsConfirm) return;
            _model.ListColorItemModel[indexOf].NextColor();
        }

        public override IEnumerator Terminate()
        {
            _colorSelectInput.SelectColorKeyboardLeft.Disable();
            _colorSelectInput.SelectColorKeyboardRight.Disable();
            _colorSelectInput.SelectColorKeyboardGamepad.Disable();
            yield return base.Terminate();
        }

        public void StartPickingCharacter()
        {
            _model.StartPicking();
        }

        public void AddColorPlayer(InputLayout inputLayout)
        {
            if (!_model.IsPicking)
            {
                Debug.Log("Not picking player. Start First!");
                return;
            }

            var count = _model.ListColorItemSubView.Count;
            if (count == 4)
            {
                Debug.Log("Only 4 colors allowed");
                return;
            }

            var newModel = new ColorItemModel($"Player {count + 1}", BaseColor.PlayerColors[count], false);
            var itemSubView = Object.Instantiate(_model.ColorPickerViewTemplate, Vector3.zero,
                Quaternion.identity,
                _view.colorPickerGroupTransform);
            itemSubView.SetModel(newModel);
            _model.AddItem(itemSubView, newModel, inputLayout);

            Debug.Log($"Player {count + 1} added");
        }

        public void CancelPickingCharacter()
        {
            if (!_model.IsPicking)
            {
                Debug.Log("Can't cancel picking color. Start First!");
                return;
            }

            Debug.Log("Cancel picking player.");

            _view.HideView();
            Publish(new ColorPickingMessage(PickingState.Cancel, new List<Color>()));
        }

        public void FinishPickingCharacter()
        {
            if (!_model.IsPicking)
            {
                Debug.Log("Can't finish what you not even start. Start First!");
                return;
            }

            Debug.Log("Finish Picking Player");
            _model.FinishPicking();
            Publish(new ColorPickingMessage(PickingState.Finish, _model.GetPickedColor()));
            Debug.Log($"Color picked {string.Join(", ", _model.GetPickedColor().ToArray())}");
        }
    }
}