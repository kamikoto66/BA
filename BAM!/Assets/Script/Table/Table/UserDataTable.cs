using Newtonsoft.Json;
using System.IO;
using System.Text;
using UnityEngine;

public class UserDataTable : GenericTable<UserDataDescriptior>
{
    public UserDataTable(string path) : base(path)
    {
    }

    public void ChangeData(UserDataDescriptior value)
    {
        UserDataDescriptior desc = null;

        if (dictionary.TryGetValue("User", out desc))
        {
            desc = value;
            dictionary["User"] = desc;

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.WriteStartArray();
                writer.WriteStartObject();

                //UserInfo
                writer.WritePropertyName("id");
                writer.WriteValue("User");
                writer.WritePropertyName("money");
                writer.WriteValue(value.Money);
                writer.WritePropertyName("Trophy");
                writer.WriteValue(value.Trophy);
                writer.WritePropertyName("selectCar");
                writer.WriteValue(value.SelectCar);
                writer.WritePropertyName("selectMap");
                writer.WriteValue(value.SelectMap);
                //~UserInfo

                //CarData
                writer.WritePropertyName("CarData");
                writer.WriteStartArray();

                foreach (var v in value.CarDatas)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("id");
                    writer.WriteValue(v.Id);
                    writer.WritePropertyName("have");
                    writer.WriteValue(v.Have);
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
                //~CarData

                //FurnitureData Info
                writer.WritePropertyName("FurnitureData");
                writer.WriteStartArray();
                foreach (var v in value.FurnitureData)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("id");
                    writer.WriteValue(v.Id);
                    writer.WritePropertyName("name");
                    writer.WriteValue(v.Name);
                    writer.WritePropertyName("have");
                    writer.WriteValue(v.Have);
                    writer.WritePropertyName("use");
                    writer.WriteValue(v.Use);
                    writer.WritePropertyName("rotate");
                    writer.WriteValue(v.Rotate);
                    writer.WritePropertyName("curDur");
                    writer.WriteValue(v.CurDur);
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
                //~FurnitureData Info

                writer.WriteEndObject();
                writer.WriteEndArray();
            }

            if (Application.platform == RuntimePlatform.Android)
            {
                string path = Application.persistentDataPath + "/Table/UserData.json";
                System.IO.File.WriteAllText(path, sb.ToString(), Encoding.Default);
            }
            else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                string path = "Assets/Resources/Table/UserData.json";
                System.IO.File.WriteAllText(path, sb.ToString(), Encoding.Default);
            }
        }
        else
        {
            Debug.LogErrorFormat("{0} Descriptor not found - {1}", this.GetType().Name, "User");
        }
    }
}
