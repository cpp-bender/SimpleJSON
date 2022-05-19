using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var gameManager = (GameManager)target;

        if (GUILayout.Button("Save"))
        {
            gameManager.SaveData();
        }

        if (GUILayout.Button("Load"))
        {
            gameManager.LoadData();
        }
    }
}
