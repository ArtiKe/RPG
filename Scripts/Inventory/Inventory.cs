using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	#region Singleton

	public static Inventory instance;

	void Awake ()
	{
		instance = this;
	}

	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 10;	

	
	public List<Item> items = new List<Item>();

    public int gold;

    private void Update()
    {
        
        GameObject inventoryUI = GameObject.Find("Canvas").transform.Find("Inventory").gameObject;
        if(inventoryUI.activeSelf)
            inventoryUI.transform.Find("Gold").Find("Value").GetComponent<Text>().text = gold.ToString();

    }

   
    public void Add (Item item)
	{
		if (item.showInInventory) {
			if (items.Count >= space) {
				Debug.Log ("Not enough room.");
				return;
			}

			items.Add (item);

			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke ();
		}
	}

	
	public void Remove (Item item)
	{
		items.Remove(item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

}
