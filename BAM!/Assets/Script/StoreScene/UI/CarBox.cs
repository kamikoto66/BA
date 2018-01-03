using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBox : BoxBase {

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        UIHelper.AddButtonListener(Vars["Buy"], Buy);
        _Type = BoxType.CarBox;
    }

    public override void Buy()
    {
        _PopUp.SetTrigger("up");
        StoreManager.instnace.selectType = _Type;
    }
}
