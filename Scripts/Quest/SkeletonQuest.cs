using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonQuest : MonoBehaviour
{
    [Header("[Quest Book]")]
    public TMPro.TextMeshProUGUI q1;
    public TMPro.TextMeshProUGUI q1LivesSkeletons;
    public TMPro.TextMeshProUGUI q2;
    public TMPro.TextMeshProUGUI q2CompleteText;
    public TMPro.TextMeshProUGUI q3;
    public TMPro.TextMeshProUGUI q3AnimalLives;
    public TMPro.TextMeshProUGUI q3CompleteText;
    public TMPro.TextMeshProUGUI q4;
    public TMPro.TextMeshProUGUI q4BantidsLives;
    public TMPro.TextMeshProUGUI q4CompleteText;


    
    [Header("[Manager Dialogs]")]
    public GameObject Dialog;
    public GameObject DialogComplete;
    public GameObject QuestPoint;
    

    [Header("[Quest Indexs]")]
    public int questIndex;
    public static int skeletonsLives;
    public static int animalsLives;
    public static int banditsLives;
    
   

    [Header("[Main Bool Setting]")]
    bool startSQ = false;
    bool StartQO = false;
    bool StartFQ;
    bool StartBQ;

    bool completeSQ = false;
    public static bool completeCQ = false;
    bool completeFQ = false;
    bool completeBQ = false;



    [Header("[MainVillage Loot Settings]")]
    public int minGoldGive = 100;
    public int maxGoldGive = 1000;
    public Transform lootPosition;
    public GameObject[] loots;


    private void Start()
    {
        questIndex = 0;
        skeletonsLives = 0;
        
    }
    void Update()
    {
        if(questIndex == 1) { 
        if (startSQ == true)
        {
                Dialog.SetActive(false);
                q1.gameObject.SetActive(true);
                q1LivesSkeletons.text = skeletonsLives.ToString();

            if (skeletonsLives == 5)
            {
                completeSQ = true;
                if (completeSQ == true)
                {
                       
                        q1.color =  Color.gray;
                        q1LivesSkeletons.text = skeletonsLives.ToString();

                    }
            }      
          }
        }

        if(questIndex == 3)
        {
            
            q2.gameObject.SetActive(true);
            if(StartQO == true)
            {
                
                if (completeCQ == true)
                {
                    q2.color = Color.gray;
                    q2CompleteText.gameObject.SetActive(true);
                }

            }
            

        }
        if (questIndex == 5)
        {
            if (StartFQ == true)
            {
                q3AnimalLives.text = animalsLives.ToString();
                q3.gameObject.SetActive(true);
                if(animalsLives == 4) { 
                if (completeFQ == true)
                {
                   
}                   q3.color = Color.gray;
                    q3CompleteText.gameObject.SetActive(true);
                }

            }


        }

        if (questIndex == 7)
        {
            if (StartBQ == true)
            {
                q4BantidsLives.text = banditsLives.ToString();
                q4.gameObject.SetActive(true);
                if (banditsLives == 4)
                {
                    completeBQ = true;
                    if (completeBQ == true)
                    {
                        q4.color = Color.gray;
                        q4CompleteText.gameObject.SetActive(true);
                    }
                    
                }

            }


        }

        if(questIndex == 8)
        {
            Dialog.SetActive(false);
            DialogComplete.SetActive(false);
            QuestPoint.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (questIndex == 0)
        {
            if (other.gameObject.tag == "Player")
            {
                if (completeSQ == false)
                {
                    Dialog.SetActive(true);
                }              
            }
        }

      if (questIndex == 1)
        {
            if (other.gameObject.tag == "Player")
            {
               if (completeSQ == true)
                {
                   
                    DialogComplete.SetActive(true);
                }
            }
        }

        if (questIndex == 2) {
            Dialog.SetActive(true);
            
        }
        if (questIndex == 3)
        {
            if (completeCQ == true)
            {
                
                DialogComplete.SetActive(true);
            }
        }
        if (questIndex == 4)
        {
            Dialog.SetActive(true);

        }

        if (questIndex == 5)
        {
            if (completeCQ == true)
            {

                DialogComplete.SetActive(true);
            }
        }
        if (questIndex == 6)
        {
            Dialog.SetActive(true);

        }

        if (questIndex == 7)
        {
            if (completeBQ == true)
            {

                DialogComplete.SetActive(true);
            }
        }



    }

    private void OnTriggerExit(Collider other)
    {
        if (questIndex == 0)
        {
            Dialog.SetActive(false);
        }

        if (questIndex == 1)
        {
            DialogComplete.SetActive(false);

            if (other.gameObject.tag == "Player")
            {
                if (completeSQ == false)
                {
                    Dialog.SetActive(false);
                    DialogComplete.SetActive(false);
                }
            }
        }
        if (questIndex == 2)
        {
            Dialog.SetActive(false);
        }
        if (questIndex == 3)
        {
            DialogComplete.SetActive(false);
        }
        if (questIndex == 4)
        {
            Dialog.SetActive(false);
        }
        if (questIndex == 5)
        {
            DialogComplete.SetActive(false);
        }
        if (questIndex == 6)
        {
            DialogComplete.SetActive(false);
            Dialog.SetActive(false);
        }
        if (questIndex == 7)
        {
            DialogComplete.SetActive(false);
        }
    }

    public void startQ()
    {
        startSQ = true;
        questIndex++;
    }
    public void startQ2()
    {
        StartQO = true;
        Dialog.SetActive(false);
        questIndex++;
    }

    public void startQ3()
    {
        StartFQ = true;
        Dialog.SetActive(false);
        questIndex++;
    }

    public void startQ4()
    {
        StartBQ = true;
        Dialog.SetActive(false);
        questIndex++;
    }



    public void MissionComplete()
    {
        DropLoot();
        questIndex++;
        DialogComplete.SetActive(false);
       
        Dialog.SetActive(true);
       

    }

   

    public void Mission2Comp()
    {
        DropLoot();
        questIndex++;
        DialogComplete.SetActive(false);
        
        Dialog.SetActive(true);

    }

    public void Mission3Comp()
    {
        DropLoot();
        questIndex++;
        DialogComplete.SetActive(false);
        
        Dialog.SetActive(true);

    }

    public void Mission4Comp()
    {
        DropLoot();
        questIndex++;
        DialogComplete.SetActive(false);

        Dialog.SetActive(true);

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
