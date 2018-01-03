using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class StageSelect : UI {

    public Transform content;
    public Vector3 sponStartPos;

    private MapDataInfo mapInfo;

    void Start () {
        Init();
    }
	
    private void Init()
    {
        UIHelper.AddButtonListener(Vars["select"], Select);

        mapInfo = new MapDataInfo();
        mapInfo.SettingData();

        var e = mapInfo.MapList;

        var rt = content.GetComponent<RectTransform>();

        foreach (var map in e)
        {
            var size = rt.sizeDelta;
            size.Set(size.x, size.y + 300.0f);
            rt.sizeDelta = size;

            GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/HomeScene/UI/StageSelectButton"));
            obj.GetComponent<SelectMapData>().SetUp(map.Value);
            obj.transform.SetParent(content);
            obj.transform.localPosition = sponStartPos;
            obj.transform.localScale = new Vector3(0.7f, 0.8f, 1.0f);

            sponStartPos.y -= 300;
        }
    }

    public void Select()
    {
        SoundManager.Instance.PlaySound(0);

        GameObject.Find("SceneChangeManager(Clone)").GetComponent<SceneChangeManager>().ChangeScene(SceneIndex.eGameScene);
        var user = TableLocator.userDataTable.Find("User");
        user.SelectMap = HomeSceneManager.instance.selectMapData;

        TableLocator.userDataTable.ChangeData(user);
        
        Screen.SetResolution(2560,1440, true);
    }
}
