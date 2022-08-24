using UnityEditor;
using UnityEngine;

namespace TankU.Gameplay
{
    [CustomEditor(typeof(GameplayLauncher))]
    public class GameplayLauncherEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GameplayLauncher myScript = (GameplayLauncher)target;

            if (GUILayout.Button("Start Game"))
            {
                myScript.StartGame();
            }

            if (GUILayout.Button("Resume Game"))
            {
                myScript.ResumeGame();
            }

            if (GUILayout.Button("Pause Game"))
            {
                myScript.PauseGame();
            }
        }
    }
}