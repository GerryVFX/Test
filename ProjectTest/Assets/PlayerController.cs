using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    
    
    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirZ = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(dirX, 0, dirZ);

        transform.position = transform.position + dir * (speed * Time.deltaTime);
    }
}
