using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character;
    public Transform disc;
    public Vector3 offsetCharacter;
    public Vector3 offsetDisc;
    public float smoothSpeed = 0.01f;

    private bool followDisc = false;

    void LateUpdate()
    {
        if (!followDisc && character != null)
        {
            // Camera follows the character before disc release
            Vector3 desiredPosition = character.position + offsetCharacter;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else if (followDisc && disc != null)
        {
            // Camera follows the disc after the throw
            Vector3 desiredPosition = disc.position + offsetDisc;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Optionally, look at the disc for a more dynamic view
            transform.LookAt(disc);
        }
    }

    public void FollowDisc()
    {
        followDisc = true;
    }
}
