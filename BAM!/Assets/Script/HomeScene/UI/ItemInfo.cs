using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : UI {


    [HideInInspector]
    Coroutine esc;


    // Use this for initialization
    void Start () {
        //UIHelper.AddButtonListener(Vars["exit"], ExitItemInfo);
        Init();
    }

    public void Init()
    {
        esc = StartCoroutine(Escape());

        Vars["Name"].GetComponent<Text>().text = TableLocator.furnitureTable.Find(HomeSceneManager.instance.selectFurnitureID).Name;
        Vars["Description"].GetComponent<Text>().text = TableLocator.furnitureTable.Find(HomeSceneManager.instance.selectFurnitureID).Description;
    }

    public void ExitItemInfo()
    {
        HomeSceneUIControl.instance.ItemInfoControl(false);
    }

    IEnumerator Escape()
    {
        while (true)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    GetComponent<Animator>().SetTrigger("Close");
                    HomeSceneUIControl.instance.MenuButton.SetTrigger("ButtonUp");
                    StopCoroutine(esc);
                    esc = null;
                }
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    GetComponent<Animator>().SetTrigger("Close");
                    HomeSceneUIControl.instance.MenuButton.SetTrigger("ButtonUp");
                    StopCoroutine(esc);
                    esc = null;
                }
            }

            yield return null;
        }
    }

    private void OnDestroy()
    {
        GameObject.Find("EmptyBackgroundButton(Clone)").GetComponent<Button>().interactable = true;
    }
}
