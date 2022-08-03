using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class BanditsDie : MonoBehaviour
{
    public CharacterStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats.OnHealthReachedZero += Banditsdir;
    }

    public void Banditsdir()
    {
        SkeletonQuest.banditsLives++;
    }
}
