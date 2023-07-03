using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public static string PLAYERNAME = "";
    public static string PLAYERNAMEHIGH = "";
    public static string FILEPATH = "/savefile.sav";
    public static int HIGHESTSCORE = 0;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
        LoadFile();
    }

    [System.Serializable]
    class SaveSytem
    {
        public string name;
        public int highScore;
    }

    public void SaveFile()
    {
        SaveSytem data = new SaveSytem();
        data.name = PLAYERNAMEHIGH;
        data.highScore = HIGHESTSCORE;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + FILEPATH, json);
    }

    public void LoadFile()
    {
        string path = Application.persistentDataPath + FILEPATH;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveSytem data = JsonUtility.FromJson<SaveSytem>(json);

            PLAYERNAMEHIGH = data.name;
            HIGHESTSCORE = data.highScore;
        }
    }
}
