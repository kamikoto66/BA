using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum eFurnitureIndex
{
    eBookShelf,
    eChair,
    eDesk,
    eDumbell,
    eForDecorate,
    eSpeaker,
    eTrash
}

public class FurnitureObject : MonoBehaviour {

    public bool isSelect = false;
    public Animator animator;
    public bool isRotation = false;

    public FurnitureTableDescriptor itemInfo;
    public Vector2 xPosEnd;
    public Vector2 zPosEnd;
    public Vector2 oldMousePos;

    //public Vector3 oldMousePos;
    public Transform modelTransform;

    public GameObject plane;

    public Material planeMatrial;
    public bool IsObjectEnter;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }

    public virtual void SetUpFurniture(FurnitureTableDescriptor data, int index )
    {
        //planeMatrial = plane.GetComponent<MeshRenderer>().materials[0];
        //planeMatrial.color = Color.green;
        //plane.SetActive(false);

        modelTransform = GetComponent<Transform>();
        itemInfo = data;
        isRotation = TableLocator.userDataTable.Find("User").FurnitureData[index].Rotate;
    }

    public virtual void Buff() { }

    public virtual void Init() { }

    public virtual FurnitureTableDescriptor Rotation() { return null; }

    void OnMouseDown()
    {
        if (isSelect.Equals(false) && HomeSceneManager.instance.modelSelect.Equals(false) && HomeSceneUIControl.instance.IsInventoryOpen.Equals(false))
        {
            isSelect = true;

            HomeSceneUIControl.instance.FurnitureObjectClick();
            HomeSceneManager.instance.ModelSelect(gameObject.name,itemInfo.Id);

            var canvas = GameObject.Find("Canvas-UIManager").GetComponent<Transform>();

            var obj = Instantiate(Resources.Load<GameObject>("Prefabs/HomeScene/UI/EmptyBackgroundButton"));
            //obj.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            obj.GetComponent<Button>().onClick.AddListener(() => { ExitSetUp(obj); });
            obj.GetComponent<Transform>().SetParent(canvas);
            obj.GetComponent<Transform>().localPosition = new Vector3(0.0f, 300.0f, 0.0f);
            obj.GetComponent<Transform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    private void ExitSetUp(GameObject thisObj)
    {
        HomeSceneUIControl.instance.FurnitureReturn();
        HomeSceneManager.instance.ModelSelectExit();
        Destroy(thisObj);
        isSelect = false;
    }

    IEnumerator OnMouseDrag()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            while (Input.touchCount >= 1)
            {
                if (isSelect && HomeSceneManager.instance.modelSelect)
                {
                    var touch = Input.GetTouch(0);
                    Vector2 curPos = touch.position;
                    Vector2 dir = curPos - oldMousePos;
                    Vector3 newModelPos;

                    dir.Normalize();

                    if (dir.x > 0 && dir.y > 0)
                    {
                        newModelPos = new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z);

                        if (newModelPos.x > xPosEnd.y)
                            newModelPos.x = xPosEnd.y;

                        transform.position = newModelPos;
                    }
                    else if (dir.x < 0 && dir.y < 0)
                    {
                        newModelPos = new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z);

                        if (newModelPos.x < xPosEnd.x)
                            newModelPos.x = xPosEnd.x;

                        transform.position = newModelPos;
                    }
                    else if (dir.x > 0 && dir.y < 0)
                    {
                        newModelPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.0f);

                        if (newModelPos.z < zPosEnd.x)
                            newModelPos.z = zPosEnd.x;

                        transform.position = newModelPos;
                    }
                    else if (dir.x < 0 && dir.y > 0)
                    {
                        newModelPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.0f);

                        if (newModelPos.z > zPosEnd.y)
                            newModelPos.z = zPosEnd.y;

                        transform.position = newModelPos;
                    }

                    oldMousePos = curPos;
                }

                yield return null;
            }
        }
        else if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            while (Input.GetMouseButton(0))
            {
                if (isSelect && HomeSceneManager.instance.modelSelect)
                {
                    Vector3 curPos = Input.mousePosition;
                    Vector3 dir = new Vector3(curPos.x - oldMousePos.x, curPos.y - oldMousePos.y, 0.0f);
                    Vector3 newModelPos;

                    dir.Normalize();

                    if (dir.x > 0 && dir.y > 0)
                    {
                        newModelPos = new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z);

                        if (newModelPos.x > xPosEnd.y)
                            newModelPos.x = xPosEnd.y;

                        transform.position = newModelPos;
                    }
                    else if (dir.x < 0 && dir.y < 0)
                    {
                        newModelPos = new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z);

                        if (newModelPos.x < xPosEnd.x)
                            newModelPos.x = xPosEnd.x;

                        transform.position = newModelPos;
                    }
                    else if (dir.x > 0 && dir.y < 0)
                    {
                        newModelPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.0f);

                        if (newModelPos.z < zPosEnd.x)
                            newModelPos.z = zPosEnd.x;

                        transform.position = newModelPos;
                    }
                    else if (dir.x < 0 && dir.y > 0)
                    {
                        newModelPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.0f);

                        if (newModelPos.z > zPosEnd.y)
                            newModelPos.z = zPosEnd.y;

                        transform.position = newModelPos;
                    }

                    oldMousePos = curPos;
                }
                yield return null;
            }
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if(isSelect && other.tag == "Furniture")
        {
            if(IsObjectEnter.Equals(false))
            {
                //planeMatrial.color = Color.red;
                IsObjectEnter = true;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (isSelect && other.tag == "Furniture")
        {
            if (IsObjectEnter.Equals(true))
            {
                //planeMatrial.color = Color.green;

                IsObjectEnter = false;
            }
        }
    }

    public void ModelSelect()
    {
        isSelect = true;
        //plane.SetActive(true);
    }

    public void ModelUnSelect()
    {
        isSelect = false;
        //plane.SetActive(false);
    }
}