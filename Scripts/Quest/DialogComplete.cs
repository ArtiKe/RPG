using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogComplete : MonoBehaviour
{
    private int completeDialog;
    private void CompleteDialog(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == _index);
    }

    public void NextComplete(int _change)
    {
        completeDialog += _change;
        CompleteDialog(completeDialog);

    }
}
