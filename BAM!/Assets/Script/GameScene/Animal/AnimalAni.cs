using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAni : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    public void OnAni(eAnimalState state)
    {
        GetComponent<Animator>().SetBool("IsMove", false);
        GetComponent<Animator>().SetBool("IsDeath", false);

        switch(state)
        {
            case eAnimalState.eDeath:
                GetComponent<Animator>().SetBool("IsDeath", true);
                break;
            case eAnimalState.eIdle:
                break;
            case eAnimalState.eMove:
                GetComponent<Animator>().SetBool("IsMove", true);
                break;
        }
    }

    public bool GetOnAni(eAnimalState state)
    {
        switch (state)
        {
            case eAnimalState.eDeath:
                return GetComponent<Animator>().GetBool("IsDeath");
            case eAnimalState.eMove:
                return GetComponent<Animator>().GetBool("IsMove");

        }
        return false;
    }
}
