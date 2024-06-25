using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerPossessItem : MonoBehaviour
{
    public ProssessInfo playerInfo;

    private void Awake()
    {
        Save();
    }

    public void Save()
    {
        string path = $"{Application.streamingAssetsPath}/ItemData_0624.json";
        string json = JsonUtility.ToJson(playerInfo);
        File.WriteAllText(path, json);
    }
}

[System.Serializable]
public class ProssessInfo
{
    public int coinCount;
    public int foodCount;
    public int woodCount;
    public int metalCount;
    public int crystalCount;
}
