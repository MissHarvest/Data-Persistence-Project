using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField]
    string playerName;
    public string PlayerName { get { return playerName; } set { playerName = value; } }

    [SerializeField]
    string bestPlayerName;
    public string BestPlayerName { get { return bestPlayerName; } set { bestPlayerName = value; } }

    [SerializeField]
    int bestScore;
    public int BestScore { get { return bestScore; } set { bestScore = value; } }

    private void Awake()
    {
        if(null == Instance)
        {
            Instance = this;
            LoadData();
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    [System.Serializable]
    class BestRecord
    {
        public string name;
        public int score;
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestRecord data = JsonUtility.FromJson<BestRecord>(json);
            bestPlayerName = data.name;
            bestScore = data.score;
        }        
    }

    public void SavePlayerData(int score)
    {
        BestRecord data = new BestRecord();

        data.name = PlayerName;
        data.score = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
