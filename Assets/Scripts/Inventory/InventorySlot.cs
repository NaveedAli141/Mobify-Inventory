using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class InventorySlot : MonoBehaviour, IDropHandler
{

    public Image icon;
    public Button removeButton;

    public GameObject CountIcon;
    public Text count;

    public Item item;

    public Transform UseButton;

    public int Size;
    public int maxSize;

    [HideInInspector] public bool GettingDragged;

    public void AddItem(Item newItem)
    {
        item = newItem;
        maxSize = item.MaxSize;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.gameObject.SetActive(!item.Default);
        removeButton.interactable = !item.Default;
        if (item.type == Item.itemType.Stackable)
        {
            CountIcon.SetActive(true);
            Size = item.Size;
            count.text = Size.ToString();
        }
    }
    void UpdateCount()
    {
        count.text = Size.ToString();
    }
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        CountIcon.SetActive(false);
        item = null;
        Size = 0;
        count.text = "";        
    }

    public void RemoveItemFromInventory()
    {
        Inventory.instance.Remove(item);
    }


    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        if (draggableItem.MySlot.item.type == Item.itemType.Stackable  && Size < maxSize && GettingDragged == false && item != null && item.type == Item.itemType.Stackable)
        {
            Size = draggableItem.MySlot.Size + Size;
            item.Size = Size;
            UpdateCount();
            draggableItem.MySlot.RemoveItemFromInventory();
        }
    }
}
