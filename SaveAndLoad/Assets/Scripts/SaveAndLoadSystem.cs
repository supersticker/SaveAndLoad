using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SaveAndLoadSystem : MonoBehaviour
{
    [System.Serializable]
    public class SaveData
    {
        public int coins;
        public Vector3 playerPosition;
    }

    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }


    public void SaveGame()
    {
        SaveData data = new SaveData();

        data.coins = GameManager.instance.score;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        data.playerPosition = player.transform.position;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(Application.persistentDataPath + "/save.json", json);

        Debug.Log(json);
    }


    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/save.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            GameManager.instance.score = data.coins;

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            player.transform.position = data.playerPosition;


            GameManager.UpdateUi();
            Debug.Log("Game Loaded");
        } else
        {
            Debug.Log("No save file found");
        }
    }
}
