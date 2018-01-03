using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureInventory : MonoBehaviour
{
    public Button inventoryOpen;
    public GameObject[] Images;
    public GameObject content;

    private Dictionary<string, GameObject> sponItem = new Dictionary<string, GameObject>();
    private Coroutine esc;

    private void Start()
    {
        SetUpInventory();
    }

    //가구 선택
    public void OnClickSelect()
    {
        SoundManager.Instance.PlaySound(0);


        if (HomeSceneManager.instance.SetUpFurnitureModel())
        {
            StopCoroutine();
            HomeSceneUIControl.instance.FurntireSelect();
        }
    }

    //인벤토리 열기
    public void OpenInventory()
    {
        HomeSceneUIControl.instance.FurnitureInventoryOpen();
        esc = StartCoroutine(Escape());
    }

    private void SetUpInventory()
    {
        int sponCount = 0;  
        Vector3 sponPos = new Vector3(-230, 250.0f, 0.0f);


        UserDataDescriptior user = TableLocator.userDataTable.Find("User");

        for (int i = 0; i < user.FurnitureData.Count; i++)
        {
            string code = user.FurnitureData[i].Id;
            GameObject obj;

            if (user.FurnitureData[i].Have && user.FurnitureData[i].Use == false)
            {
                FurnitureTableDescriptor info = TableLocator.furnitureTable.Find(code);
                obj = Instantiate(Resources.Load<GameObject>(info.ImagePath));
                obj.GetComponent<FurnitureImage>().SetInfo(info);
                obj.transform.localPosition = sponPos;
                obj.transform.localRotation = Quaternion.identity;
                obj.transform.localScale = Vector3.one;
                obj.transform.SetParent(content.transform, false);
                sponItem[info.Id] = obj;

                if (sponCount == 0)
                {
                    sponPos.x = 0;
                    sponCount = 1;
                }
                else if (sponCount == 1)
                {
                    sponPos.x = 230;
                    //sponPos.y -= 240;
                    sponCount = 2;
                }
                else if(sponCount == 2)
                {
                    sponPos.x = -230;
                    sponPos.y -= 240;
                    sponCount = 0;
                }
            }
        }
    }

    public void ResponItem()
    {
        foreach(var item in sponItem)
        {
            Destroy(item.Value);
        }
        sponItem.Clear();
        SetUpInventory();
    }

    public void PopItem(string id)
    {
        if(sponItem.ContainsKey(id))
        {
            Destroy(sponItem[id]);
            ResponItem();
        }
    }

    IEnumerator Escape()
    {
        while (true)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    HomeSceneUIControl.instance.FurnitureInventoryClose();
                    StopCoroutine();
                }
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    HomeSceneUIControl.instance.FurnitureInventoryClose();
                    StopCoroutine();
                }
            }

            yield return null;
        }
    }

    private void StopCoroutine()
    {
        inventoryOpen.interactable = true;
        StopCoroutine(esc);
        esc = null;
    }
}
