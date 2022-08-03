using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    private int dialogIndex;

    private void SelectedDialog(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == _index);
    }


    public void NextDialog(int _change)
    {
        dialogIndex += _change;
        SelectedDialog(dialogIndex);

    }
}
