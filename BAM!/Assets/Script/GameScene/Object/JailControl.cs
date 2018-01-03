using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JailControl : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if(transform.position.y > 0)
        {
            transform.Translate(new Vector3(0, 0, -10f * Time.deltaTime));
        }
	}
}
