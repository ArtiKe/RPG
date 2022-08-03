using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable {
   
    [Header("[Enemy Respawn Settings]")]
    public string prefabName = "";
    public float respawnTime = 10f;
    public Vector3 respawnSpot;
    public Quaternion respawnRotation;

    [Header("[Enemy Stats Settings]")]
    public CharacterStats stats;

    [Header("[Enemy Loot Settings]")]
    public int minGoldGive = 100;
    public int maxGoldGive = 1000;
    public Transform lootPosition;
    public GameObject[] loots;

    void Start ()
	{      
       
        respawnSpot = gameObject.transform.position;
        respawnRotation = gameObject.transform.rotation;

        
		stats = GetComponent<CharacterStats>();
		stats.OnHealthReachedZero += Die;
    }

	
	public override void Interact()
	{
		Debug.Log("Interact");
        CharacterCombat combatManager = Player.instance.playerCombatManager;
		combatManager.Attack(stats);
	}

    IEnumerator CallRespawnFunction()
    {
        
        Debug.LogFormat("Enemy {0} Dead", gameObject.name);

       
        gameObject.GetComponent<CapsuleCollider>().enabled = false;

       
        yield return new WaitForSeconds(respawnTime);

        
        GameObject enemyPrefab = Resources.Load("Prefabs/NPCs/" + prefabName, typeof(GameObject)) as GameObject;

        
        GameObject.Find("GameManager").GetComponent<RespawnManager>().DoEnemyRespawn(enemyPrefab, respawnSpot, respawnRotation, gameObject);
    }

    void Die()
    {
      
        Player.instance.GetComponent<CharacterCombat>().Normal();
        Player.instance.GetComponent<PlayerController>().focus = null;
        Player.instance.GetComponent<CharacterCombat>().healthSlider.gameObject.SetActive(false);

        
        GetComponent<EnemyController>().target = null;

        
        GetComponent<CharacterCombat>().Death();

        
        GetComponent<CharacterCombat>().healthSlider.gameObject.SetActive(false);

      
        DropLoot();

        
        StartCoroutine(CallRespawnFunction());

       
	}

    void DropLoot()
    {
        
        int goldValue = Random.Range(minGoldGive, maxGoldGive);
        GameObject.Find("GameManager").GetComponent<Inventory>().gold += goldValue;

       
        int lootIndex = Random.Range(0, loots.Length);
        GameObject currentLoot = loots[lootIndex];

        Instantiate(currentLoot, lootPosition.position, Quaternion.identity);
        Debug.Log("Drop Loot: " + currentLoot.name + ", Gold Drop: " + goldValue);
    }

}
