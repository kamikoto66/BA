using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarModelManager : MonoBehaviour {

    private GameObject tergetObject;

    // Use this for initialization
    void Start () {
        SponCarModel();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeModel()
    {
        DestroyModel();
        SponCarModel();
    }


    private void SponCarModel()
    {
        string id = HomeSceneManager.instance.SelectCarID;
        tergetObject = Instantiate(Resources.Load<GameObject>(TableLocator.carTable.Find(id).ModelPath));        
    }

    private void DestroyModel()
    {
        if (tergetObject != null)
        {
            Destroy(tergetObject);
        }
    }
}
