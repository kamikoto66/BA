using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarterCamera : MonoBehaviour {

    public Vector3 camRotation = new Vector3(48, -45, 0);
   public Vector3 camPosition = new Vector3(20, 10, -2);
    public GameObject player;
    public bool bShake;
    public float shakePower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        // transform.position = player.transform.position + camPosition;
        transform.position = Vector3.Lerp(transform.position, player.transform.position + camPosition, 10  * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(camRotation);

        // 카메라 진동
        if (bShake == true)
        {
            if(shakePower > 0.0f)
            {
                shakePower -= 5.0f * Time.deltaTime;
            }
            else
            {
                bShake = false;
                shakePower = 0.0f;
            }
            Vector3 shakeCameraPos = Random.insideUnitCircle * shakePower;
            transform.position = new Vector3(transform.position.x + shakeCameraPos.x, transform.position.y + shakeCameraPos.y, 
                transform.position.z);
        }
    }

    public void vibrateCamera()
    {
        bShake = true;
        shakePower = 1.0f;
    }
}