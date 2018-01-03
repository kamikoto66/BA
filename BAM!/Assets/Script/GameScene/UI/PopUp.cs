using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    int size = 1;
    public Text clearText;
    public Text score;
    public Text buildingNum;
    public Text animalNum;


    void Start()
    {
        openUI();
    }

    void FixedUpdate()
    {
        //clearText.fontSize = Screen.height * size / 100;
        if(transform.localScale.x == 1)
        {
            GetComponent<Animator>().SetBool("IsAni", true);
        }
    }

    private void OnAccept()
    {

    }

    private void OnReject()
    {

    }

    public void openUI()
    {
        GetComponent<Animator>().SetBool("IsEnd", true);
    }

    // TODO : 메인씬으로 이동
    public void closeUI()
    {
        GetComponent<GameObject>().SetActive(false);
    }
}
