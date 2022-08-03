using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;



public class InventoryUI : MonoBehaviour {

	public GameObject inventoryUI;	
	public Transform itemsParent;   
	public GameObject Questbook;

	Inventory inventory;	

	void Start ()
	{
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;
	}

	
	void Update ()
	{
		if (Input.GetButtonDown("Inventory"))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
			UpdateUI();
		}
        if (Input.GetKeyDown(KeyCode.T))
        {
			Questbook.SetActive(!Questbook.activeSelf);
        }

		
		
	}

	
	public void UpdateUI ()
	{
		InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();

		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)
			{
				slots[i].AddItem(inventory.items[i]);
			} else
			{
				slots[i].ClearSlot();
			}
		}
	}

}
