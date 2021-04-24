using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mess : MonoBehaviour
{
    public float scale = 5;

    private void Start()
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Soap")
        {
            scale -= 0.3f;
            transform.localScale = new Vector3(scale, scale, scale);
            if (scale <= 0)
            {
                Destroy(gameObject);
            }            
        }

    }
}
