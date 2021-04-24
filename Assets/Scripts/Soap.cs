using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soap : MonoBehaviour
{
    public float speed = 20;
    public Vector3 direction;

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
