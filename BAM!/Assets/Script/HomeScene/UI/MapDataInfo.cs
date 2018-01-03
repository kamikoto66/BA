using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class MapDataInfo
{

    private Dictionary<int, MapDataDescriptor> mapList = new Dictionary<int, MapDataDescriptor>();

    public void SettingData()
    {
        int listLength = TableLocator.mapDataTable.dictionary.Count;
        //int listLength = TableLocator.mapDataTable.dictionary.Count;
        string mapName = "M_";

        for (int i = 0; i < listLength; i++)
        {
            string name = mapName + i.ToString();
            MapDataDescriptor mapData = TableLocator.mapDataTable.Find(name);
            int level = int.Parse(mapData.Level);
            mapList.Add(level, mapData);
        }
    }

    public Dictionary<int, MapDataDescriptor> MapList { get { return mapList; } private set { } }
}
