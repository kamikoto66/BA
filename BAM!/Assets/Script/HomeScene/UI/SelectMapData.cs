using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMapData : MonoBehaviour {

    public Text stageName;
    public Text moneyAward;
    public Text HonorAward;
    public Text time;
    public Text level;

    private MapDataDescriptor data;
    
    public void SetUp(MapDataDescriptor data)
    {
        this.data = data;
        stageName.text = data.Name;
        moneyAward.text = data.Award;
        HonorAward.text = data.Award;
        time.text = "Time: " + data.Time.ToString();
        level.text = "Level: " + data.Level.ToString();
    }
}
