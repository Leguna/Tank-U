using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using TMPro;

namespace TankU.Module.Result
{
    public class CardResultView : BaseView
    {
        [SerializeField] private TMP_Text _status;
        [SerializeField] private TMP_Text _playerName;
        [SerializeField] private TMP_Text _exp;
        [SerializeField] private TMP_Text _totalExp;
        [SerializeField] private TMP_Text _level;
    } 
}
