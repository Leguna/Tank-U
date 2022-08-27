using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerSpawnerView : ObjectView<IPlayerSpawnerModel>
    {
        [SerializeField] public List<Transform> _spawnTransform;
        [SerializeField] public int PLayerAmountSpawner;

        protected override void InitRenderModel(IPlayerSpawnerModel model)
        {
        }

        protected override void UpdateRenderModel(IPlayerSpawnerModel model)
        {
        }

    }
}
