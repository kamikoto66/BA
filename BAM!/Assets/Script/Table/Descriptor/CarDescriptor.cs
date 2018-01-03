using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class CarDescriptor : BaseDescriptor {

    [JsonProperty("modelPath")]
    public string ModelPath { get; private set; }

    [JsonProperty("imagePath")]
    public string ImagePath { get; private set; }

    [JsonProperty("speed")]
    public int Speed { get; private set; }

    [JsonProperty("maxSpeed")]
    public int MaxSpeed { get; private set; }

    [JsonProperty("hp")]
    public int Hp { get; private set; }

    [JsonProperty("prefabPath")]
    public string prefabPath { get; private set; }

}
