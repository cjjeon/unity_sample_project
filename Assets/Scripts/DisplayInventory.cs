using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public GameObject inventoryItemUI;
    public InventoryObject inventory;

    private int NUM_OF_COLUMNS = 6;
    private Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateDisplay()
    {
        itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
        
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var inventorySlot = inventory.Container[i];
            
            var row = i / NUM_OF_COLUMNS;
            var column = i % NUM_OF_COLUMNS;
            
            var rowChild = transform.GetChild(row);
            var item = rowChild.transform.GetChild(column);
            item.GetChild(1).transform.GetComponentInChildren<Image>().sprite = inventorySlot.item.image;
            if (inventorySlot.amount > 1)
            {
                var textMesh = item.GetChild(2).GetComponent<TMP_Text>();
                if (textMesh)
                    textMesh.text = inventorySlot.amount.ToString();
            }
            
            Debug.Log("Slot: " + i + ", Row: " + row + ", COLUMN: " + column);
            // var obj = Instantiate(inventoryItemUI, Vector3.zero, Quaternion.identity, transform);
            // obj.transform.GetChild(1).GetComponentInChildren<Image>().sprite = inventorySlot.item.image;
            // itemsDisplayed.Add(inventorySlot, inventorySlot);
        }
    }
    
}
