using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Text;

public class Example0618 : MonoBehaviour
{
    public Text text;

    public List<ItemData> itemData;
    public List<ItemData> readFromJson = new List<ItemData>();

    private void Awake()
    {
        //Save();
    }

    public void ItemButtonClick(int i)
    {
        switch(i)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }

    public void GetItemInfo(ItemData info)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"이름 : {info.name}");
        sb.Append($"분류 : {info.type}");
        sb.Append($"효과 : {info.passive}");

        text.text = sb.ToString();
    }

    public void Save()
    {
        foreach (ItemData data in itemData)
        {
            string path = $"{Application.streamingAssetsPath}/{data.name}_ItemData.json";
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json);
        }
    }

    public void ItemFilesLoad()
    {
        readFromJson.Clear();

        DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);

        foreach (FileInfo file in di.GetFiles())
        {
            string path = $"{Application.streamingAssetsPath}/{file.Name}";

            if (File.Exists(path) && file.Extension == ".json")
            {
                string json = File.ReadAllText(path);
                readFromJson.Add(JsonUtility.FromJson<ItemData>(json));
            }
        }
    }
}

[System.Serializable]
public class ItemData
{
    public string name;
    public int id;
    public string type;
    public string passive;
}