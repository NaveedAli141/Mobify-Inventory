using System.Diagnostics;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;
    public bool showInInventory = true;
    public bool Default;
    public itemType type;
    public GameObject prefab;

    public enum itemType { NonStackable, Stackable };

    public int Size;
    public int MaxSize;

    public virtual void Use()
    {

    }
    public virtual Item Clone()
    {
        Item clone = ScriptableObject.Instantiate(this);
        return clone;
    }
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);

    }

}
