using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalControl : MonoBehaviour {

    // 현재 맵 동물들 데이터
    public List<AnimalDataDescriptor> animalList;

    // 생성된 동물들
    public List<GameObject> animals;

    // 철장 Prefab
    public GameObject Jail;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(settingData());

	}

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && GameManager.getInstance.isGameClear)
        {
            GameObject target = GetClickedObject();
            // 대상이 동물인지 확인, 사망여부 확인
            if (target.tag != "Animal")
                return;
     //       if (target.GetComponent<AnimalBase>().animalState != eAnimalState.eDeath)
            //    return;

            Vector3 jailPos = new Vector3(target.transform.position.x, target.transform.position.y + 20, target.transform.position.z);
            GameObject jail = (GameObject)Instantiate(Jail, jailPos, Jail.transform.rotation);
        }
    }

    private GameObject GetClickedObject()
    {
        RaycastHit hit;
        GameObject target = null;


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 


        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인
        {
            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject;
        }

        return target;
    }


    IEnumerator SponAnimal(float delayTime)
    {
        GameObject animal;
        int animalType = Random.Range(0, animalList.Count);

        animal = Resources.Load(animalList[animalType].Path) as GameObject;

        GameObject sponAnimal = (GameObject)Instantiate(animal, animal.transform.position, animal.transform.rotation);
        sponAnimal.GetComponent<AnimalBase>().playerPosition = GameManager.getInstance.player.transform;
        sponAnimal.GetComponent<AnimalBase>().animalState = eAnimalState.eIdle;

        sponAnimal.GetComponent<AnimalBase>().speed = animalList[animalType].Speed;
        sponAnimal.GetComponent<AnimalBase>().maxSpeed = animalList[animalType].MaxSpeed;
        sponAnimal.GetComponent<AnimalBase>().hp = animalList[animalType].Hp;

        // 관리용 리스트에 추가
        animals.Add(sponAnimal);
    
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(SponAnimal(delayTime));
    }

    void settingAnimal()
    {
        AnimalBase animal = new AnimalBase();
        for (int i = 0; i < GameManager.getInstance.loadMapData.animalType.Count; i++)
        {
            string path = "";
            switch (GameManager.getInstance.loadMapData.animalType[i])
            {
                case eAnimal.eDear:
                    path = "A_000";
                    break;
                case eAnimal.eDear2:
                    path = "A_001";
                    break;
                case eAnimal.eGiraffe:
                    path = "A_002";
                    break;
                case eAnimal.eGiraffe2:
                    path = "A_003";
                    break;
                case eAnimal.eRhinoceros:
                    path = "A_004";
                    break;
                case eAnimal.eRhinoceros2:
                    path = "A_005";
                    break;
            }
            animalList.Add(TableLocator.animalDataTable.Find(path));
        }
    }

    IEnumerator settingData()
    {
        yield return new WaitForSeconds(1f);

        animalList = new List<AnimalDataDescriptor>();
        animalList.Clear();

        settingAnimal();

        StartCoroutine(SponAnimal(20));
    }
}
