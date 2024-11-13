using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;

    public float speed = 10f;
    public float rotation = 200f;
    public float lifeTime = 5f;

    [Header("Explosion")]
    public GameObject explosionPrefab;
    public AudioClip explosionSound;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        FixRotationToTarget();
        rb.velocity = transform.up * speed;
    }

    private void FixRotationToTarget()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float angle = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -angle * rotation;
    }

    void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
    }
}