using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class CollectiblesController : MonoBehaviour
{

    public CollectiblesData[] cd;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        //prevent multiple instances of the same object
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.persistentDataPath + "/gameData.dat");
        bf.Serialize(fs, cd);
        fs.Close();
        Debug.Log("Data saved.");
    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/gameData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);
            cd = (CollectiblesData[])bf.Deserialize(fs);
            fs.Close();
            Debug.Log("Data loaded.");
        }
        else
        {
            Debug.LogError("File you are trying to load from is missing");
        }
    }

    public void IncrementCount(GameObject go)
    {
        if (go.name.Contains("Heart"))
        {
            cd[0].collectibleNum++;
        }
        else if (go.name.Contains("SoftStar"))
        {
            cd[1].collectibleNum++;
        }
        else if (go.name.Contains("5 Side Diamond"))
        {
            cd[2].collectibleNum++;
        }
    }

    void OutputCounts()
    {
        Debug.Log("You've collected:");
        Debug.Log("Hearts = " + cd[0].collectibleNum);
        Debug.Log("Stars = " + cd[1].collectibleNum);
        Debug.Log("Diamonds = " + cd[2].collectibleNum);
    }

    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            Debug.Log("Loading data...");
            LoadData();
        }
        else if (Input.GetKeyDown("s"))
        {
            Debug.Log("Saving data...");
            SaveData();
        }
    }
}
