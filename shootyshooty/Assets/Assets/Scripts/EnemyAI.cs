using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] float speed;
    Rigidbody rb;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        rb.AddForce(-(this.transform.position - player.position).normalized * speed);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
