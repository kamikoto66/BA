using UnityEngine;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

public class MapDataDescriptor : BaseDescriptor {

    [JsonProperty("name")]
    public string Name { get; private set; }

    [JsonProperty("time")]
    public string Time { get; private set; }

    [JsonProperty("level")]
    public string Level { get; private set; }

    [JsonProperty("award")]
    public string Award { get; private set; }

    //[JsonProperty("count")]
    //public string Count { get; private set; }
}
