using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaneImpactSound : MonoBehaviour
{

    private GameObject senmagWorkspace;
    private GameObject defaultCursor;

    private bool firstTime = false;


    private void Start()
    {
        senmagWorkspace = GameObject.Find("SenmagWorkspace");
    }


    [Header("Wwise")]
    // Drag your cane impact Play Event from the Wwise Picker here.
    public AK.Wwise.Event ImpactEvent;

    [Header("Settings")]
    // A cooldown in seconds to prevent the sound from spamming.
    public float CooldownSeconds = 0.2f;

    // A private variable to track when the sound was last played.
    private float lastPlayTime = -1f;

    // This is a built-in Unity function that is automatically called
    // when this object's collider hits another object's collider.
    //private void OnCollisionEnter(Collision collision)
    //{
    //    // Check if enough time has passed since the last sound was played.
    //    if (Time.time >= lastPlayTime + CooldownSeconds)
    //    {
    //        // If the cooldown has passed, update the last play time to now.
    //        lastPlayTime = Time.time;

    //        // Post the Wwise Event to play the sound from this cane's location.
    //        ImpactEvent.Post(gameObject);
    //    }
    //}

    private void Update()
    {
        if (senmagWorkspace.transform.GetChild(0).GetChild(1) == null || senmagWorkspace.transform.childCount == 0)
        {
            return;
        }

        if (!firstTime)
        {
            defaultCursor = senmagWorkspace.transform.GetChild(0).GetChild(1).gameObject;

            firstTime = true;
        }


        if (defaultCursor.GetComponent<Senmag_stylusControl>().isColliding)
        {
            // Check if enough time has passed since the last sound was played.
            if (Time.time >= lastPlayTime + CooldownSeconds)
            {
                // If the cooldown has passed, update the last play time to now.
                lastPlayTime = Time.time;

                // Post the Wwise Event to play the sound from this cane's location.
                ImpactEvent.Post(gameObject);
            }
        }

    }
}
