using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStats))]
public class SceletonDie : MonoBehaviour
{
    public CharacterStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats.OnHealthReachedZero += Sceletondir;
    }

    public void Sceletondir()
    {
        SkeletonQuest.skeletonsLives++;
    }
}
