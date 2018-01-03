using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxBase : UI {

    public Animator _PopUp;
    public BoxType _Type { get; set; }

    public enum BoxType
    {
        FurnitureBox,
        CarBox
    }

    public virtual void Init() { }
    public virtual void Buy() { }
}
