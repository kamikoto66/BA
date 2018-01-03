using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUoOverlap : UI {

	// Use this for initialization
	void Start () {
        UIHelper.AddButtonListener(Vars["ok"], () => { GetComponent<Animator>().SetTrigger("down"); });
	}
	
}
