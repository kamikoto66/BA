//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class CarController : MonoBehaviour
//{
//    //public Transform[] meshRodas;
//    //public WheelCollider[] colisorRodas;

//    //public float torque = 1000;
//    //public float pesoVeiculo = 1500;

//    //private float angulo;
//    //private float direcao;

//    //private Rigidbody corpoRigido;

//    //void Start()
//    //{
//    //    corpoRigido = GetComponent<Rigidbody>();
//    //    corpoRigido.mass = pesoVeiculo;

//    //}

//    //void Update()
//    //{
//    //    direcao = Input.GetAxis("Horizontal");
//    //    if (Input.GetAxis("Horizontal") > 0.7f || Input.GetAxis("Horizontal") < -0.7f)
//    //    {
//    //        angulo = Mathf.Lerp(angulo, direcao, Time.deltaTime * 4);
//    //    }
//    //    else
//    //    {
//    //        angulo = Mathf.Lerp(angulo, direcao, Time.deltaTime * 2);
//    //    }
//    //}

//    //void FixedUpdate()
//    //{
//    //    colisorRodas[0].steerAngle = angulo * 40;
//    //    colisorRodas[1].steerAngle = angulo * 40;
//    //    //
//    //    colisorRodas[2].motorTorque = Input.GetAxis("Vertical") * torque;
//    //    colisorRodas[3].motorTorque = Input.GetAxis("Vertical") * torque;
//    //    colisorRodas[0].motorTorque = Input.GetAxis("Vertical") * torque;
//    //    colisorRodas[1].motorTorque = Input.GetAxis("Vertical") * torque;

//    //    for (int x = 0; x < colisorRodas.Length; x++)
//    //    {
//    //        Quaternion quat;
//    //        Vector3 pos;
//    //        colisorRodas[x].GetWorldPose(out pos, out quat);
//    //        meshRodas[x].position = pos;
//    //        meshRodas[x].rotation = quat;
//    //    }
//    //}

//    Rigidbody rBody;
//    public Vector3 COM = new Vector3(0 ,0, 0);
//    public WheelCollider[] wc;
//    public Transform[] tires;

//    public int wcTorqueLength;

//    public int wcDecelerationSpeedLenth;

//    public float mTorque = 2500;
//    public float mBrake = 10000f;
//    public float mSteer = 25f;
//    public float mDecelerationSpeed = 1000f;

//    public float currentSpeed;
//    public float mSpeed;
//    public float mMagnitude;
//    public bool turning;

//    public bool BrakeAllowed;

//    void Start()
//    {
//        rBody = GetComponent<Rigidbody>();
//        rBody.centerOfMass = COM;
//    }

//    void Update()
//    {
//        HandBrake();
//        RotatingRTires();
//    }

//    void FixedUpdate()
//    {
//        CarMovement();
//        DecelerationSpeed();

//    }

//    private void DecelerationSpeed()
//    {
//        if (!BrakeAllowed && Input.GetButton("Vertical") == false)
//        {
//            for (int i = 0; i < wcDecelerationSpeedLenth; i++)
//            {
//                wc[i].brakeTorque = mDecelerationSpeed;
//                wc[i].motorTorque = 0;
//            }
//        }
//    }

//    private void CarMovement()
//    {
//        currentSpeed = wc[2].radius * wc[2].rpm * 60 / 1000 * Mathf.PI;
//        currentSpeed = Mathf.Round(currentSpeed);

//        if(currentSpeed < mSpeed && rBody.velocity.magnitude <= mMagnitude)
//        {
//            for (int i= 0; i < wcTorqueLength; i++)
//            {
//                wc[i].motorTorque = Input.GetAxis("Vertical") * mTorque;
//            }
//        }
//        wc[0].steerAngle = Input.GetAxis("Horizontal") * mSteer;
//        wc[1].steerAngle = Input.GetAxis("Horizontal") * mSteer;

//        if (Input.GetAxis("Horizontal") != 0)
//        {
//            turning = true;
//        }
//        else
//            turning = false;

//    }

//    private void RotatingRTires()
//    {
//        for (int i = 0; i < wcTorqueLength; i++)
//        {
//            tires[i].Rotate(wc[i].rpm / 60 * 360 * Time.deltaTime, 0f, 0f);
//        }
//        tires[0].localEulerAngles = new Vector3(tires[0].localEulerAngles.x, wc[0].steerAngle - tires[0].localEulerAngles.z, tires[0].localEulerAngles.z);
//        tires[1].localEulerAngles = new Vector3(tires[1].localEulerAngles.x, wc[1].steerAngle - tires[1].localEulerAngles.z, tires[1].localEulerAngles.z);

//    }

//    private void HandBrake()
//    {
//        if(Input.GetKey(KeyCode.Space))
//        {
//            BrakeAllowed = true;
//        }
//        else
//        {
//            BrakeAllowed = false;
//        }

//        if(rBody.velocity.magnitude <= 10f && BrakeAllowed && turning)
//        {
//            mBrake = 20f;
//        }
//        else if(BrakeAllowed)
//        {
//            for (int i = 0; i < wcTorqueLength; i++) 
//            {
//                wc[i].brakeTorque = mBrake;
//                wc[i].motorTorque = 0f;
//            }
//            rBody.drag = 0.4f;
//        }
//        else if(!BrakeAllowed && Input.GetButton("Vertical") == true) 
//        {
//            for (int i = 0; i < wcTorqueLength; i++)
//            {
//                wc[i].brakeTorque = 0;
//            }
//            rBody.drag = 0.4f;
//        }
//    }
//}


using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{

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
        maxTorque = 1000;
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -1, 0); // 무게중심이 높으면 차가 쉽게 전복된다
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //전진, 후진
        colliderRR.motorTorque = maxTorque * speed;
        colliderRL.motorTorque = maxTorque * speed;

        //좌우 방향전환
        colliderFR.steerAngle = 15 * -Input.GetAxis("Horizontal");
        colliderFL.steerAngle = 15 * -Input.GetAxis("Horizontal");

        // 바퀴회전효과
        wheelTransformFL.Rotate(colliderFL.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);
        wheelTransformFR.Rotate(colliderFR.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);
        wheelTransformRL.Rotate(colliderRL.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);
        wheelTransformRR.Rotate(colliderRR.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);
    }
}