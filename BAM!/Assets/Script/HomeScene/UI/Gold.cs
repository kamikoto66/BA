using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : UI {

    Text goldText;

    public void SetGold(int gold)
    {
        if(goldText == null){
            goldText = transform.GetComponentInChildren<Text>();
        }
        goldText.text = gold.ToString();
    }   
}
