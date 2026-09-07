using System;
using UnityEngine;

public class WorldMove : MonoBehaviour
{
    private Rigidbody2D rb;

    private SpeedControlleer sp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = FindAnyObjectByType<SpeedControlleer>().GetComponent<SpeedControlleer>();
    }

    private void FixedUpdate() {
        rb.linearVelocityX = -sp.speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Destroyer"))
            Destroy(gameObject);
    }
}
