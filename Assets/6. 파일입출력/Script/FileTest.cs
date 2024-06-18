using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

public class FileTest : MonoBehaviour
{
    public PlayerData playerData;
    public Text text;

    public List<PlayerData> playerDatas;
    public List<PlayerData> readFromJson = new List<PlayerData>();

    private void Start()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("Data Path : ");
        sb.AppendLine(Application.dataPath);
        sb.Append("Pers data path : ");
        sb.AppendLine(Application.persistentDataPath);
        sb.Append("Str data path : ");
        sb.AppendLine(Application.streamingAssetsPath);

        //�̵������� �ϸ� ȥ�� (�޸� ����)
        //string path = Application.dataPath;
        //path += "\n";
        //path += Application.persistentDataPath;
        //path += "\n";
        //path += Application.streamingAssetsPath;

        text.text = sb.ToString();
        
    }

    public void Save()
    {
        foreach (PlayerData data in playerDatas)
        {
            //print(JsonUtility.ToJson(new PlayerData()));

            //�ؽ�Ʈ ������ ����� ��� (���ϸ�, Ȯ���� ����)
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            //playerData�� Json ���ڿ��� ��ȯ
            string json = JsonConvert.SerializeObject(data); //string json = JsonUtility.ToJson(data);
            // ���� ��� (���, ����)
            File.WriteAllText(path, json);
        }
    }

    public void Load()
    {
        readFromJson.Clear();

        string[] names = { "����", "������" };

        foreach (string name in names)
        {
            string path = $"{Application.streamingAssetsPath}/{name}_Data.json";

            // ��ȿ�� �˻�
            if (File.Exists(path))
            {
                //���Ϸκ��� json�������� ���ڿ��� ������
                string json = File.ReadAllText(path);
                //json ������ �����͸� �Ľ��Ͽ� playerData�ν��Ͻ� ���� �� �� �Ҵ�.
                PlayerData data = JsonConvert.DeserializeObject<PlayerData>(json); //readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
                readFromJson.Add(data);
            }
        }
    }

    public void AllFileLoad()
    {
        //streamingAsset ���� �ȿ� �ִ� json ������ ��� �о 
        //readFromJson ����Ʈ�� add�Ͻÿ�
        //��Ʈ
        readFromJson.Clear();

        DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);

        foreach(FileInfo file in di.GetFiles())
        {
            //if(path != )
            string path = $"{Application.streamingAssetsPath}/{file.Name}";

            if (File.Exists(path) && file.Extension == ".json")
            {
                string json = File.ReadAllText(path);
                readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
            }
        }
    }
}

// �ٸ� ���·� �����͸� ����ϱ� ���� ����ȭ ������ �ʿ��ϴ�
// �� ����ȭ�� �ϸ� ȣȯ���� �������� ���ȼ��� ��������.
[System.Serializable]
public class PlayerData //������ ȣȯ���� �ʿ��� ������ ��ü�̱� ������ ����ȭ ��
{
    public string name;
    public int level;
    public float exp;
    public int hp;
    public int attack;
    public int[] items;
    public List<SkillData> skills;
}

[System.Serializable]
public class SkillData
{
    public int id;
    public int level;
    public UpgradeType upgrade;
}

public enum UpgradeType
{
    Attack,
    Defence,
    Speed,
    HP
}

