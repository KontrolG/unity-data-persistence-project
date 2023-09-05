using System;
using System.IO;
using UnityEngine;

[Serializable]
public class HighScore
{
    public string playerName;
    public int score;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public HighScore previousHighScore;
    public string playerName;
    public string path;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

        path = $"{Application.persistentDataPath}/score.json";

        DontDestroyOnLoad(gameObject);
    }

    public void SaveHighScore(string playerName, int score)
    {
        HighScore highScore = new HighScore
        {
            playerName = playerName,
            score = score
        };

        File.WriteAllText(path, JsonUtility.ToJson(highScore));
    }

    public void LoadPreviousHighScore()
    {
        if (!File.Exists(path)) return;
        string json = File.ReadAllText(path);
        previousHighScore = JsonUtility.FromJson<HighScore>(json);
    }
}
