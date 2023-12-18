using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.ComponentModel;
using AsyncOperation = UnityEngine.AsyncOperation;

public class MM : MonoBehaviour 
{    
    public PlayerData _playerData;
    public void StartGame()
    {
        if (File.Exists(Application.persistentDataPath + "/GAMEDATA.json")) 
        {
            File.Delete(Application.persistentDataPath + "/GAMEDATA.json");
        }
            SceneManager.LoadScene(1);

    }

    public void ContinueGame()       
    {

        if (File.Exists(Application.persistentDataPath + "/GAMEDATA.json"))
        {
            var dataStr = File.ReadAllText(Application.persistentDataPath + "/GAMEDATA.json");
            var data = JsonUtility.FromJson<PlayerData>(dataStr);
            SceneManager.LoadScene(data.sceneID);            

          //  if (SceneManager.GetActiveScene().buildIndex == data.sceneID)
          //  {

          //      transform.position = data.Position;
          //  }
            
        }

    }

    [Serializable]
    public class PlayerData
    {
        public int sceneID;
        public Vector3 Position;
        public string Name;

        public PlayerData()
        {
        }

        public PlayerData(int sceneID, Vector3 position, string name)
        {
            this.sceneID = sceneID;
            Position = position;
            Name = name;
        }
    }
}




