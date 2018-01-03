using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eAnimal {eDear,eDear2, eGiraffe, eGiraffe2, eRhinoceros, eRhinoceros2, A_006, A_007, A_008, A_009, A_010, A_011, A_012, A_013,
    A_014, A_015, A_016, A_017};
public enum eAnimalState {eIdle, eMove, eDeath,  };

public class AnimalBase : MonoBehaviour
{
    public GameObject exclamationMark;

    public GameObject centerOfMass;

    public Transform playerPosition;
    public Vector3 direction;
    protected float velocity;
    public float accelaration;
    public int hp;
    protected bool isProvoke;

    public bool isDash;
    public eAnimal animalType;
    public eAnimalState animalState;

    public float speed;
    public float maxSpeed;
    public int id;

    public void Start()
    {
        isDash = false;
        velocity = 0.1f;
        animalState = eAnimalState.eIdle;
        GetComponent<AnimalAni>().OnAni(animalState);
        isProvoke = false;
    }

    public void Update()
    {
        if (isProvoke == false && playerPosition.GetComponent<PlayerState>().GetIsProvoke())
        {
            isProvoke = true;
        }

        CheckPlayerPosition();
        MoveToTarget();
    }

    public void Death()
    {
        hp = 0;
        if (hp <= 0)
        {
            animalState = eAnimalState.eDeath;
            GetComponent<AnimalAni>().OnAni(animalState);
        }
    }

    public void MoveToTarget()
    {
        if (animalState == eAnimalState.eDeath)
            return;

        playerPosition = GameManager.getInstance.playerObject.transform;
   
        if (animalState != eAnimalState.eMove)
            return;

        if (isDash == false)
        {
            direction = (playerPosition.transform.localPosition - centerOfMass.transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);
        }

        float distance = Vector3.Distance(playerPosition.transform.localPosition, centerOfMass.transform.position);

        if (distance <= 3.0f && isDash == false)
        {
            isDash = true;
        }
        if (distance >= 3.0f && isDash)
            isDash = false;

        if(isProvoke)
        {
            this.transform.localPosition = new Vector3(transform.localPosition.x + (direction.x * velocity * 1.2f),
                                                              transform.localPosition.y + (direction.y * velocity * 1.2f),
                                                              transform.localPosition.z + (direction.z * velocity * 1.2f));
        }
        else
        {
            this.transform.localPosition = new Vector3(transform.localPosition.x + (direction.x * velocity),
                                                           transform.localPosition.y + (direction.y * velocity),
                                                           transform.localPosition.z + (direction.z * velocity));
        }
    }

    public void CheckPlayerPosition()
    {
        if (animalState == eAnimalState.eDeath)
            return;

        float distance = Vector3.Distance(playerPosition.transform.localPosition, centerOfMass.transform.position);

        if (distance <= 15 && animalState != eAnimalState.eMove)
        {
            StartCoroutine("StartTrace");
        }

        if(distance >= 25)
        {
            animalState = eAnimalState.eIdle;
            GetComponent<AnimalAni>().OnAni(animalState);
        }
    }
     
    public void MinusHP ()
    {
        hp -= 1;
        if (hp <= 0)
        {
            animalState = eAnimalState.eDeath;
            GetComponent<AnimalAni>().OnAni(animalState);
        }
    }

    // 장애물과 충돌시에 뒤로 밀림
    void OnCollisionEnter(Collision coll)
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    IEnumerator StartTrace()
    {
        while(exclamationMark.transform.localScale.x < 0.01f)
        {
            exclamationMark.transform.localScale = new Vector3(exclamationMark.transform.localScale.x + 0.001f, exclamationMark.transform.localScale.y + 0.001f,
                exclamationMark.transform.localScale.z + 0.001f);
            if (exclamationMark.transform.localScale.x >= 0.01f)
            {
                yield return new WaitForSeconds(1f);
                animalState = eAnimalState.eMove;
                GetComponent<AnimalAni>().OnAni(animalState);
                exclamationMark.transform.localScale = new Vector3(0 ,0 ,0);
                StopCoroutine("StartTrace");
            }
            yield return new WaitForSeconds(0.01f);
        }  
    }
}
