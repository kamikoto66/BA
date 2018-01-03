using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

public class UserDataDescriptior : BaseDescriptor {

    public class CarDataDescriptor : BaseDescriptor
    {
        [JsonProperty("have")]
        public bool Have { get; set; }
    }

    public class FurnitureDataDescriptor : BaseDescriptor
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("have")]
        public bool Have { get;  set; }

        [JsonProperty("Use")]
        public bool Use { get;  set; }

        [JsonProperty("rotate")]
        public bool Rotate { get;  set; }

        [JsonProperty("curDur")]
        public int CurDur { get;  set; }
    }
    
	[JsonProperty("money")]
    public int Money { get; set; }

    [JsonProperty("trophy")]
    public int Trophy { get; set; }

    [JsonProperty("selectCar")]
    public string SelectCar { get; set; }

    [JsonProperty("selectMap")]
    public string SelectMap { get; set; }
    
    [JsonProperty("CarData")]
    public ReadOnlyCollection<CarDataDescriptor> CarDatas { get; set; }

    [JsonProperty("FurnitureData")]
    public ReadOnlyCollection<FurnitureDataDescriptor> FurnitureData { get; set; }
}
