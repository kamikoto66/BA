using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    private Touch tempTouchs;
    private Vector3 touchedPos;
    bool touchOn;

    public WheelCollider colliderFR;
    public WheelCollider colliderFL;
    public WheelCollider colliderRR;
    public WheelCollider colliderRL;

    // 바퀴 회전을 위한 Transform
    public Transform wheelTransformFL;
    public Transform wheelTransformFR;
    public Transform wheelTransformRL;
    public Transform wheelTransformRR;

    public int maxTorque;

    public int speed;
    public int maxSpeed;

    // Use this for initialization
    void Start()
    {
        touchOn = false;

        maxTorque = 1000;
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -2, 0); // 무게중심이 높으면 차가 쉽게 전복된다
    }

   public void move()
    {


        // 모바일 이동
        if (Input.touchCount > 0)
        {    //터치가 1개 이상이면.
            for (int i = 0; i < Input.touchCount; i++)
            {
                tempTouchs = Input.GetTouch(i);
                if(tempTouchs.phase == TouchPhase.Ended)
                {
                    colliderFR.steerAngle = 0;
                    colliderFL.steerAngle = 0;
                }

                if (tempTouchs.phase == TouchPhase.Began || tempTouchs.phase == TouchPhase.Moved || tempTouchs.phase == TouchPhase.Stationary)
                {

                    touchedPos = tempTouchs.position;
                  //  touchedPos = Camera.main.ScreenToWorldPoint(tempTouchs.position);//get world position.
                    touchOn = true;

                    //  좌우 위치 구별후 이동
                    if (touchedPos.x <= Screen.width/2 )
                    {
                        colliderFR.steerAngle = 15 * -1;
                        colliderFL.steerAngle = 15 * -1;
                    }
                    else if(touchedPos.x >= Screen.width / 2)
                    {
                        colliderFR.steerAngle = 15 * 1;
                        colliderFL.steerAngle = 15 * 1;
                    }

                    break;   //한 프레임(update)에는 하나만.
                }
            }
        }



        //전진, 후진
        colliderRR.motorTorque = maxTorque * speed;
        colliderRL.motorTorque = maxTorque * speed;

        //좌우 방향전환
        colliderFR.steerAngle = 15 * Input.GetAxis("Horizontal");
        colliderFL.steerAngle = 15 * Input.GetAxis("Horizontal");

        // 바퀴회전효과
        wheelTransformFL.Rotate(colliderFL.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);
        wheelTransformFR.Rotate(colliderFR.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);
        wheelTransformRL.Rotate(colliderRL.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);
        wheelTransformRR.Rotate(colliderRR.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);
    }
}
