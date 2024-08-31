using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{

    public GameObject inventoryUI;
    public Transform itemsParent;   

    Inventory inventory;    

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            UpdateUI();
            if (inventoryUI.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else 
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void UpdateUI()
    {
        InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

}
