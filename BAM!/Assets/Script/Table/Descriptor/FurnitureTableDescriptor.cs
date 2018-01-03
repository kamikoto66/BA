using UnityEngine;
using Newtonsoft.Json;
using System.Collections.ObjectModel;


public class FurnitureTableDescriptor : BaseDescriptor
{
    public class BuffGroupDescriptor
    {
        [JsonProperty("buff")]
        public string buff { get; private set; }
    }

    [JsonProperty("name")]
    public string Name { get; private set; }

    [JsonProperty("probabilty")]
    public string Probabilty { get; private set; }

    [JsonProperty("dur")]
    public int Dur { get; private set; }

    [JsonProperty("description")]
    public string Description { get; private set; }

    [JsonProperty("path")]
    public string Path { get; private set; }

    [JsonProperty("imagePath")]
    public string ImagePath { get; private set; }

    [JsonProperty("BuffGroup")]
    public ReadOnlyCollection<BuffGroupDescriptor> BuffGroup { get; private set; }
}

