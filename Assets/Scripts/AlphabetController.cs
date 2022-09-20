using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetController : MonoBehaviour
{
    [SerializeField] string character;
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        player.CollectAlphabet(character);
        Destroy(gameObject);
    }
}
