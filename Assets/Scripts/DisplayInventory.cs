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
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        }
        
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var inventorySlot = inventory.Container[i];
            GameObject obj = Instantiate(inventoryItemUI, transform);

            obj.transform.Find("Image").GetComponent<Image>().sprite = inventorySlot.item.image;
            if (inventorySlot.amount > 1)
            {
                var textMesh = obj.transform.Find("Amount").GetComponent<TMP_Text>();
                if (textMesh)
                    textMesh.text = inventorySlot.amount.ToString();
            }
        }
    }
    
}
