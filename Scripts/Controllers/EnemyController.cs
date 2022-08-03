using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(CharacterCombat))]
public class EnemyController : MonoBehaviour {

	public float lookRadius = 10f;

	public Transform target;
	NavMeshAgent agent;
	CharacterCombat combatManager;

	void Start()
	{
		target = Player.instance.transform;
		agent = GetComponent<NavMeshAgent>();
		combatManager = GetComponent<CharacterCombat>();
	}

	void Update ()
	{
       
        if (GetComponent<CharacterStats>().currentHealth <= 0)
            return;

       
        target = Player.instance.transform;
        if (target == null)
            return;

		
		float distance = Vector3.Distance(target.position, transform.position);

		
		if (distance <= lookRadius)
		{
			
			agent.SetDestination(target.position);
			if (distance <= agent.stoppingDistance)
			{
               
                GetComponent<CharacterCombat>().Battle();
                combatManager.healthSlider.gameObject.SetActive(true);

               
                if (Player.instance.playerStats.currentHealth > 0)
                {
                                 
                    combatManager.Attack(Player.instance.playerStats);
                    FaceTarget();
                }
                else
                {
                    
                    GetComponent<CharacterCombat>().Normal();
                    combatManager.healthSlider.gameObject.SetActive(false);
                    target = null;
                }               
			}
		}
	}

	
	void FaceTarget ()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}

}
