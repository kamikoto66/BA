using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUI : MonoBehaviour {

    public int maxHp;
    int nowHp;

    public GameObject heart;
    public GameObject unHeart;

    public List<GameObject> hearts;

	// Use this for initialization
	void Start () {
        nowHp = maxHp;
        for (int i = 0; i < maxHp; i++)
        {
            hearts.Add(Instantiate(heart,new Vector3(-400 + i * 100,  547, - 1328), heart.transform.rotation));
            hearts[i].transform.localScale = new Vector3(1, 1, 1);
            hearts[i].transform.SetParent(this.transform, false);
        }
	}
	
	public void minusHp()
    {
        nowHp -= 1;
        int unHeartNum = maxHp - nowHp;
        hearts[hearts.Count - unHeartNum] = unHeart;
        unHeart.transform.position = new Vector3(-400 + 100 * hearts.Count - unHeartNum, 547, -1328);
    }
}
