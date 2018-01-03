using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContol : MonoBehaviour
{
    private PlayerMove playerMove;
    private PlayerAnimation playerAnimation;
    private PlayerState playerState;
    public GameObject danger;

	// Use this for initialization
	void Awake ()
    {
        playerMove = GetComponent<PlayerMove>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerState = GetComponent<PlayerState>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerMove.move();
        playerState.state();
	}
}
