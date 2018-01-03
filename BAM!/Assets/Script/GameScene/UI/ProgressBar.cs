using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum eBarType { eProgressBar = 0, eHpBar}

public class ProgressBar : MonoBehaviour {

    private Slider progressBar;
    public int startNum;
    public int nowNum;
    public int barType;

    bool isSetting;

    public GameObject fill;

    // Use this for initialization
    void Start () {
        isSetting = false;
        fill.GetComponent<Image>().SetNativeSize();
        StartCoroutine(settingData());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(isSetting)
        {
            progressBar.value = (float)nowNum / (float)startNum;
            //progressText.text = (((float)nowNum / (float)startNum) * 100).ToString()+ "%";

            if (!GameManager.getInstance.isGameClear && !GameManager.getInstance.isGameOver)
            {
                switch (barType)
                {
                    case (int)eBarType.eProgressBar:
                        if (startNum == nowNum)
                        {
                            GameManager.getInstance.isGameClear = true;
                            StartCoroutine("GetAnimalTime");
                        }
                        break;
                }
            }
        }
        
    }

    IEnumerator GetAnimalTime()
    {
        while (nowNum >= 0)
        {
            nowNum--;
            if (nowNum <= 0)
            {
                GameManager.getInstance.canvas.GetComponentInChildren<PopUp>().openUI();
                yield return new WaitForSeconds(1f);
                StopCoroutine("GetAnimalTime");
            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator settingData()
    {
        yield return new WaitForSeconds(1f);

        isSetting = true;
        progressBar = GetComponent<Slider>();

        if(barType == (int)eBarType.eProgressBar)
        {
            nowNum = 0;
            startNum = GameManager.getInstance.loadMapData.buildingNum;
        }
    }
}
