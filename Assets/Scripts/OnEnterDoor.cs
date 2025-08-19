using SenmagHaptic;
using UnityEngine;

public class OnEnterDoor : MonoBehaviour
{
    private bool shouldOpen = false;
    private Transform door;
    public float openAngle = -75f;  // target Y angle
    public float rotationSpeed = 50f; // degrees per second

    void Start()
    {
        door = transform.GetChild(0).GetChild(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Senmag_HapticCursor>() || other.CompareTag("Door"))
        {
            shouldOpen = true;
        }
    }

    void Update()
    {
        if (shouldOpen)
        {
            // Current rotation
            Quaternion currentRotation = gameObject.transform.localRotation;

            // Target rotation (-75f on Y)
            Quaternion targetRotation = Quaternion.Euler(0, openAngle, 0);

            // Rotate smoothly towards target
            gameObject.transform.localRotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
