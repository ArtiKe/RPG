using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Consumable")]
public class Consumable : Item {

	public int healthGain;		
    public int hungerGain;		
    public int thirstyGain;      

    
    public override void Use()
	{
		
		PlayerStats playerStats = Player.instance.playerStats;

        if (healthGain > 0)
		    playerStats.Heal(healthGain);

        if (hungerGain > 0)
            playerStats.HealHunger(hungerGain);

        if (thirstyGain > 0)
            playerStats.HealThirsty(thirstyGain);

        Debug.Log(name + " consumed!");

		RemoveFromInventory();	
	}

}
