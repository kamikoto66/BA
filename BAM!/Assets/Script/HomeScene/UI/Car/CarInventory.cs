using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarInventory : UI {

    public Button InventoryOpen;
    public GameObject content;

    private Animator animator;
    private Coroutine esc;

    // Use this for initialization
    void Start () {
        UIHelper.AddButtonListener(Vars["SelectButton"], OnClickSelect);
        SetUpInvenTory();
    }
	
    public void OnClickSelect()
    {
        SoundManager.Instance.PlaySound(0);

        if (HomeSceneManager.instance.ChangeCarModel()){
            StopCoroutine();
        }
    }

    public void OpenInventory()
    {
        HomeSceneUIControl.instance.CarInventoryOpen();
        esc = StartCoroutine(Escape());
    }

    IEnumerator Escape()
    {
        while (true)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    StopCoroutine();
                }
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    StopCoroutine();
                }
            }

            yield return null;
        }
    }

    private void SetUpInvenTory()
    {
        int sponCount = 0;

        var car = TableLocator.carTable.All();

        Vector3 sponPos = new Vector3(-120.0f, 500.0f, 0.0f);

        foreach (var v in car)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>(v.ImagePath));
            obj.GetComponent<CarImage>().SetInfo(v);
            obj.transform.localPosition = sponPos;
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one;
            obj.transform.SetParent(content.transform, false);

            if (sponCount == 0)
            {
                sponPos.x = 120;
                sponCount = 1;
            }
            else if (sponCount == 1)
            {
                sponPos.x = -120;
                sponPos.y -= 240;
                sponCount = 0;
            }
        }
    }

    private void StopCoroutine()
    {
        HomeSceneUIControl.instance.CarInventoryClose();
        InventoryOpen.interactable = true;
        StopCoroutine(esc);
        esc = null;
    }
}
