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
                ItemFilesLoad("ȭ��");
                break;
            case 1:
                ItemFilesLoad("����");
                break;
            case 2:
                ItemFilesLoad("����");
                break;
            case 3:
                ItemFilesLoad("����");
                break;
            case 4:
                ItemFilesLoad("����");
                break;
        }
    }

    public void GetItemInfo(ItemData info)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"�̸� : {info.name}");
        sb.Append($"�з� : {info.type}");
        sb.Append($"ȿ�� : {info.passive}");

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

    public void ItemFilesLoad(string fileName)
    {
        readFromJson.Clear();

        DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);

        foreach (FileInfo file in di.GetFiles())
        {
            if(file.Name == $"{fileName}_ItemData.json")
            {
                string path = $"{Application.streamingAssetsPath}/{file.Name}";

                if (File.Exists(path) && file.Extension == ".json")
                {
                    string json = File.ReadAllText(path);
                    readFromJson.Add(JsonUtility.FromJson<ItemData>(json));
                    
                    GetItemInfo(JsonUtility.FromJson<ItemData>(json));
                }
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