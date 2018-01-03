using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public GameObject gameCamera;
    public GameObject map;
    public GameObject animalControl;

    // UI
    public Canvas canvas;

    // 동적 생성
    public GameObject playerObject;
    public GameObject animalControlObject;

    // 게임 클리어 여부
    public bool isGameClear;
    public bool isGameOver;
    public bool isPopUp;

    // 로드한 게임 맵데이터
   [HideInInspector]  public LoadMapData loadMapData;

    // Use this for initialization
    void Awake ()
    {
        //게임로드
        var stageTable = TableLocator.userDataTable.Find("User").SelectMap;
     //    SceneManager.LoadScene(TableLocator.mapDataTable.Find(stageTable).Name, LoadSceneMode.Additive);
        SceneManager.LoadScene("New Scene", LoadSceneMode.Additive);
        //
        GameObject.Find("Canvas").GetComponent<CanvasScaler>().referenceResolution = new Vector2(2560, 1440);
        Screen.orientation = ScreenOrientation.LandscapeLeft;



    }

    void Start()
    {
        // 플레이어 생성
        PlayerInit();
        // 동물관리 생성
        AnimalControlInit();
        //   UIManager.OpenUI<PopupSample>("Prefabs/GameScene/UI/PopUp", UIManager.UIType.ClosingModal);

        // canvas.GetComponentInChildren<PopUp>().openUI();

        // UI 세팅

        // 시계 설정
        canvas.GetComponentInChildren<Clock>().endTime = loadMapData.gameTime;
        canvas.GetComponentInChildren<Clock>().StartTick();

        // 진행바 설정
        //foreach (ProgressBar val in canvas.GetComponentsInChildren<ProgressBar>()) 
        //{
        //    if(val.barType == (int)eBarType.eProgressBar)
        //    {

        //    }
        //}
    }

    // 동적생성
    void PlayerInit()
    {
        string playerCarId = (TableLocator.userDataTable.Find("User").SelectCar);

        GameObject car = null;

        car = Resources.Load(TableLocator.carTable.Find(playerCarId).prefabPath) as GameObject;
        Debug.Log(TableLocator.carTable.Find(playerCarId).prefabPath);
        // speed 와 masSpeed 적용

        car.GetComponent<PlayerMove>().speed = TableLocator.carTable.Find(playerCarId).Speed;
        car.GetComponent<PlayerMove>().maxSpeed = TableLocator.carTable.Find(playerCarId).MaxSpeed;

        playerObject = (GameObject)Instantiate(car, loadMapData.playerPos.position, car.transform.rotation);
        // 카메라 세팅
        gameCamera.GetComponent<QuarterCamera>().player = playerObject;

       
    }

    void AnimalControlInit()
    {
        animalControlObject = (GameObject)Instantiate(animalControl, animalControl.transform.position, animalControl.transform.rotation);
    }

    public void GameClear()
    {

    }

    public void GameOver()
    {
      //  foreach(ProgressBar val in canvas.GetComponentsInChildren<ProgressBar>())
        {
            //val.Close();
        }
       // canvas.GetComponentInChildren<Clock>().Close();

        GameObject popUp = Resources.Load("Prefabs/GameScene/UI/PopUp") as GameObject;
        Instantiate(popUp);
    }

    //=====================================
    // 싱글톤
    private static GameManager instance;

    public static GameManager getInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            }
            return instance;
        }
    }

    public int m_data { set; get; }
}
