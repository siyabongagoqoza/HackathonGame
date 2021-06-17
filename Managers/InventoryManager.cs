using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventorySlotContainer;
    [SerializeField] private Text descriptionText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;
    
    /*
        This method adds the items description to the desired box, if the item is usable it will display
        the "use" button. If the item is not usable it will not display any button.
    */
    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description;
        if (buttonActive)
        { 
            useButton.SetActive(true);


        } else
        {
            useButton.SetActive(false);
        }
    }

    /*
        This method is responsible for creating an inventory slot for each item found in the players invntory.
        It creates a slot from a prefab we import via the "blankInventorySlot", it uses the game object and pass
        the necessary data into their respective fields.
    */
    void MakeInventorySlot()
    {
        if (playerInventory)
        {
            for (int i = 0; i < playerInventory.myInventory.Count; i ++)
            {
                if (playerInventory.myInventory[i].numberHeld > 0)
                {
                    GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                    temp.transform.SetParent(inventorySlotContainer.transform);

                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();

                    if (newSlot)
                    {
                        newSlot.Setup(playerInventory.myInventory[i], this); // This is calling the Setup method from the inventorySlot.cs script
                
                    }
                }
            }
        }
    }

    // Once this game object gets enabled these method execute.
    void OnEnable()
    { 
        ClearInventorySlots();
        MakeInventorySlot();
        SetTextAndButton("", false);
    }
    
    public void SetupDescriptionAndButton(string newDescriptionString, bool isButtonUsable, InventoryItem newItem)
    {
       currentItem = newItem;
       descriptionText.text = newDescriptionString;
       useButton.SetActive(isButtonUsable);

    }
    
    void ClearInventorySlots()
    {
        for (int i = 0; i < inventorySlotContainer.transform.childCount; i++ )
        {
            Destroy(inventorySlotContainer.transform.GetChild(i).gameObject);
        }
    }

    public void UseButtonPressed()
    {
        if (currentItem)
        {
            currentItem.Use();
            
            //Clear All inventory slots
            ClearInventorySlots();
            
            //Refill slots with new numbers
            MakeInventorySlot();

            // The item will not display if the numberHeld is 0 or less.
            if (currentItem.numberHeld <= 0 )
            {
                SetTextAndButton("", false);
            }
            
        }
    }

    // This enable or disable the Inventory panel based on it's previous state.
    public void ToggleInventory()
    {
        if (inventoryPanel.activeInHierarchy != true)
        {
            inventoryPanel.SetActive(true);
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    // This decreases the desired item by one if the player used it.
    public void DropItem()
    {
        currentItem.numberHeld -= 1;
    }
}

