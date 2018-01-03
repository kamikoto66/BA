using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoData : MonoBehaviour {

    public Text ItemName;
    public Text ItemDescription;
    public Image ItemIcon;

    public Image[] ItemIcons;

    private FurnitureInfo info;

    public void ChangeItemData(FurnitureInfo info)
    {
        if (this.info == info)
            return;
        else if(this.info != info)
        {
            ItemName.text = info.ItemName;
            ItemDescription.text = info.Description;
        }
    }
}
