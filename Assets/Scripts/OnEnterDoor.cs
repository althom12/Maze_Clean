using SenmagHaptic;
using UnityEngine;

public class OnEnterDoor : MonoBehaviour
{
    // NEW: A public variable to hold our Wwise sound event.
    public AK.Wwise.Event DoorCreakEvent;

    public bool shouldOpen = false;
    private Transform door;
    public float openAngle = -75f;
    public float rotationSpeed = 50f;

   

    void Start()
    {
        //door = transform.GetChild(0).GetChild(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Senmag_HapticCursor>() || other.CompareTag("Door"))
        {
            // NEW: Check if the door isn't already opening before playing the sound.
            if (!shouldOpen)
            {
                // NEW: Tell Wwise to play the sound from this door's location.
                DoorCreakEvent.Post(gameObject);

                shouldOpen = true;
            }
        }
    }

    void Update()
    {
        if (shouldOpen)
        {
            Quaternion currentRotation = gameObject.transform.localRotation;
            Quaternion targetRotation = Quaternion.Euler(0, openAngle, 0);
            gameObject.transform.localRotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}