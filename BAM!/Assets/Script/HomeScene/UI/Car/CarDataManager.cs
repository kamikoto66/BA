using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDataManager : MonoBehaviour {

    public static CarDataManager m_pInstance;
    private CarDataParse carDataParse;

    // Use this for initialization
    void Start () {
        m_pInstance = this;
        //carDataParse = GetComponent<CarDataParse>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetCar(int id)
    {
        carDataParse.ChangeCarHave(id);
    }

    public void AddItem(CarInfo _cInfo) { carDataParse.carData[_cInfo.id] = _cInfo; }
    public CarInfo GetItem(int id) { return carDataParse.carData[id]; }
    public Dictionary<int, CarInfo> GetAllItem() { return carDataParse.carData; }
    public int GetItemCount() { return carDataParse.carData.Count; }
}

public class CarInfo
{
    public int id;
    public bool have;
    public int curDur;
    public int MaxDur;
    public string ImageName;

    public CarInfo() { }
    public CarInfo(int id, bool have, int MaxDur, int CurDur, string ImageName)
    {
        this.id = id;
        this.have = have;
        this.MaxDur = MaxDur;
        this.curDur = CurDur;
        this.ImageName = ImageName;
    }
}