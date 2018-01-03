using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarImage : MonoBehaviour {
    
    private CarDescriptor item;

    // Use this for initialization

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetInfo(CarDescriptor itemInfo)
    {
        item = itemInfo;
    }

    public void OnClick()
    {
        SoundManager.Instance.PlaySound(0);

        HomeSceneManager.instance.ChangeSelectCarID(item.Id);
    }
}
