using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour, IClicked
{
    [SerializeField] string m_name;
    
    public void onClickAction()
    {
        Vector3 position = transform.position;
        position.x += m_name.Length / 2;
        foreach (char c in m_name)
        {
            position.x += -1.1f;
            Instantiate(
            Resources.Load("Alphabets/" + c),
            position,
            transform.rotation
        );   
        }
        Destroy(gameObject);
    } 
}
