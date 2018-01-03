using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private AudioSource audioSource = new AudioSource();
    private AudioClip audioClip = new AudioClip();

    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = (SoundManager)GameObject.FindObjectOfType(typeof(SoundManager));
                if (!instance)
                {
                    GameObject uiManagerPrefab = Resources.Load<GameObject>("Prefab/SoundManager");
                    instance = Instantiate<GameObject>(uiManagerPrefab).GetComponent<SoundManager>();
                }
            }

            return instance;
        }
    }

    private void Start()
    {
        audioClip = Resources.Load("Sound/04_button") as AudioClip;
        //audioClip[1] = Resources.Load("Sound/backgroundSound") as AudioClip;


        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;

        //audioSource[1] = gameObject.AddComponent<AudioSource>();
        //audioSource[1].clip = audioClip[1];
        //audioSource[1].loop = true;
    }

    public void PlaySound(int code)
    {
        audioSource.Play();
    }
}
