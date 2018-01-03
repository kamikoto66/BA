using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BoradManager : MonoBehaviour {
    
    //싱글턴
    public static BoradManager instance;
    //Unity 변수

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        Debug.Log(TableLocator.userDataTable.Find("User").FurnitureData[0].Name);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
 