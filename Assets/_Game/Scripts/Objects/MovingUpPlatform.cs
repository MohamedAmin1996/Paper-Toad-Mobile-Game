using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUpPlatform : MonoBehaviour
{
    [SerializeField] float maxHeight;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 endPos;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startPos = rb.position;
        endPos = new Vector3(startPos.x, startPos.y + maxHeight, startPos.z);
    }

    void FixedUpdate()
    {
        rb.velocity =  new Vector2(0, rb.velocity.y + moveSpeed);
        if (rb.position.y >= endPos.y)
        {
            rb.velocity = Vector3.zero;
            rb.position = startPos;
        }


    }

    
}
