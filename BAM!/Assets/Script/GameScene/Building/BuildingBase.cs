using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBase : MonoBehaviour
{

    public int hp;
    public int id;
    public bool isDestroy;
    // 집
    public GameObject house;
    // 폐허
    public GameObject ruins;
    // 파티클
    public GameObject particle;

    private float endYPos;

    void CheckHP()
    {
        // 체력이 0 이하일때 건물파괴
        if(hp <= 0)
        {
            Vector3 particlePos = gameObject.transform.position;
            particlePos.y +=1 ;

            GameObject ex = (GameObject)Instantiate(particle, particlePos, particle.transform.rotation);
            //GetComponent<Animator>().SetBool("IsFallen", true);

            GameManager.getInstance.canvas.GetComponentInChildren<ProgressBar>().nowNum++;

         //   GameObject ru = (GameObject)Instantiate(ruins, gameObject.transform.position, ruins.transform.rotation);
         //   ru.transform.position = new Vector3(ru.transform.position.x, ru.transform.position.y + 0.01f, ru.transform.position.z);
            //GetComponent<Animator>().SetBool("IsFallen", true);

            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Animal" && coll.gameObject.GetComponent<AnimalBase>().animalState != eAnimalState.eDeath)
        {
            hp -= 1;
            coll.gameObject.GetComponent<AnimalBase>().MinusHP();

            foreach(ProgressBar val in GameManager.getInstance.canvas.GetComponentsInChildren<ProgressBar>())
            {
                if(val.barType == (int)eBarType.eProgressBar)
                {
                    val.nowNum++;
                    break;
                }
            }
           GameManager.getInstance.gameCamera.GetComponent<QuarterCamera>().vibrateCamera();
            CheckHP();

            Vector3 particlePos = gameObject.transform.position;
            particlePos.y += 1;


            GameObject ex = (GameObject)Instantiate(particle, particlePos, particle.transform.rotation);
        }
    }
}
