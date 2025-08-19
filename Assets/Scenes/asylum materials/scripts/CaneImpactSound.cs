using UnityEngine;

public class CaneImpactSound : MonoBehaviour
{
    private GameObject senmagWorkspace;
    private GameObject defaultCursor;
    private bool firstTime = false;

    [Header("Wwise")]
    public AK.Wwise.Event ImpactEvent;

    [Header("Settings")]
    public float CooldownSeconds = 0.2f;

    private float lastPlayTime = -1f;

    // Track the previous collision state
    private bool wasColliding = false;

    private void Start()
    {
        senmagWorkspace = GameObject.Find("SenmagWorkspace");
    }

    private void Update()
    {
        if (senmagWorkspace.transform.childCount == 0 || senmagWorkspace.transform.GetChild(0).childCount <= 1)
        {
            return;
        }

        if (!firstTime)
        {
            defaultCursor = senmagWorkspace.transform.GetChild(0).GetChild(1).gameObject;
            firstTime = true;
        }

        bool isColliding = defaultCursor.GetComponent<Senmag_stylusControl>().isColliding;

        // Detect the transition: not colliding → colliding
        if (!wasColliding && isColliding)
        {
            if (Time.time >= lastPlayTime + CooldownSeconds)
            {
                lastPlayTime = Time.time;
                ImpactEvent.Post(defaultCursor);
            }
        }

        // Update previous state
        wasColliding = isColliding;
    }
}
