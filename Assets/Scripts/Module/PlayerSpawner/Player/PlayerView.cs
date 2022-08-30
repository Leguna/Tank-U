using System;
using Agate.MVC.Base;
using TankU.Module.Base;
using UnityEngine;

namespace TankU.Gameplay
{
    public class PlayerView : ObjectView<IPlayerModel>, IDamageableView
    {
        private Action _Move;
        private Action<PlayerModel, PlayerView> _onInit;
        private Action<Vector3, int> _onMove;
        private Action _rotate;
        private Action _cooldownBomb;
        private Action<int> _onTakeDamage;

        internal void SetCallbacks(Action Move, Action Rotate, Action<PlayerModel, PlayerView> Init,
            Action<Vector3, int> OnMove, Action CoolDownTimer, Action<int> OnTakeDamage)
        {
            _Move = Move;
            _onInit = Init;
            _onMove = OnMove;
            _rotate = Rotate;
            _cooldownBomb = CoolDownTimer;
            _onTakeDamage = OnTakeDamage;
        }

        protected override void InitRenderModel(IPlayerModel model)
        {
            TryGetComponent(out MeshRenderer meshRenderer);
            meshRenderer.material = model.MaterialColor;
            _onMove?.Invoke(Vector3.zero, _model.PlayerNumber);
        }

        protected override void UpdateRenderModel(IPlayerModel model)
        {
        }

        private void FixedUpdate()
        {
            _rotate?.Invoke();
            _Move?.Invoke();
        }

        private void Update()
        {
            _cooldownBomb?.Invoke();
        }

        public void TakeDamage(IDoingDamageModel damageModel)
        {
            _onTakeDamage?.Invoke(damageModel.Damage);
        }
    }
}