using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentDesk : FurnitureObject
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void SetUpFurniture(FurnitureTableDescriptor data, int index)
    {
        base.SetUpFurniture(data, index);

        Init();
    }

    public override void Init()
    {
        xPosEnd = new Vector2(-20.5f, 14.1f);
        zPosEnd = new Vector2(-18.2f, 16.2f);
        modelTransform = GetComponent<Transform>();

        if (isRotation)
        {
            modelTransform.Rotate(new Vector3(0.0f, 0.0f, -90.0f));
        }
    }

    public override FurnitureTableDescriptor Rotation()
    {
        isRotation = !isRotation;

        if (isRotation)
        {
            modelTransform.Rotate(new Vector3(0.0f, 0.0f, -90.0f));
        }
        else if (!isRotation)
        {
            modelTransform.Rotate(new Vector3(0.0f,0.0f , 90.0f));
        }

        return itemInfo;
    }
}
