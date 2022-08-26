using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

namespace TankU.Setting
{
    public interface ISettingModel : IBaseModel
    {
        public bool IsAudioOn { get; }
    }
}
