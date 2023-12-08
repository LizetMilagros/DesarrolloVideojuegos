using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold;
    void FixedUpdate()
    {
        if(transform.position.y < threshold)
        {
            transform.position = new Vector3(0.95f, 0.8f, -4.48f);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
