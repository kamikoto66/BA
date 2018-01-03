using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SceneChangeManager : MonoBehaviour {

    private Transform _Canvas;
    private GameObject _FadeImage;
    private SceneIndex _NextScene;
    private SceneIndex _CurrentScene;
    private bool _IsnextScene;

    // Use this for initialization
    void Start()
    {
        _Canvas = GameObject.Find("Canvas-UIManager").GetComponent<Transform>();
        FadeSetUp("Fade");
        StartCoroutine("FadeIn");
    }

    public void ChangeScene(SceneIndex index)
    {
        FadeSetUp("FadeOut");

        _NextScene = index;
        _IsnextScene = true;
        StartCoroutine("FadeOut");
    }

    private void FadeSetUp(string FadeName)
    {
        //생성
        _FadeImage = Instantiate(Resources.Load("Prefabs/SceneChange/FadeImage")) as GameObject;
        //셋팅
        _FadeImage.transform.SetParent(_Canvas);
        _FadeImage.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        _FadeImage.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

        switch (FadeName)
        {
            case "FadeIn":
                _FadeImage.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                break;
            case "FadeOut":
                _FadeImage.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                break;
        }
    }

    private void DestroyFadeImage()
    {
        Destroy(_FadeImage);
        _FadeImage = null;
    }

    //밝아짐
    IEnumerator FadeIn()
    {
        while (true)
        {
            Color color = _FadeImage.GetComponent<Image>().color;
            color.a -= Mathf.Lerp(0, 1, Time.deltaTime);

            if (color.a <= 0.0f)
            {
                StopCoroutine("FadeIn");
                DestroyFadeImage();
            }
            else
            {
                _FadeImage.GetComponent<Image>().color = color;
            }

            yield return null;
        }
    }

    //어두워짐
    IEnumerator FadeOut()
    {
        while (true)
        {
            Color color = _FadeImage.GetComponent<Image>().color;
            color.a += Mathf.Lerp(0, 1, Time.deltaTime);

            if (color.a >= 1.0f)
            {
                _IsnextScene = false;
                _CurrentScene = _NextScene;
                SceneManager.LoadScene((int)_NextScene);
                StopCoroutine("FadeOut");
            }
            else
            {
                _FadeImage.GetComponent<Image>().color = color;
            }

            yield return null;
        }
    }

}
