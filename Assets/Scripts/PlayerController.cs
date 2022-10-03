using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] NavMeshAgent m_NavMeshAgent;

    private Animator m_Animator;
    public InventoryObject inventory;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_NavMeshAgent.remainingDistance <= m_NavMeshAgent.stoppingDistance)
        {
            m_Animator.SetFloat("Speed_f", 0);
        }
        else
        { 
            m_Animator.SetFloat("Speed_f", m_NavMeshAgent.remainingDistance);
        }
    }

    public void Move(Vector3 point)
    {
        m_NavMeshAgent.SetDestination(point);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide: ", other);
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.itemObject, 1);
            Destroy(other.gameObject);
        }
    }
}
