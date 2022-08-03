using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This resorts combat for all characters. */

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

	public float attackRate = 1f;
	private float attackCountdown = 0f;

	public event System.Action OnAttack;
    public event System.Action OnBattle;
    public event System.Action OnNormal;
    public event System.Action OnDeath;

    CharacterStats myStats;
	CharacterStats enemyStats;

    public Slider healthSlider;

	void Start ()
	{
       
		myStats = GetComponent<CharacterStats>();

       
        healthSlider.maxValue = myStats.maxHealth.GetValue();
        healthSlider.value = myStats.currentHealth;
    }

	void Update ()
	{
        
        if (myStats.currentHealth <= 0)
            return;

        
        healthSlider.value = myStats.currentHealth;

       
        attackCountdown -= Time.deltaTime;
	}

	public void Attack (CharacterStats enemyStats)
	{
		if (attackCountdown <= 0f)
		{
			this.enemyStats = enemyStats;
			attackCountdown = 1f / attackRate;

			StartCoroutine(DoDamage(enemyStats,.6f));

			if (OnAttack != null) {
				OnAttack ();
			}
		}
	}

    public void Battle()
    {
        if (OnBattle != null)
            OnBattle();
    }

    public void Normal()
    {
        if (OnNormal != null)
            OnNormal();
    }

    public void Death()
    {
        if (OnDeath != null)
            OnDeath();
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
		Debug.Log("Start combat damage system");
		yield return new WaitForSeconds (delay);

		Debug.Log (transform.name + " attacking for " + myStats.damage.GetValue () + " damage");
		enemyStats.TakeDamage (myStats.damage.GetValue ());
	}
}
