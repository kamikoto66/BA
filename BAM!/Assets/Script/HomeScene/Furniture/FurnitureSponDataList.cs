using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//화면상에 올려놓은 가구들의 데이터
[Serializable]
public class FurnitureSponData
{
    public Vector3 sponPos;
    public string DataId;

    public FurnitureSponData() { }
    public FurnitureSponData(Vector3 p, string id) { sponPos = p; DataId = id; }
    public override string ToString()
    {
         return sponPos.ToString() + ";"  + DataId;    
    }
}

public class FurnitureSponDataList : MonoBehaviour
{
    public Dictionary<string, FurnitureSponData> furnitureList = new Dictionary<string, FurnitureSponData>();

    private void Start()
    {
        //furnitureList.Clear();
        //SavaFurnitureData();
        //LoadFurnitureData();
    }

    public void Init()
    {
        LoadFurnitureData();
    }

    //추가
    public void AddFurnitureData(Vector3 sponPos, string id)
    {     
        FurnitureSponData data = new FurnitureSponData(sponPos, id);

        furnitureList[data.DataId] = data;

        SavaFurnitureData();
    }

    public void DeleteFurnitureData(string id)
    {
        if(furnitureList.ContainsKey(id))
        {
            furnitureList.Remove(id);
            SavaFurnitureData();
        }
    }

    //가구 데이터 로드
    void LoadFurnitureData()
    {
        string data = PlayerPrefs.GetString("FurnitureSponData");
        string[] DataUseString;

        if(!string.IsNullOrEmpty(data))
        {
            DataUseString = data.Split(':');

            foreach (var s in DataUseString)
            {
                if (s.CompareTo("") != 0)
                {
                    SaveFurniturList(s);
                }
            }
        }
    }

    //PlayerPrefs에 저장
    void SavaFurnitureData()
    {
        string SaveString = "";

        var e = furnitureList.GetEnumerator();
        while(e.MoveNext())
        {
            var data = e.Current.Value;
            SaveString += data.ToString();
            SaveString += ":";
        }

        PlayerPrefs.SetString("FurnitureSponData", SaveString);
    }

    void SaveFurniturList(string s)
    {
        FurnitureSponData temp = new FurnitureSponData();

        string[] DataArray = s.Split(';');

        temp.sponPos = ConvertVector(DataArray[0]);
        temp.DataId = DataArray[1];
        furnitureList[temp.DataId] = temp;
    }

    string Replace(string s)
    {
        s = s.Replace("(", "");
        s = s.Replace(")", "");
        return s;
    }

    Vector3 ConvertVector(string s)
    {
        string[] data = s.Split(',');

        data[0] = Replace(data[0]);
        data[1] = Replace(data[1]);
        data[2] = Replace(data[2]);

        Vector3 v = new Vector3();
        v.x = float.Parse(data[0]);
        v.y = float.Parse(data[1]);
        v.z = float.Parse(data[2]);

        return v;
    }
}
