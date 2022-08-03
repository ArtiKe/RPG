using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnManager : MonoBehaviour 
{
    [Header("[Player Respawn Settings]")]
    public GameObject playerPrefab;
    public GameObject DeathUI;
    public Transform respawnSpot;

    public void LateUpdate()
    {
       
        float time = DeathUI.GetComponentInChildren<ProgressBar>().currentPercent;

       
        if (time >= 100f)
        {
            
            time = 100f;

           
            DeathUI.transform.Find("RespawnButton").GetComponent<Button>().interactable = true;
        }
    }

    public void DoPlayerRespawn()
    {
        
        GameObject newPlayer = Instantiate(playerPrefab, respawnSpot.position, Quaternion.identity) as GameObject;

        
        Camera.main.GetComponent<CameraController>().target = newPlayer.transform;

       
        Destroy(GameObject.FindGameObjectWithTag("Player"));

        
        DeathUI.transform.Find("RespawnButton").GetComponent<Button>().interactable = false;
        DeathUI.GetComponentInChildren<ProgressBar>().currentPercent = 0;
        DeathUI.SetActive(false);

       
        Debug.LogFormat("Respawn Player {0}", newPlayer.name);
    }

    public void DoEnemyRespawn(GameObject enemyPrefab, Vector3 respawnSpot, Quaternion respawnRotation, GameObject oldEnemy)    
    {
       
        GameObject newEnemy = Instantiate(enemyPrefab, respawnSpot, respawnRotation) as GameObject;

        
        Destroy(oldEnemy);

      
        Debug.LogFormat("Respawn Enemy {0}", newEnemy.name);
    }
}
