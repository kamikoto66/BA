using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSystem : MonoBehaviour {

    public static StoreSystem instance;
    public float[] carProb;
    public float[] furnitureProb;

    float Choose(float[] probs) // 확률
    {
        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

    void Start()
    {
        instance = this;

        int c = TableLocator.probsTable.Find("Prob").cars.Count;
        carProb = new float[c];

        for (int i = 0; i < c; i++)
        {
            carProb[i] = TableLocator.probsTable.Find("Prob").cars[i].Value;
        }

        int f = TableLocator.probsTable.Find("Prob").furnitures.Count;
        furnitureProb = new float[f];

        for (int i = 0; i < f; i++)
        {
            furnitureProb[i] = TableLocator.probsTable.Find("Prob").furnitures[i].Value;
        }

    }

    public int BuyCar()
    {
        var index =  Choose(carProb);

        int random = new int();

        if (index == 0)
        {
            random = Random.Range(0, 3);
        }
        else if (index == 1)
        {
            random = Random.Range(4, 7);
        }
        else if (index == 2)
        {
            random = Random.Range(8, 10);
        }

        return random;
    }
}