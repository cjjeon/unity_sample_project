using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    [SerializeField] private PlayerController m_player;
    [SerializeField] private GameObject m_Effect;

    public GameObject[] gameObjects;
    private GameObject _pendingGameObject;
    private RaycastHit hit;
    
    private void Update()
    {
        bool isClick = Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject();
        if (_pendingGameObject != null)
        {
            _pendingGameObject.transform.position = hit.point;
        }
        
        if (isClick && hit.collider != null)
        {
            
            if (_pendingGameObject != null)
            {
                Debug.Log("Placed Object");
                PlaceObject();
            }
            else
            {
                IClicked clicked =  hit.collider.GetComponent<IClicked>();
                if (clicked != null)
                {
                    Debug.Log("Object Clicked");
                    // Delete a character that's hit
                    clicked.onClickAction();
                    
                    // Create Blink Effect once Object is destroyed
                    Instantiate(m_Effect, hit.transform.position, hit.transform.rotation);
                }

                BoxCollider boxCollider = hit.collider.GetComponent<BoxCollider>();
                if (boxCollider != null && boxCollider.tag == "Ground")
                {
                    Debug.Log("Ground Clicked");
                    m_player.Move(hit.point);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, 1000);
    }

    private void PlaceObject()
    {
        _pendingGameObject = null;
    }
    
    public void SelectObject(int index)
    {
        _pendingGameObject = Instantiate(gameObjects[index], hit.point, transform.rotation);
    }
}
