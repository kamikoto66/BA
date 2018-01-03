using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyText : UI {

    private Text trophyText;

	// Use this for initialization
	void Start () {
		if(trophyText == null){
            trophyText = transform.GetComponentInChildren<Text>();
        }
	}
	
    public void SetTrophy(int trophy)
    {
        if(trophyText == null){
            trophyText = transform.GetComponentInChildren<Text>();
        }
        trophyText.text = trophy.ToString();
    }
}
