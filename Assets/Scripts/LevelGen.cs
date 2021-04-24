using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    public GameObject[] buildings;
    public Vector3 offset;
    public Vector3 spacing;

    private void Start()
    {
       for(int x = 0; x < buildings.Length; x++)
       {
           for (int z = 0; z < buildings.Length; z++)
           {
               int r = Random.Range(0, buildings.Length);
               Vector3 pos = new Vector3(spacing.x * x, -1, spacing.z * z);
               GameObject b = Instantiate(buildings[r], pos, new Quaternion(0, 0, 0, 0));
               b.AddComponent<MeshCollider>();
               b.transform.parent = transform;
               b.transform.position -= offset;
           }
       }


    }
}
