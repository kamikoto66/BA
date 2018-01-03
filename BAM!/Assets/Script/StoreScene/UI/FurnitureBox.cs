using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureBox : BoxBase {


    private void Start()
    {
        Init();
    }

    public override void Buy()
    {

    }

    public override void Init() 
    {
        UIHelper.AddButtonListener(Vars["Buy"], Buy);
        _Type = BoxType.FurnitureBox;
    }
}
