using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Equipment")]
public class Equipment : Item {

	public EquipmentSlot equipSlot;		
	public int armorModifier;
	public int damageModifier;

    public override Item Clone()
    {
        Equipment clone = ScriptableObject.Instantiate(this) as Equipment;
        return clone;
    }

    public override void Use ()
	{
		EquipmentManager.instance.Equip(this);	
		RemoveFromInventory();
	}

}

public enum EquipmentSlot { Head, Chest, L_Hand, R_Hand, Legs,  Feet}
