using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarDataParse : MonoBehaviour
{
    public Dictionary<int, CarInfo> carData = new Dictionary<int, CarInfo>();

    private string strPath = "Assets/Resources/";
    private FileStream f;

    private void Awake()
    {
        //StartCoroutine(LoadData());

    }

    private IEnumerator LoadData()
    {
        TextAsset textAsset = Resources.Load("CarDatacsv") as TextAsset;
        yield return textAsset;

        StringReader StringReader = new StringReader(textAsset.text);

        string s = StringReader.ReadLine();
        string[] value;

        while (s != null)
        {
            value = s.Split(',');

            carData[int.Parse(value[0])] = new CarInfo(int.Parse(value[0]), bool.Parse(value[1]), int.Parse(value[2]), int.Parse(value[3]), value[4]);

            s = StringReader.ReadLine();
        }

        //if (SceneManager.GetActiveScene().buildIndex == 0)
        //    GameObject.Find("CarInventory").GetComponent<CarInventory>().SetUpInvenTory(carData);
        //else if (SceneManager.GetActiveScene().buildIndex == 1)
        //    GameObject.Find("CarItemManager(Clone)").GetComponent<StoreCarItemManager>().SetUpItemList();
    }

    private void SaveData()
    {
        try
        {
            if (Application.platform == RuntimePlatform.Android)
                f = File.OpenWrite(Application.persistentDataPath + "/CarDatacsv.csv");
            else if (Application.platform == RuntimePlatform.WindowsEditor)
                f = File.OpenWrite(strPath + "CarDatacsv.csv");

            StreamWriter writer = new StreamWriter(f, System.Text.Encoding.Unicode);

            var e = carData.GetEnumerator();

            while (e.MoveNext())
            {
                CarInfo info = e.Current.Value;
                string value = info.ToString();
                writer.WriteLine(value);
            }

            writer.Close();
        }
        catch (NullReferenceException e)
        {

        }
    }

    public Dictionary<int, CarInfo> GetList()
    {
        return carData;
    }

    public CarInfo GetItem(int id)
    {
        if (carData.ContainsKey(id))
        {
            return carData[id];
        }

        return null;
    }

    public void SetItem(int id, CarInfo d)
    {
        if (carData.ContainsKey(id))
        {
            carData[id] = d;
            SaveData();
        }
    }

    public void ChangeCarHave(int id)
    {
        CarInfo info = carData[id];

        if(!info.have)
        {
            info.have = true;
            carData[id] = info;
            SaveData();
        }
    }

    public bool IsCarHave(int id)
    {
        if (carData.ContainsKey(id))
        {
            return carData[id].have;
        }

        return false;
    }
}
