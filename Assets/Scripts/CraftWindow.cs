using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftWindow : MonoBehaviour
{
    public InventoryObject inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector2.zero;
    }

    public void Open()
    {
        transform.LeanScale(Vector2.one, 0.1f);
    }
    
    public void Close()
    {
        transform.LeanScale(Vector2.zero, 0.2f).setEaseInBack();
    }
}
