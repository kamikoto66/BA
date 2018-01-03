using UnityEngine;
using System.Collections;

public class GameObjectDestroy : MonoBehaviour
{
    private float destroyTime;

    void Start()
    {

    }
    void Update()
    {
        if (destroyTime >= 2f)
        {
            Destroy(gameObject);
        }
        else
        {
            destroyTime += Time.deltaTime;
        }

    }

}
