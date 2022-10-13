using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    [Tooltip("List of Items")]
    public List<ItemScriptableObject> itemsAvailable;

    [Tooltip("Number of spawn items for inventory")]
    public int numberOfItems = 5;

    [Tooltip("Items Selection Panel")]
    public GameObject itemsSelectionPanel;

    private List<InventoryItem> itemsForPlayer; //the items that the player can use during the game

    // Start is called before the first frame update
    void Start()
    {
        itemsForPlayer = new List<InventoryItem>();
        PopulateInventorySystem();
        RefreshInventorySystemGUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshInventorySystemGUI()
    {
        int buttonId = 0;

        foreach(InventoryItem item in itemsForPlayer)
        {
            //load the button
            GameObject button = itemsSelectionPanel.transform.Find("Button" + buttonId).gameObject;

            //search for the child image and change its sprite (the inventory item sprite)
            button.transform.Find("Image").GetComponent<Image>().sprite = item.item.icon;

            //change the quantity text label
            button.transform.Find("Quantity").GetComponent<TextMeshProUGUI>().text = "x" + item.quantity;

            //move to the next button
            buttonId += 1;
        }

        //set active false redundant buttons
        for(int i= buttonId; i < 3; i++)
        {
            itemsSelectionPanel.transform.Find("Button" + i).gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// This method is going to randomly pick items from the list itemsAvailable
    /// and we are going to store these items in the list itemsForPlayer.
    /// These items later on will be used by the player during the game.
    /// </summary>
    private void PopulateInventorySystem()
    {
        for(int i = 0; i < numberOfItems; i++)
        {
            //pick random object from itemsAvailable
            ItemScriptableObject objItem = itemsAvailable[Random.Range(0, itemsAvailable.Count)];

            //check whether objItem exists in itemsForPlayer. If it exists, we need to increase
            //the quantity value by 1. So basically we are grouping items if they are of
            //the same inventory type. For example, group basic mana together, group basic health
            //together & group full health together by changing the quantity value
            int countItems = itemsForPlayer.Where(x => x.item == objItem).ToList().Count;

            if(countItems == 0)
            {
                //add item in array itemsForPlayer so that they can be used by the player
                //technique 1
                //InventoryItem inventoryItem = new InventoryItem();
                //inventoryItem.item = objItem;
                //inventoryItem.quantity = 1;
                //itemsForPlayer.Add(inventoryItem);

                //technique 2 (shorter)
                itemsForPlayer.Add(new InventoryItem() { item = objItem, quantity = 1 });
            }
            else
            {
                //search inside itemsForPlayer for an element exactly like objItem
                var item = itemsForPlayer.First(a => a.item == objItem);
                //modify and increase quantity
                item.quantity += 1;
            }
        



        }
    }

    public class InventoryItem
    {
        public ItemScriptableObject item { get; set; }
        public int quantity { get; set; }
    }
}
