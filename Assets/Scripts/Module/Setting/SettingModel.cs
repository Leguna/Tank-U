using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace TankU.Setting
{
    public class SettingModel : BaseModel, ISettingModel
    {
        public bool IsAudioOn { get; private set; } = true;

        public void SetAudioToggle()
        {
            IsAudioOn = !IsAudioOn;
            SetDataAsDirty();
        }
    }
}
