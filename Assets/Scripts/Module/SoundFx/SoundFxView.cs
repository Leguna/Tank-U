using Agate.MVC.Base;
using UnityEngine;
// TODO @Leguna: Delete this.
namespace SpacePlan.Module.SoundFx
{
    public class SoundFxView : BaseView
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _coinSound;

        public void PlayCoinSound()
        {
            _audioSource.PlayOneShot(_coinSound);
        }
    }
}