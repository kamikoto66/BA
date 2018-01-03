using Newtonsoft.Json;
using System.IO;
using System.Text;
using UnityEngine;

public class MapDataTable : GenericTable<MapDataDescriptor> {

    public MapDataTable(string path) : base(path)
    {
    }

    private void ChangeData(MapDataDescriptor value, string path)
    {
        MapDataDescriptor desc = null;

        if (dictionary.TryGetValue(path, out desc))
        {
            desc = value;
            dictionary[path] = desc;

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                // TODO : 수정
            }
           
        }
    }

    private void AddData()
    {

    }
}
