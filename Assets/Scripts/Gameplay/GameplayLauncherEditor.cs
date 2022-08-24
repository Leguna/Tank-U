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
            if (!EditorApplication.isPlaying) return;

            var gc = (GameplayLauncher)target;

            EditorGUILayout.LabelField("Game Command Center", EditorStyles.boldLabel);

            if (GUILayout.Button("Start Game"))
            {
                gc.StartGame();
            }

            if (GUILayout.Button("Resume Game"))
            {
                gc.ResumeGame();
            }

            if (GUILayout.Button("Pause Game"))
            {
                gc.PauseGame();
            }

            EditorGUILayout.LabelField("Color Sample", EditorStyles.boldLabel);
            if (GUILayout.Button("Add Player Color"))
            {
                gc.AddPlayer();
            }

            if (GUILayout.Button("Start Picking Player"))
            {
                gc.StartPickingPlayer();
            }
            if (GUILayout.Button("Finish Picking Player"))
            {
                gc.FinishPickingPlayer();
            }
            if (GUILayout.Button("Cancel Picking Player"))
            {
                gc.CancelPickingPlayer();
            }
        }
    }
}