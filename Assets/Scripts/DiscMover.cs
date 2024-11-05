using UnityEngine;

public class DiscMover : MonoBehaviour
{
    public Vector3[] floaters;
    public bool shouldMove = false;
    public float speed = 1f;

    private int targetIndex = 0;

    private void Update()
    {
        if(!shouldMove || targetIndex >= floaters.Length || this.transform.position.y <= 0.01f)
        {
            return;
        }

        Vector3 targetPosition = floaters[targetIndex];
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, speed * Time.deltaTime);

        if(Vector3.Distance(this.transform.position, targetPosition) < 0.1f)
        {
            targetIndex++;
        }
    }
}
