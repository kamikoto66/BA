using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButtons : UI {

    public Animator animator;

	// Use this for initialization
	void Start () {
        UIHelper.AddButtonListener(Vars["Put"], OnPutButton);
        UIHelper.AddButtonListener(Vars["Rotate"], Rotate);
        UIHelper.AddButtonListener(Vars["Cancel"], Cancel);
    }

    //public void ButtonsUp()
    //{
    //    SoundManager.Instance.PlaySound(0);

    //    HomeSceneUIControl.instance.InventoryItemSelect();
    //}

    public void Cancel()
    {
        SoundManager.Instance.PlaySound(0);

        HomeSceneUIControl.instance.FurniturePutOrCancel();
        HomeSceneManager.instance.DestroyFurnitureModel();
    }

    public void OnPutButton()
    {
        SoundManager.Instance.PlaySound(0);

        //설치했으니 데이터에 저장해줘야함
        if (HomeSceneManager.instance.PutFurnitureModel())
        {
            HomeSceneUIControl.instance.FurniturePutOrCancel();
        }
    }

    public void Rotate()
    {
        SoundManager.Instance.PlaySound(0);

        HomeSceneManager.instance.ModelRotate();
    }
}
