using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureImage : MonoBehaviour {

    private FurnitureTableDescriptor data;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void SetInfo(FurnitureTableDescriptor _data)
    {
        data = _data;
    }

    public FurnitureTableDescriptor GetInfo()
    {
        return data;
    }

    public void OnClick()
    {
        SoundManager.Instance.PlaySound(0);
        HomeSceneManager.instance.ChangeSelectFurnitureID(data.Id);
    }
}
