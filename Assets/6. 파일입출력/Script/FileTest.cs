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

        //이딴식으로 하면 혼남 (메모리 낭비)
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

            //텍스트 파일을 출력할 경오 (파일명, 확장자 포함)
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            //playerData를 Json 문자열로 변환
            string json = JsonConvert.SerializeObject(data); //string json = JsonUtility.ToJson(data);
            // 파일 출력 (경로, 내용)
            File.WriteAllText(path, json);
        }
    }

    public void Load()
    {
        readFromJson.Clear();

        string[] names = { "전사", "마법사" };

        foreach (string name in names)
        {
            string path = $"{Application.streamingAssetsPath}/{name}_Data.json";

            // 유효성 검사
            if (File.Exists(path))
            {
                //파일로부터 json포맷으로 문자열을 가져옴
                string json = File.ReadAllText(path);
                //json 포맷의 데이터를 파싱하여 playerData인스턴스 생성 후 값 할당.
                PlayerData data = JsonConvert.DeserializeObject<PlayerData>(json); //readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
                readFromJson.Add(data);
            }
        }
    }

    public void AllFileLoad()
    {
        //streamingAsset 폴더 안에 있는 json 파일을 모두 읽어서 
        //readFromJson 리스트에 add하시오
        //힌트
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

// 다른 형태로 데이터를 취급하기 위해 직렬화 과정이 필요하다
// ㄴ 직렬화를 하면 호환성은 좋아지고 보안성은 떨어진다.
[System.Serializable]
public class PlayerData //데이터 호환성이 필요한 데이터 객체이기 때문에 직렬화 함
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

