using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace TankU.Setting
{
    public class SettingModel : BaseModel, ISettingModel
    {
        public bool IsSfxOn { get; private set; } = true;

        public bool IsBgmOn { get; private set; } = true;

        public void SetSfxToggle()
        {
            IsSfxOn = !IsSfxOn;
            SetDataAsDirty();
        }

        public void SetBgmToggle()
        {
            IsBgmOn = !IsBgmOn;
            SetDataAsDirty();
        }
    }
}
