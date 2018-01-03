using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSceneUIControl : MonoBehaviour {

    public static HomeSceneUIControl instance;
    public bool IsInventoryOpen { get; private set; }

    public Animator MenuButton;
    public Animator FurnitureButtons;
    public Animator InfoButtons;

    public Animator CarInventory;
    public Animator FurnitureInventory;
    //public Animator ItemInfo;

    // Use this for initialization
    void Start () {

        instance = this;
        MenuButton = GameObject.Find("MenuButtons(Clone)").GetComponent<Animator>();
        FurnitureButtons = GameObject.Find("InventoryButtons(Clone)").GetComponent<Animator>();
        InfoButtons = GameObject.Find("InfoButtons(Clone)").GetComponent<Animator>();

        CarInventory = GameObject.Find("CarInventory").GetComponent<Animator>();
        FurnitureInventory = GameObject.Find("FurnitureInventory").GetComponent<Animator>();
    }
	
    //자동차 인벤토리 열기
    public void CarInventoryOpen()
    {
        CarInventory.SetTrigger("MoveLeft");
        MenuButton.SetTrigger("ButtonDown");
        IsInventoryOpen = true;
    }
    //자동차 인벤토리 닫기
    public void CarInventoryClose()
    {
        CarInventory.SetTrigger("MoveRight");
        MenuButton.SetTrigger("ButtonUp");
        IsInventoryOpen = false;
    }
    //가구 인벤토리 열기
    public void FurnitureInventoryOpen()
    {
        FurnitureInventory.SetTrigger("MoveRight");
        MenuButton.SetTrigger("ButtonDown");
        IsInventoryOpen = true;
    }
    //가구 인벤토리 닫기
    public void FurnitureInventoryClose()
    {
        FurnitureInventory.SetTrigger("MoveLeft");
        MenuButton.SetTrigger("ButtonUp");
        IsInventoryOpen = false;
    }
    //가구 놓기
    public void FurniturePutOrCancel()
    {
        MenuButton.SetTrigger("ButtonUp");
        FurnitureButtons.SetTrigger("ButtonDown");
    }

    /// <summary>
    /// 인벤토리에서 아이템 선택
    /// </summary>
    public void InventoryItemSelect()
    {
        FurnitureInventory.SetTrigger("MoveLeft");
        FurnitureButtons.SetTrigger("ButtonUp");
    }

    //화면상에 있는 가구 클릭
    public void FurnitureObjectClick()
    {
        InfoButtons.SetTrigger("ButtonUp");
        MenuButton.SetTrigger("ButtonDown");
    }

    /// <summary>
    ///화면상에 있는 가구 인벤토리로
    /// </summary>
    public void FurnitureReturn()
    {
        InfoButtons.SetTrigger("ButtonDown");
        MenuButton.SetTrigger("ButtonUp");
    }

    /// <summary>
    /// 화면상에 나와있는 모델선택후 움지이도록 하는 버튼 누를때 
    /// </summary>
    public void FurnitureMove()
    {
        FurnitureButtons.SetTrigger("ButtonUp");
        InfoButtons.SetTrigger("ButtonDown");
    }

    public void FurntireSelect()
    {
        FurnitureButtons.SetTrigger("ButtonUp");
        FurnitureInventory.SetTrigger("MoveLeft");
        IsInventoryOpen = false;
    }

    public void ItemInfoControl(bool isopen)
    {
        //if(isopen)
        //{
        //    ItemInfo.SetTrigger("Open");
        //    InfoButtons.SetTrigger("ButtonDown");
        //}
        //else if(!isopen)
        //{
        //    ItemInfo.SetTrigger("Close");
        //    InfoButtons.SetTrigger("ButtonUp");
        //}
    }
}
