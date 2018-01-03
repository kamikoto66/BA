using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollButton : UI
{
    public Sprite OpenButton;
    public Sprite CloseButton;

    private Animator animator;
    private Image InventoryImage;
    private Button scrollButton;

    // Use this for initialization
    void Start()
    {
        InventoryImage = GetComponent<Image>();
        animator = GetComponent<Animator>();
        scrollButton = GetComponent<Button>();

        UIHelper.AddButtonListener(Vars["Furniture"], () => {
            SoundManager.Instance.PlaySound(0);

            GameObject.Find("FurnitureInventory").GetComponent<FurnitureInventory>().OpenInventory();
            animator.SetTrigger("MoveRight");
            scrollButton.interactable = false;
        });
        UIHelper.AddButtonListener(Vars["Car"], () =>
        {
            SoundManager.Instance.PlaySound(0);

            GameObject.Find("CarInventory").GetComponent<CarInventory>().OpenInventory();
            animator.SetTrigger("MoveRight");
            scrollButton.interactable = false;
        });
    }

    public void OnChick()
    {
        SoundManager.Instance.PlaySound(0);

        if (HomeSceneManager.instance.modelState == ModelState.eNone)
        {
            if (animator.GetBool("Right"))
                animator.SetTrigger("MoveLeft");
            else if (animator.GetBool("Left"))
                animator.SetTrigger("MoveRight");
        }
    }

    public void ChangeImageOpenButton()
    {
        InventoryImage.sprite = OpenButton;
        animator.SetBool("Left", false);
        animator.SetBool("Right", true);
    }

    public void ChangeImageCloseButton()
    {
        InventoryImage.sprite = CloseButton;
        animator.SetBool("Left", true);
        animator.SetBool("Right", false);
    }
}
