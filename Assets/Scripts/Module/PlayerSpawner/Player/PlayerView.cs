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
        private Action<float> _onUpdate;
        private MeshRenderer _meshRenderer;

        internal void SetCallbacks(Action Move, Action Rotate, Action<PlayerModel, PlayerView> Init,
            Action<Vector3, int> OnMove, Action CoolDownTimer, Action<int> OnTakeDamage, Action<float> onUpdate)
        {
            _Move = Move;
            _onInit = Init;
            _onMove = OnMove;
            _rotate = Rotate;
            _cooldownBomb = CoolDownTimer;
            _onTakeDamage = OnTakeDamage;
            _onUpdate = onUpdate;
        }

        protected override void InitRenderModel(IPlayerModel model)
        {
            TryGetComponent(out _meshRenderer);
            _meshRenderer.material = model.MaterialColor;
            _onMove?.Invoke(Vector3.zero, _model.PlayerNumber);
        }


        protected override void UpdateRenderModel(IPlayerModel model)
        {
            _meshRenderer.material = model.MaterialColor;
        }

        private void FixedUpdate()
        {
            _rotate?.Invoke();
            _Move?.Invoke();
        }

        private void Update()
        {
            _cooldownBomb?.Invoke();
            _onUpdate?.Invoke(Time.deltaTime);
        }

        public void TakeDamage(IDoingDamageModel damageModel)
        {
            _onTakeDamage?.Invoke(damageModel.Damage);
        }
    }
}