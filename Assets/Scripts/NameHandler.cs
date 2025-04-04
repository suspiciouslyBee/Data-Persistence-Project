using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class NameHandler : MonoBehaviour
{
    //Just handles scores

    public static NameHandler Instance;
    public string Name;
    public int Score;

    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int Score;
    }

    //Set the name and score, then move to the next scene
    void InitName(string newName)
    {
        Name = newName;
        Score = 0;
        SceneManager.LoadScene(1);
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    //Save and load methods
    
    
    //Only Call when the score is greater
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.Name = Name;
        data.Score = Score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Name = data.Name;
            Score = data.Score;
        }
    }

}
