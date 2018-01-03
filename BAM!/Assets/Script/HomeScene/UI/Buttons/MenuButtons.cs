using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : UI {

	// Use this for initialization
	void Start () {

        UIHelper.AddButtonListener(Vars["GameShop"], () => {
            SoundManager.Instance.PlaySound(0);

            GameObject.Find("SceneChangeManager(Clone)").GetComponent<SceneChangeManager>().ChangeScene(SceneIndex.eStoreScene);
        });

        UIHelper.AddButtonListener(Vars["GamePlay"], () => {
            SoundManager.Instance.PlaySound(0);

            UIManager.OpenUI<StageSelect>("Prefabs/HomeScene/UI/StageSelect", UIManager.UIType.ClosingModal);
        });

        UIHelper.AddButtonListener(Vars["RendMenu"], () => {
            SoundManager.Instance.PlaySound(0);

            GameObject.Find("SceneChangeManager(Clone)").GetComponent<SceneChangeManager>().ChangeScene(SceneIndex.eRendScene);
        });
    }
}
