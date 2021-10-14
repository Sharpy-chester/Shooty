using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float maxMovementSpeed;
    [SerializeField] float acceleration;
    Rigidbody rb;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if ((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && rb.velocity.magnitude < maxMovementSpeed)
        {
            print(rb.velocity.magnitude);
            //just realised that im a dumbass for timesing the acceleration by time.deltaTime cos i'm adding force.... cant be bothered to change it right now so yeah
            rb.AddForce((acceleration * Time.deltaTime) * Input.GetAxis("Horizontal"), 0, (acceleration * Time.deltaTime) * Input.GetAxis("Vertical"));

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
