using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Runtime.Serialization;

public class BaseDescriptor : MonoBehaviour {

    [JsonProperty("id")]
    public string Id { get; private set; }

    [OnDeserialized()]
    public void OnDeserialized(StreamingContext context)
    {
        CheckIntegrity();
    }

    public virtual void CheckIntegrity()
    {
    }
}
