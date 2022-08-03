using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class AnimalsDie : MonoBehaviour
{
    public CharacterStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats.OnHealthReachedZero += Animalsdir;
    }

    public void Animalsdir()
    {
        SkeletonQuest.animalsLives++;
    }
}
