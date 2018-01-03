using Newtonsoft.Json;
using System.Collections.ObjectModel;
using UnityEngine;

public class AnimalDataDescriptor : BaseDescriptor {

	[JsonProperty("name")]
    public string Name { get; private set; }

    [JsonProperty("hp")]
    public int Hp { get; private set; }

    [JsonProperty("speed")]
    public int Speed { get; private set; }

    [JsonProperty("maxSpeed")]
    public int MaxSpeed { get; private set; }

    [JsonProperty("path")]
    public string Path { get; private set; }
}
