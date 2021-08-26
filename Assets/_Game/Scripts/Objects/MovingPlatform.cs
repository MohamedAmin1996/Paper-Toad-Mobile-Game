using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float maxHeight;
    [SerializeField] float moveSpeed;
    public Rigidbody rb;
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 endPos;

    private void Awake()
    {
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
