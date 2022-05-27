using UnityEditor;
using UnityEngine;
using SimpleJSON;


[CustomEditor(typeof(PlayerController))]
public class PlayerControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var player = (PlayerController)target;

        if (GUILayout.Button("Reset Player Data"))
        {
            var playerSaveData = new PlayerSaveData(1, 1);

            SaveManager.Reset(playerSaveData, "PlayerSaveData.json");
        }

        if (GUILayout.Button("Reset Multiple Player Data"))
        {
            var playerSaveDatas = new PlayerSaveData[] { new PlayerSaveData(0, 0) };

            SaveManager.Reset(playerSaveDatas, "PlayerSaveDatas.json");
        }
    }
}
