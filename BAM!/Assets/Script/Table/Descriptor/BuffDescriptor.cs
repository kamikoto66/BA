using UnityEngine;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

public class BuffDescriptor : BaseDescriptor
{
    public class BuffEffect 
    {
        [JsonProperty("level")]
        public int Level { get; private set; }

        [JsonProperty("type")]
        public int Type { get; private set; }

        [JsonProperty("value")]
        public int Value { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }
    }

    [JsonProperty("name")]
    public string Name { get; private set; }

    [JsonProperty("Effect")]
    public ReadOnlyCollection<BuffEffect> Effects { get;  private set;}
}