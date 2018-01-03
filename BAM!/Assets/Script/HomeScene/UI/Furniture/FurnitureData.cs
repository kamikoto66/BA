using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FurnitureData : MonoBehaviour
{
    private string strPath = "Assets/Resources/";
    private Dictionary<int, FurnitureInfo> ItemData = new Dictionary<int, FurnitureInfo>();
    private FileStream f;

    private void Awake()
    {
        Debug.Log("FurnitureData");
        //LoadItemData();
        //StartCoroutine(LoadItemData());
    }

    //인벤토리에 아이템을 추가하고 데이터에 추가
    public FurnitureInfo ItemGenerate(int Code, bool HaveItem, int MaxDur, int CurDur, string Name, bool Use, bool Rotate, string Description)
    {
        FurnitureInfo info = new FurnitureInfo(Code, HaveItem, MaxDur, CurDur, Name, Use, Rotate, Description);
        return info;
    }

    //PlayerPrefs에서 불러온다
    private IEnumerator LoadItemData()
    {
        TextAsset textAsset = Resources.Load("FurnitureDatacsv") as TextAsset;
        yield return textAsset;

        StringReader StringReader = new StringReader(textAsset.text);
        
        string s = StringReader.ReadLine();
        string[] value;

        while(s != null)
        {
            value = s.Split(',');

            ItemData[int.Parse(value[0])] = ItemGenerate(int.Parse(value[0]), bool.Parse(value[1]), int.Parse(value[2]), int.Parse(value[3]),
                value[4], bool.Parse(value[5]), bool.Parse(value[6]), value[7]);

            s = StringReader.ReadLine();
        }

        //GameObject.Find("FurnitureInventory").GetComponent<FurnitureInventory>().SetUpInventory(ItemData);
        //GameObject.Find("FurnitureModelManager").GetComponent<FurnitureModelManager>().SetUpModels();
    }

    //PlayerPrefs에 저장
    private void SaveItemData()
    {
        try
        {
            if(Application.platform == RuntimePlatform.Android)
                f = File.OpenWrite(Application.persistentDataPath + "/FurnitureDatacsv.csv");
            else if(Application.platform == RuntimePlatform.WindowsEditor)
                f = File.OpenWrite(strPath + "FurnitureDatacsv.csv");

            StreamWriter writer = new StreamWriter(f, System.Text.Encoding.Unicode);

            var e = ItemData.GetEnumerator();

            while (e.MoveNext())
            {
                FurnitureInfo info = e.Current.Value;
                string value = info.ToString();
                writer.WriteLine(value);
            }

            writer.Close();
        }
        catch (NullReferenceException e)
        {

        }
    }

    public Dictionary<int, FurnitureInfo> GetList()
    {
        return ItemData;
    }

    public FurnitureInfo GetItem(int id)
    {
        if (ItemData.ContainsKey(id))
        {
            return ItemData[id];
        }

        return null;
    }

    public void SetItem(int id, FurnitureInfo d)
    {
        if (ItemData.ContainsKey(id))
        {
            ItemData[id] = d;
            SaveItemData();
        }
    }
}

//소지하고있는 아이템들
[Serializable]
public class FurnitureInfo
{
    public int ItemCode { get; set; }
    public bool HaveItem { get; set; }
    public int MaxDur { get; set; }
    public int CurDur { get; set; }
    public string ItemName { get; set; }
    public bool IsItemUse { get; set; }
    public bool IsRotate { get; set; }
    public string Description { get; set; }

    public FurnitureInfo() { }
    public FurnitureInfo(int Code, bool HaveItem, int MaxDur, int CurDur, string Name, bool Use, bool Rotate, string Description)
    {
        this.ItemCode = Code;
        this.HaveItem = HaveItem;
        this.MaxDur = MaxDur;
        this.CurDur = CurDur;
        this.ItemName = Name;
        this.IsItemUse = Use;
        this.IsRotate = Rotate;
        this.Description = Description;
    }

    public override string ToString()
    {
        string s;
        s = ItemCode.ToString() + "," + HaveItem.ToString() + "," + MaxDur.ToString() + "," + CurDur + "," + ItemName + "," 
            + IsItemUse.ToString() + "," + IsRotate.ToString() + "," + Description;
        return s;
    }
}
