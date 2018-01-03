using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public enum FurnitureIndex
{
    eStudentDesk,
    eStudentChair
}


public class FurnitureModelManager : MonoBehaviour {
       
    private FurnitureData data;
    private Transform boardHolder;
    private Vector3 oldPos;
    private GameObject tergetObj;
    private FurnitureSponDataList dataManager;

	// Use this for initialization
	void Start () {
        dataManager = GetComponent<FurnitureSponDataList>();
        SetUpModels();
    }

    // Update is called once per frame
    void Update () {
    }

    public void SetUpModels()
    {
        boardHolder = new GameObject("Borad").transform;

        dataManager.Init();
        var enumerator = dataManager.furnitureList.GetEnumerator();  // var형 - 모든 타입을 지향

        while (enumerator.MoveNext())  // .MoveNext() - 다음 키로 넘어감 true/false로 리턴
        {
            var pair = enumerator.Current;  // .Current - 지정한 키와 값을 꺼내기
            FurnitureSponData item = pair.Value;  // .Value - pair의 값을 item 변수에 대입
            Debug.Log (item.DataId);
            FurnitureTableDescriptor info = TableLocator.furnitureTable.Find(item.DataId);
            GameObject obj = SponModel(info);
            obj.transform.position = item.sponPos;
        }
    }

    private GameObject SponModel(FurnitureTableDescriptor data)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>(data.Path));
        var id = int.Parse(Regex.Replace(data.Id, @"\D", ""))-1;

        switch ((FurnitureIndex)id)
        {
            case FurnitureIndex.eStudentDesk: obj.GetComponent<StudentDesk>().SetUpFurniture(data, id); break;
            case FurnitureIndex.eStudentChair: obj.GetComponent<StudentChair>().SetUpFurniture(data, id); break;
        }

        obj.tag = "Furniture";
        obj.transform.SetParent(boardHolder);

        return obj;
    }

    //인벤토리에서 염
    public void SelectModel(FurnitureTableDescriptor data)
    {
        if(HomeSceneManager.instance.modelSelect.Equals(false) && tergetObj == null)
        {
            tergetObj = SponModel(data);
            tergetObj.GetComponent<FurnitureObject>().ModelSelect();
        }
    }

    public void SelectModel(string s)
    {
        if (HomeSceneManager.instance.modelSelect.Equals(false))
        {
            if(tergetObj == null)
            {
                tergetObj = GameObject.Find(s);
                tergetObj.GetComponent<FurnitureObject>().ModelSelect();
                oldPos = tergetObj.transform.position;
            }
        }
    }

    //설치를 취소
    public void DestroyInvenModel()
    {
        if (tergetObj != null)
        {
            Destroy(tergetObj);
        }     
    }

    public void DestroySelectModel()
    {
        if(tergetObj != null)
        {
            tergetObj.transform.position = oldPos;
            tergetObj.GetComponent<FurnitureObject>().ModelUnSelect();
            tergetObj = null;
        }
    }

    //인벤토리에서
    public void PutModelToData(FurnitureTableDescriptor data)
    {
        var index = int.Parse(Regex.Replace(data.Id, @"\D", ""))-1;
        var t = TableLocator.userDataTable.Find("User");

        //여기는 모델을 놓고 데이터에 저장하는 부분
        dataManager.AddFurnitureData(tergetObj.transform.position, data.Id);

        HomeSceneManager.instance.modelSelect = false;
        tergetObj.GetComponent<FurnitureObject>().ModelUnSelect();
        tergetObj = null;
    }

    //사무실에 있는 모델에서
    public void PutModelToData()
    {
        if(tergetObj != null)
        {
            FurnitureTableDescriptor d = tergetObj.GetComponent<FurnitureObject>().itemInfo;
            var index = int.Parse(Regex.Replace(d.Id, @"\D", "")) - 1;
            var t = TableLocator.userDataTable.Find("User");

            dataManager.AddFurnitureData(tergetObj.transform.position, d.Id);

            tergetObj.GetComponent<FurnitureObject>().ModelUnSelect();
            tergetObj = null;
        }
    }

    //인벤토리로 다시 돌림
    public void ReturnModelInventory()
    {
        if(tergetObj != null)
        {
            FurnitureTableDescriptor d = tergetObj.GetComponent<FurnitureObject>().itemInfo;
            var userdata = TableLocator.userDataTable.Find("User");
            var index = int.Parse(Regex.Replace(d.Id, @"\D", "")) - 1;

            userdata.FurnitureData[index].Rotate = false;
            userdata.FurnitureData[index].Use = false;
            TableLocator.userDataTable.ChangeData(userdata);

            dataManager.DeleteFurnitureData(d.Id);
            Destroy(tergetObj);
            tergetObj = null;
        }
    }

    //회전    
    public void ModelRotate()
    {
        if(tergetObj != null)
        {
            FurnitureTableDescriptor d = tergetObj.GetComponent<FurnitureObject>().Rotation();

            var index = int.Parse(Regex.Replace(d.Id, @"\D", ""))-1;
            var furnitureData = TableLocator.userDataTable.Find("User");

            dataManager.AddFurnitureData(tergetObj.transform.position, d.Id);

            furnitureData.FurnitureData[index].Rotate = !furnitureData.FurnitureData[index].Rotate;

            TableLocator.userDataTable.ChangeData(furnitureData);
        }
    }

    public bool GetSelectModelEnter()
    {
        return tergetObj.GetComponent<FurnitureObject>().IsObjectEnter;
    }
}
