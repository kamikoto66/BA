using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    float _timeCnt;
    public GUIText _guiTime;
    // Update is called once per frame]
    private void Start()
    {
        _timeCnt = 0;
    }
    void Update()
    {
        _timeCnt += Time.deltaTime;
    }

    /// <summary>
    /// Raises the GU event.
    /// 시간표시
    /// </summary>
    void OnGUI()
    {
        string timeStr;
        timeStr = "" + _timeCnt.ToString("00.00");
        timeStr = timeStr.Replace(".", ":");
        _guiTime.text = "Time : " + timeStr;
    }
}
