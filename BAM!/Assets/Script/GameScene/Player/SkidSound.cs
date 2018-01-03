using UnityEngine;

using System.Collections;



public class SkidSound : MonoBehaviour
{



    public float currentFrictionValue;

    public GameObject skidSound;

    private float waitTime = 0.1f;
    public GameObject skidPrefab;

    void Start()
    {
    }

    void Update()
    {

        WheelHit hit;
        transform.GetComponent<WheelCollider>().GetGroundHit(out hit);
        currentFrictionValue = hit.sidewaysSlip;
        currentFrictionValue = Mathf.Abs(currentFrictionValue);
        if (currentFrictionValue >= 0.08f && waitTime >= 0.1f)
        {
            //Instantiate(skidSound, hit.point, Quaternion.identity);
            waitTime = 0f;
        }
        else
        {
            waitTime += Time.deltaTime;
        }

        if (currentFrictionValue >= 0.08f)
        {
            setSkidMark();
        }

    }



    private Vector3 prevPos = Vector3.zero;

    private float skidTime;

    void setSkidMark()
    {

        WheelHit hit;

        transform.GetComponent<WheelCollider>().GetGroundHit(out hit);

        if (prevPos == Vector3.zero)
        {

            prevPos = hit.point;

            return;

        }

        if (skidTime > 0.05f)
        {

            Vector3 relativePos = prevPos - hit.point; ;

            Quaternion rot = Quaternion.LookRotation(relativePos);

            GameObject skidInstance = (GameObject)Instantiate(skidPrefab, hit.point, rot);

            prevPos = hit.point;

            skidInstance.AddComponent<GameObjectDestroy>();

            skidTime = 0;

        }
        else
        {

            skidTime += Time.deltaTime;

        }

    }

}