using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerStats : CharacterStats
{
    public Stat maxHunger;         
    public int currentHunger { get; protected set; }    

    public Stat maxThirsty;          
    public int currentThirsty { get; protected set; }    

    public event System.Action OnHungerReachedZero;
    public event System.Action OnThirstyhReachedZero;

   
    public override void Start ()
    {
		base.Start();

        currentHunger = maxHunger.GetValue();
        currentThirsty = maxThirsty.GetValue();

        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}

	void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
	{
		if (newItem != null) {
			armor.AddModifier (newItem.armorModifier);
			damage.AddModifier (newItem.damageModifier);
		}

		if (oldItem != null)
		{
			armor.RemoveModifier(oldItem.armorModifier);
			damage.RemoveModifier(oldItem.armorModifier);
		}
	}

    public void SurvivalDamage(int damage, string type)
    {
        if (type.Equals("Hunger"))
        {
           
            currentHunger -= damage;
            Debug.Log(transform.name + " takes " + damage + " hunger.");

          
            if (currentHunger <= 0)
            {
                if (OnHungerReachedZero != null)
                {
                    OnHungerReachedZero();
                }
            }
        }

        if (type.Equals("Thirsty"))
        {
         
            currentThirsty -= damage;
            Debug.Log(transform.name + " takes " + damage + " thirsty.");

           
            if (currentThirsty <= 0)
            {
                if (OnThirstyhReachedZero != null)
                {
                    OnThirstyhReachedZero();
                }
            }
        }
    }

   
    public void HealHunger(int amount)
    {
        currentHunger += amount;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger.GetValue());
    }

    
    public void HealThirsty(int amount)
    {
        currentThirsty += amount;
        currentThirsty = Mathf.Clamp(currentThirsty, 0, maxThirsty.GetValue());
    }
}
