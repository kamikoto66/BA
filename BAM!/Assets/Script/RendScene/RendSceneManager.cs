using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var obj = Instantiate(Resources.Load<GameObject>("Prefabs/SceneChangeManager"));
        //obj.GetComponent<SceneChangeManager>().FadeInInit();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
