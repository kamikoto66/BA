using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour {

    GameObject chim;
    public Text TimeText;
    public int time;
	
    void StartTick()
    {
        StartCoroutine(tick());
    }
    
    void Start()
    {
        StartTick();
        time = 300;
    }


	// Update is called once per frame
	void Update ()
    {
    
    }

    IEnumerator tick()
    {
        while (true)
        {
            time -= 1;
            if (time <= 0)
            {
                StopCoroutine("tick");
                GameManager.getInstance.isGameOver = true;
                GameManager.getInstance.GameOver();
            }
            TimeText.text = time.ToString();
            yield return new WaitForSeconds(1.0f);
        }
    }
}
