using Agate.MVC.Base;
using UnityEngine;

namespace Leguna.ExampleMVC.Module.SoundFx
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