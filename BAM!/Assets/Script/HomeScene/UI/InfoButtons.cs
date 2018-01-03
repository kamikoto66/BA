using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButtons : UI {

	// Use this for initialization
	void Start () {
        UIHelper.AddButtonListener(Vars["Move"], FurnitureMove);
        UIHelper.AddButtonListener(Vars["Info"], InfoButton);
        UIHelper.AddButtonListener(Vars["Return"], ReturnButton);
    }

    public void FurnitureMove()
    {
        SoundManager.Instance.PlaySound(0);

        HomeSceneUIControl.instance.FurnitureMove();
        HomeSceneManager.instance.modelSelect = true;
        Destroy(GameObject.Find("EmptyBackgroundButton(Clone)"));
    }

    public void InfoButton()
    {
        SoundManager.Instance.PlaySound(0);

        HomeSceneUIControl.instance.ItemInfoControl(true);
        UIManager.OpenUI<ItemInfo>("Prefabs/HomeScene/UI/ItemInfo", UIManager.UIType.ClosingModal);
        GameObject.Find("EmptyBackgroundButton(Clone)").GetComponent<Button>().interactable = false;
    }

    public void ReturnButton()
    {
        SoundManager.Instance.PlaySound(0);

        HomeSceneUIControl.instance.FurnitureReturn();
        HomeSceneManager.instance.ModelReturnInventory();
        Destroy(GameObject.Find("EmptyBackgroundButton(Clone)"));
    }
}
