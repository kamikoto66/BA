using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreBackButton : MonoBehaviour {

    public void OnClick()
    {
        GameObject.Find("SceneChangeManager(Clone)").GetComponent<SceneChangeManager>().ChangeScene(SceneIndex.eHomeScene);
        //SceneManager.LoadSceneAsync((int)SceneIndex.eHomeScene);   
    }
}
