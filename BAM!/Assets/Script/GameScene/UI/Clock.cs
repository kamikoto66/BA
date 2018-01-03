using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

    public float endTime;
    public float nowTime;
    public GameObject secondHand;

    // Use this for initialization
    public void StartTick()
    {
        nowTime = 0;
        StartCoroutine("tick");
    }

    void Update()
    {
      
    }

    IEnumerator tick()
    {
        while(true)
        {
            nowTime++;
            secondHand.transform.eulerAngles = new Vector3(secondHand.transform.rotation.x, secondHand.transform.rotation.y, (nowTime / endTime * -360));
            if (nowTime > endTime)
                StopCoroutine("tick");
            yield return new WaitForSeconds(1.0f);
        }
        
    }
}
