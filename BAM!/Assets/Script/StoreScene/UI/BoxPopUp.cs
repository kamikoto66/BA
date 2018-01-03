using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxPopUp : UI {

	// Use this for initialization
	void Start () {
        UIHelper.AddButtonListener(Vars["ok"], Buy);
        UIHelper.AddButtonListener(Vars["cancel"], () => { GetComponent<Animator>().SetTrigger("down"); });
	}
	
    public void Buy()
    {
        Debug.Log("BoxPopUp Buy");
        GetComponent<Animator>().SetTrigger("down");

        if(StoreManager.instnace.selectType == BoxBase.BoxType.CarBox)
        {
            if (TableLocator.userDataTable.Find("User").Money >= 500)
            {
                var user = TableLocator.userDataTable.Find("User");
                user.Money -= 500;

                TableLocator.userDataTable.ChangeData(user);
                GameObject.Find("GoldText").GetComponent<Text>().text = user.Money.ToString();

                int index = StoreSystem.instance.BuyCar();
                //상자 생성
                Instantiate(Resources.Load<GameObject>("Prefabs/Store/box"));
            }
        }
        else if(StoreManager.instnace.selectType == BoxBase.BoxType.FurnitureBox)
        {

        }
    }
}
