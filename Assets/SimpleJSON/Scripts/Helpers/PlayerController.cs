using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("DEPENDENCIES")]
    public PlayerSaveData playerSave;

    private void Start()
    {
        playerSave = SaveManager.Load<PlayerSaveData>(SaveManager.PLAYERSAVEDATAPATH);
    }
}
