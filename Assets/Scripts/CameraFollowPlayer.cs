using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform m_CharacterTransform;
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = m_CharacterTransform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_CharacterTransform)
        {
            transform.position = m_CharacterTransform.position - offset;
        }
    }
}
