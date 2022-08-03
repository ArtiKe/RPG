using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieMan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SkeletonQuest.completeCQ = true;
        }
        
    }
}
