using SimpleJSON;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerSaveData data;

    private void Awake()
    {
        data = SaveManager.Load<PlayerSaveData>(data.FileName);
    }
}
