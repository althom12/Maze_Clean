using SenmagHaptic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterDoor : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponentInParent<Senmag_HapticCursor>() || other.gameObject.tag == "Door")
        {
            gameObject.transform.GetChild(0).GetChild(0).localEulerAngles = new Vector3(0, -75f, 0);
        }

    }

    void Update()
    {
        
    }
}
