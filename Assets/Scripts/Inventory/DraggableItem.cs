using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    public InventorySlot MySlot;



    public void OnBeginDrag(PointerEventData eventData)
    {
        if (MySlot.item.type == Item.itemType.Stackable)
        {
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
            MySlot.GettingDragged = true;
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (MySlot.item.type == Item.itemType.Stackable)
        {
            transform.position = Input.mousePosition;
            MySlot.GettingDragged = true;
        }
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        MySlot.GettingDragged = false;
        SpawnItemAtMousePosition();
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 screenPosition = Input.mousePosition;
        screenPosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(screenPosition);
    }

    private void SpawnItemAtMousePosition()
    {
       /* Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (MySlot.item.prefab != null)
            {
                Instantiate(MySlot.item.prefab, hit.point, Quaternion.identity);
                MySlot.item.RemoveFromInventory();
            }
        }
        else
        {
            Debug.Log("No valid surface detected to place the item.");
        }*/
    }
}
