using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class SurvivalSystem : MonoBehaviour
{
   
    GameObject canvas;

    
    [Header("[Hunger Settings]")]
    public float hungerDelay = 60f;
    public int hungerDamage = 1;
    Coroutine hungerCoroutine;

   
    bool hungerLevel1;
    bool hungerLevel2; 
    bool hungerLevel3;

    [Header("[Thirsty Settings]")]
    public float thirstyDelay = 90f;
    public int thirstyDamage = 1;
    Coroutine thirstyCoroutine;

    
    bool thirstyLevel1;
    bool thirstyLevel2;
    bool thirstyLevel3;

   
    PlayerStats myStats;

    void Start()
    {
       
        canvas = GameObject.Find("Canvas");

       
        myStats = GetComponent<PlayerStats>();

       
        canvas.transform.Find("VitalslUI").Find("HealthSlider").GetComponent<Slider>().maxValue = myStats.maxHealth.GetValue();
        canvas.transform.Find("VitalslUI").Find("HealthSlider").GetComponent<Slider>().value = myStats.currentHealth;

        canvas.transform.Find("VitalslUI").Find("HungerSlider").GetComponent<Slider>().maxValue = myStats.maxHunger.GetValue();
        canvas.transform.Find("VitalslUI").Find("HungerSlider").GetComponent<Slider>().value = myStats.currentHunger;

        canvas.transform.Find("VitalslUI").Find("ThirstySlider").GetComponent<Slider>().maxValue = myStats.maxThirsty.GetValue();
        canvas.transform.Find("VitalslUI").Find("ThirstySlider").GetComponent<Slider>().value = myStats.currentThirsty;


        
        hungerCoroutine = StartCoroutine(DoHungerDamage(hungerDelay));
        thirstyCoroutine = StartCoroutine(DoThirstyDamage(thirstyDelay));
    }

    void Update()
    {
      
        canvas.transform.Find("VitalslUI").Find("HealthSlider").GetComponent<Slider>().value = myStats.currentHealth;
        canvas.transform.Find("VitalslUI").Find("HungerSlider").GetComponent<Slider>().value = myStats.currentHunger;
        canvas.transform.Find("VitalslUI").Find("ThirstySlider").GetComponent<Slider>().value = myStats.currentThirsty;

        
        if (myStats.currentHunger <= 75 && myStats.currentHunger > 50 && !hungerLevel1)
        {
            
            string[] messages = { "I want to eat something", "I'm feeling hungry", "I feel hungry", "My stomach grumbles"};

            
            int index = Random.Range(0, messages.Length - 1);
            string getMessage = messages[index];

           
            canvas.transform.Find("Notifications").Find("HungerPopNot").Find("Description").GetComponent<Text>().text = getMessage;
            canvas.transform.Find("Notifications").Find("HungerPopNot").gameObject.SetActive(true);     
            
            
            Debug.Log(getMessage);

           
            hungerLevel1 = true;
        }
        else if(myStats.currentHunger <= 50 && myStats.currentHunger > 25 && !hungerLevel2)
        {
            
            string[] messages = { "I'm extremely hungry", "My stomach grumbled violently", "I'm starving"};

            
            int index = Random.Range(0, messages.Length - 1);
            string getMessage = messages[index];

            
            canvas.transform.Find("Notifications").Find("HungerPopNot").Find("Description").GetComponent<Text>().text = getMessage;

            
            canvas.transform.Find("Notifications").Find("HungerPopNot").gameObject.SetActive(false);
            canvas.transform.Find("Notifications").Find("HungerPopNot").gameObject.SetActive(true);

            
            Debug.Log(getMessage);

           
            hungerLevel2 = true;
        }
        else if(myStats.currentHunger <= 25 && myStats.currentHunger > 0 && !hungerLevel3)
        {
            
            string[] messages = { "I'm dying of starvation"};

            
            int index = Random.Range(0, messages.Length - 1);
            string getMessage = messages[index];

          
            canvas.transform.Find("Notifications").Find("HungerPopNot").Find("Description").GetComponent<Text>().color = Color.red;
            canvas.transform.Find("Notifications").Find("HungerPopNot").Find("Description").GetComponent<Text>().text = getMessage;

            
            canvas.transform.Find("Notifications").Find("HungerPopNot").gameObject.SetActive(false);
            canvas.transform.Find("Notifications").Find("HungerPopNot").gameObject.SetActive(true);

            
            Debug.Log(getMessage);

            
            hungerLevel3 = true;
        }
        else if (myStats.currentHunger <= 0)
        {
            
            string message = "Hunger Death";

            
            Debug.Log(message);

           
            StopCoroutine(hungerCoroutine);
            StopCoroutine(thirstyCoroutine);
        }

        
        if (myStats.currentThirsty <= 75 && myStats.currentThirsty > 50 && !thirstyLevel1)
        {
           
            string[] messages = { "I feel thirsty", "I'm thirsty", "I need a drink", "I feel like having a drink" };

           
            int index = Random.Range(0, messages.Length - 1);
            string getMessage = messages[index];

            
            canvas.transform.Find("Notifications").Find("ThirstyPopNot").Find("Description").GetComponent<Text>().text = getMessage;
            canvas.transform.Find("Notifications").Find("ThirstyPopNot").gameObject.SetActive(true);

           
            Debug.Log(getMessage);

           
            thirstyLevel1 = true;
        }
        else if (myStats.currentThirsty <= 50 && myStats.currentThirsty > 25 && !thirstyLevel2)
        {
           
            string[] messages = { "I want to drink something", "I really need to drink"};

            
            int index = Random.Range(0, messages.Length - 1);
            string getMessage = messages[index];

           
            canvas.transform.Find("Notifications").Find("ThirstyPopNot").Find("Description").GetComponent<Text>().text = getMessage;

           
            canvas.transform.Find("Notifications").Find("ThirstyPopNot").gameObject.SetActive(false);
            canvas.transform.Find("Notifications").Find("ThirstyPopNot").gameObject.SetActive(true);

           
            Debug.Log(getMessage);

         
            thirstyLevel2 = true;
        }
        else if (myStats.currentThirsty <= 25 && myStats.currentThirsty > 0 && !thirstyLevel3)
        {
           
            string[] messages = { "I'm dying of dehydration" };

           
            int index = Random.Range(0, messages.Length - 1);
            string getMessage = messages[index];

          
            canvas.transform.Find("Notifications").Find("ThirstyPopNot").Find("Description").GetComponent<Text>().color = Color.red;
            canvas.transform.Find("Notifications").Find("ThirstyPopNot").Find("Description").GetComponent<Text>().text = getMessage;

           
            canvas.transform.Find("Notifications").Find("ThirstyPopNot").gameObject.SetActive(false);
            canvas.transform.Find("Notifications").Find("ThirstyPopNot").gameObject.SetActive(true);

          
            Debug.Log(getMessage);

           
            thirstyLevel3 = true;
        }
        else if (myStats.currentThirsty <= 0)
        {
            
            string message = "Thirsty Death";

            
            Debug.Log(message);

           
            StopCoroutine(hungerCoroutine);
            StopCoroutine(thirstyCoroutine);
        }
    }

    IEnumerator DoHungerDamage(float delay)
    {
        Debug.Log("Start survival damage system");
        while (true)
        {      
            yield return new WaitForSeconds(delay);
            myStats.SurvivalDamage(hungerDamage, "Hunger");
        }   
    }

    IEnumerator DoThirstyDamage(float delay)
    {
        Debug.Log("Start survival damage system");
        while (true)
        {
            yield return new WaitForSeconds(delay);
            myStats.SurvivalDamage(thirstyDamage, "Thirsty");
        }  
    }
}
