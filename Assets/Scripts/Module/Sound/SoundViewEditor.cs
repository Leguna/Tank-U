using TankU.Sound;
using UnityEditor;
using UnityEngine;

namespace TankU.Module.Sound
{
#if UNITY_EDITOR

    [CustomEditor(typeof(SoundView))]
    public class SoundViewEditor : Editor
    {
        [SerializeField] private AudioSource _bgm;
        [SerializeField] private AudioSource _sfxBombExplode;
        [SerializeField] private AudioSource _sfxBulletFire;
        [SerializeField] private AudioSource _sfxPlayerDie;

        private SoundController _soundController;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (!EditorApplication.isPlaying) return;

            var gv = (SoundView)target;

            EditorGUILayout.LabelField("Sound Command Center", EditorStyles.boldLabel);

            if (GUILayout.Button("Play BGM"))
            {
                //AudioClip bgmClip = _bgm.clip;
                //gv.PlayBgm(bgmClip);
                _soundController.PlayBgm(SoundBgmName.Game);
            }

            EditorGUILayout.LabelField("Sound Effects", EditorStyles.boldLabel);

            if (GUILayout.Button("Play Bomb Explode SFX"))
            {
                //AudioClip sfxClip = _sfxBombExplode.clip;
                //gv.PlaySfx(sfxClip);
                _soundController.PlaySfx(SoundEffectName.BombExplode);
            }

            if (GUILayout.Button("Play Bullet Fire SFX"))
            {
                AudioClip sfxClip = _sfxBulletFire.clip;
                gv.PlaySfx(sfxClip);
            }

            if (GUILayout.Button("Play Player Die SFX"))
            {
                AudioClip sfxClip = _sfxPlayerDie.clip;
                gv.PlaySfx(sfxClip);
            }
        }
    }
#endif
}