using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour {
    bool isPause;
    void Start()
    {
        isPause = false;
    }

    public void setPause()
    {
        isPause = !isPause;

        if(isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
