using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public enum ModelState
{
    eNone,
    eInventory,
    eSponModel
}

public class HomeSceneManager : MonoBehaviour
{

    public static HomeSceneManager instance;

    //설치된 오브젝트 눌렀을때
    public bool modelSelect { get; set; }
    public ModelState modelState { get; set; }

    public string SelectCarID;
    public string selectFurnitureID = "";
    public string selectMapData = "";

    public FurnitureModelManager furnitureModelManager { get; private set; }
    public GameObject invenToryManager { get; private set; }

    private int money = 0;
    private int trophy = 0;

    private void Awake()
    {
        Init();
        GenerateUI();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Init()
    {
        instance = this;

        var obj = Instantiate(Resources.Load<GameObject>("Prefabs/SceneChangeManager"));

        SelectCarID = TableLocator.userDataTable.Find("User").SelectCar;
        modelSelect = false;
        modelState = ModelState.eNone;
        trophy = TableLocator.userDataTable.Find("User").Trophy;
        money = TableLocator.userDataTable.Find("User").Money;

        invenToryManager = GameObject.Find("CarInvenManager");
        furnitureModelManager = GameObject.Find("FurnitureModelManager").GetComponent<FurnitureModelManager>();
    }

    private void GenerateUI()
    {
        UIManager.OpenUI<MenuButtons>("Prefabs/HomeScene/UI/MenuButtons");
        UIManager.OpenUI<Gold>("Prefabs/HomeScene/UI/Gold").SetGold(money);
        UIManager.OpenUI<TrophyText>("Prefabs/HomeScene/UI/Trophy").SetTrophy(trophy);
        UIManager.OpenUI<OptionButton>("Prefabs/HomeScene/UI/Option");
        UIManager.OpenUI<RankingButton>("Prefabs/HomeScene/UI/Ranking");
        UIManager.OpenUI<InfoButtons>("Prefabs/HomeScene/UI/InfoButtons");
        UIManager.OpenUI<InventoryButtons>("Prefabs/HomeScene/UI/InventoryButtons");
    }

    //자동차 인벤토리에서 선택한 정보 전환
    public void ChangeSelectCarID(string id)
    {
        if (id != SelectCarID)
        {
            SelectCarID = id;
        }
    }

    //자동차 모델 변경
    public bool ChangeCarModel()
    {
        if (SelectCarID != TableLocator.userDataTable.Find("User").SelectCar)
        {
            var user = TableLocator.userDataTable.Find("User");
            user.SelectCar = SelectCarID;
            TableLocator.userDataTable.ChangeData(user);
            //자동차 모델 변경
            invenToryManager.GetComponent<CarModelManager>().ChangeModel();
            return true;
        }
        return false;
    }

    //가구 인벤토리에서 아이디 변경
    public void ChangeSelectFurnitureID(string id)
    {
        if (id != selectFurnitureID)
        {
            selectFurnitureID = id;
        }
    }

    //인벤토리에서 선택한 가구 생성
    public bool SetUpFurnitureModel()
    {
        if (selectFurnitureID != "")
        {
            FurnitureTableDescriptor info = TableLocator.furnitureTable.Find(selectFurnitureID);
            furnitureModelManager.GetComponent<FurnitureModelManager>().SelectModel(info);
            modelSelect = true;
            modelState = ModelState.eInventory;

            return true;
        }

        return false;
    }

    //가구 지워줌
    public void DestroyFurnitureModel()
    {
        if (modelSelect && modelState.Equals(ModelState.eInventory))
        {
            //화면에서 지우기
            furnitureModelManager.GetComponent<FurnitureModelManager>().DestroyInvenModel();
            modelSelect = false;
            modelState = ModelState.eNone;
        }
        else if (modelSelect && modelState.Equals(ModelState.eSponModel))
        {
            //기존 위치로 돌려놓기
            furnitureModelManager.GetComponent<FurnitureModelManager>().DestroySelectModel();
            modelSelect = false;
            modelState = ModelState.eNone;
        }
    }

    //가구를 설치 정보를 데이터에 저장
    public bool PutFurnitureModel()
    {
        if (modelSelect && modelState.Equals(ModelState.eInventory))
        {
            if (!furnitureModelManager.GetComponent<FurnitureModelManager>().GetSelectModelEnter())
            {
                var user = TableLocator.userDataTable.Find("User");
                var index = int.Parse(Regex.Replace(selectFurnitureID, @"\D", "")) - 1;

                user.FurnitureData[index].Use = true;

                furnitureModelManager.GetComponent<FurnitureModelManager>().PutModelToData(TableLocator.furnitureTable.Find(selectFurnitureID));
                TableLocator.userDataTable.ChangeData(user);
                GameObject.Find("FurnitureInventory").GetComponent<FurnitureInventory>().PopItem(selectFurnitureID);
                //선택하지 않음 으로 전환
                modelSelect = false;
                modelState = ModelState.eNone;

                return true;
            }
        }
        else if (modelSelect && modelState.Equals(ModelState.eSponModel))
        {
            if (!furnitureModelManager.GetComponent<FurnitureModelManager>().GetSelectModelEnter())
            {
                furnitureModelManager.GetComponent<FurnitureModelManager>().PutModelToData();

                modelSelect = false;
                modelState = ModelState.eNone;

                return true;
            }
        }

        return false;
    }

    //화면상에있는 모델 선택
    public void ModelSelect(string s, string id)
    {
        furnitureModelManager.GetComponent<FurnitureModelManager>().SelectModel(s);
        selectFurnitureID = id;
        modelState = ModelState.eSponModel;
    }

    //인벤토리로 다시 넣어준다
    public void ModelReturnInventory()
    {
        furnitureModelManager.GetComponent<FurnitureModelManager>().ReturnModelInventory();
        GameObject.Find("FurnitureInventory").GetComponent<FurnitureInventory>().ResponItem();
        modelSelect = false;
        modelState = ModelState.eNone;
    }

    //모델 회전
    public void ModelRotate()
    {
        furnitureModelManager.GetComponent<FurnitureModelManager>().ModelRotate();
    }

    public void ChangeStageID(MapDataDescriptor data)
    {
        if (selectMapData != data.Id)
        {
            selectMapData = data.Id;
        }
    }

    public void ModelSelectExit()
    {
        modelSelect = false;
        modelState = ModelState.eNone;
    }
}