using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public int currentChar;
    public int CoinCount;
    public static SaveManager instance { get; private set; }
    public bool[] charsUnlocked = new bool[5] { true, false, false, false, false };

   

    // Start is called before the first frame update
    void Awake()
    {
        CoinCount = PlayerPrefs.GetInt("coins");
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Load();
        }
    }

    public void Load()
    {
        string filePath = Application.persistentDataPath + "/playerinfo.dat";
        if (File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            currentChar = data.currentChar;
            CoinCount = data.CoinCount;
            charsUnlocked = data.charsUnlocked;

            if(data.charsUnlocked == null)
                charsUnlocked = new bool[5] { true, false, false, false, false };

            file.Close();
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("coins", CoinCount);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();

        data.currentChar = currentChar;
        data.CoinCount = CoinCount;
        data.charsUnlocked = charsUnlocked;
        bf.Serialize(file, data);
        file.Close();
    }

    // Update is called once per frame
    void Update()
    {
        CoinCount = PlayerPrefs.GetInt("coins");
    }

    [Serializable]
    public class PlayerData_Storage
    {
        public int currentChar;
        public int CoinCount;
        public bool[] charsUnlocked;
    }
}
