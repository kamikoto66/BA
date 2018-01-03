using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    // 체력과, 속력등은 후에 xml 파싱을 통해서 얻어옵니다.
    public int hp;
    public int baseSpeed;
    public int maxSpeed;
    public int accelSpeed;

    Vector3 startPos;
    Vector3 endPos;

    // 도발 상태 체크
    public bool isProvoke;

	// Use this for initialization
	void Start ()
    {
        isProvoke = false;
        hp = 5;

        // 체력 UI 설정
        foreach(ProgressBar val in GameManager.getInstance.canvas.GetComponentsInChildren<ProgressBar>())
        {
            if(val.barType == (int)eBarType.eHpBar)
            {
                val.startNum = hp;
                val.nowNum = hp;
            }
        }
    }
	
    public void state()
    { 
        if (Input.GetMouseButtonDown(0))
            startPos = Input.mousePosition;
        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            if (startPos.y - endPos.y > 100)
            {
                isProvoke = true;
                GetComponent<PlayerContol>().danger.SetActive(true);
            }
            if (startPos.y - endPos.y < -100)
            {
                isProvoke = false;
                GetComponent<PlayerContol>().danger.SetActive(false);
            }
        }
    }

    public bool GetIsProvoke()
    {
        return isProvoke;
    }
}
