using UnityEngine;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

public class ProbsDescriptor : BaseDescriptor {

    public class Car : BaseDescriptor
    {
        [JsonProperty("prob")]
        public string Prob { get; private set; }

        [JsonProperty("value")]
        public float Value { get; private set; }
    }

    public class Furniture : BaseDescriptor
    {
        [JsonProperty("prob")]
        public string prob { get; private set; }

        [JsonProperty("value")]
        public float Value { get; private set; }
    }


    [JsonProperty("Car")]
    public ReadOnlyCollection<Car> cars { get; private set; }

    [JsonProperty("Furniture")]
    public ReadOnlyCollection<Furniture> furnitures { get; private set; }
}