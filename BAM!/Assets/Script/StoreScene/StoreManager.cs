using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour {
    public static StoreManager instnace;
    public int coin { get; set; }

   
    public Text CoinText;

    public BoxBase.BoxType selectType { get; set; }

    // Use this for initialization
    void Start() {
        Init();
    }

    // Update is called once per frame
    void Update() {

    }

    private void Init()
    {
        instnace = this;

        coin = TableLocator.userDataTable.Find("User").Money;

        CoinText.text = coin.ToString();

        Instantiate(Resources.Load<GameObject>("Prefabs/SceneChangeManager"));
    }


    public void BoxSelect(BoxBase.BoxType type)
    {
        if(type != selectType)
        {
            selectType = type;
        }
    }

    public void CheckCarHave(int id)
    {
        if (!TableLocator.userDataTable.Find("User").CarDatas[id].Have)
        {
            var user = TableLocator.userDataTable.Find("User");
            user.CarDatas[id].Have = true;
            TableLocator.userDataTable.ChangeData(user);
        }
        else
        {
            var user = TableLocator.userDataTable.Find("User");
            user.Money += 250;
            TableLocator.userDataTable.ChangeData(user);
        }
    }
}
