using System.Collections;
using UnityEngine;

public class DiscMover : MonoBehaviour
{
    public GameObject[] floaters;
    public bool shouldMove = false;
    public float speed = 20f;

    private int targetIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(shouldMove)
        {
            Debug.Log("starting disc mover");
            StartCoroutine(MoveToNextFloater());
        }
        Debug.Log("disc mover is waiting");
    }

    IEnumerator MoveToNextFloater()
    {
        while(true)
        {
            Vector3 startPosition = this.transform.position; 
            Vector3 targetPosition = floaters[targetIndex].transform.position; 
            float journeyLength = Vector3.Distance(startPosition, targetPosition); 
            float startTime = Time.time; 
            
            while (transform.position != targetPosition) 
            { 
                float distCovered = (Time.time - startTime) * speed; 
                float fractionOfJourney = distCovered / journeyLength; 
                transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney); 
                yield return null; 
            }

            targetIndex = (targetIndex + 1) % floaters.Length;
        }
    }
}
