using Assets.Scripts.Models;
using Assets.Scripts;
using UnityEngine;
using System;

public class Throw : MonoBehaviour
{
    public GameObject floaterPrefab;
    public GameObject floaterParent;
    public GameObject disc;          // The disc object
    public Transform handTransform;  // The hand bone where the disc starts
    public Animator animator;        // The Animator component for the humanoid model
    public CameraFollow cameraFollowScript;

    private Rigidbody discRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        discRigidBody = disc.GetComponent<Rigidbody>();
        disc.transform.SetParent(handTransform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartThrow();
        }
    }

    void StartThrow()
    {
        animator.SetTrigger("Throw");
    }

    // Set up hard-coded values
    // Using Dynamic Discs Truth
    Disc memDisc = new()
    {
        Speed = Speed.Speed5,
        Glide = Glide.Glide5,
        Turn = Turn.Turn0,
        Fade = Fade.Fade2
    };

    // Completely flat disc nose angle and no hyzer/anhyzer
    DiscOrientation discOrientation = new()
    {
        DiscRoll = 0f,
        DiscPitch = 0f
    };

    // For discs, optimal launch angle is between 15 and 30 degrees
    LaunchAngle launchAngle = new()
    {
        PolarAngle = 60f,
        AzimuthalAngle = 90f // Thrown straight towards positive z.
    };

    // Semi-average disc speed
    float velocity = 100f; // Measured in kmph

    void ThrowDisc()
    {
        if(floaterPrefab == null)
        {
            Debug.LogError("floater prefab is null");
            return;
        }

        Vector3 originPoint = disc.transform.position;

        Func<float, Vector3> flightPath = FlightPath.CalculateFlightPath(memDisc, discOrientation, launchAngle, originPoint, velocity);

        Vector3[] floaterArray = new Vector3[300];

        for (float i = 0; i < 300; i += 1f)
        {
            Vector3 point = flightPath(i);
            var newFloater = Instantiate(floaterPrefab, point, Quaternion.identity, floaterParent.transform);

            newFloater.name = "floater" + i;
            floaterArray[(int)i] = point;
        }

        disc.transform.SetParent(null);
        if (disc.TryGetComponent<DiscMover>(out var discMover))
        {
            disc.transform.Flatten();
            discMover.floaters = floaterArray;
            discMover.shouldMove = true;
        }

        cameraFollowScript.FollowDisc();
    }
}
