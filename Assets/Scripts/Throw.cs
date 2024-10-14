using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject disc;          // The disc object
    public Transform handTransform;  // The hand bone where the disc starts
    public Animator animator;        // The Animator component for the humanoid model
    public float throwForce = 500f;  // Adjust the force applied when throwing
    public Vector3 throwDirection = Vector3.forward;  // Direction of the throw

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
            ThrowDisc();
        }
    }

    void ThrowDisc()
    {
        animator.SetTrigger("Throw");
        disc.transform.SetParent(null);
        discRigidBody.isKinematic = false;
        discRigidBody.AddForce(throwDirection.normalized * throwForce);
    }
}
