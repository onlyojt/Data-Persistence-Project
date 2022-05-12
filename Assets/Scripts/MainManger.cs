using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManger : MonoBehaviour
{
    public static MainManger instance;
    public string userName;
    public string bestUser;
    public int bestScore = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class SaveData
    {
        public string bestUser;
        public int bestScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.bestUser = this.bestUser;
        data.bestScore = this.bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/SaveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            this.bestUser = data.bestUser;
            this.bestScore = data.bestScore;
        }
    }
}
