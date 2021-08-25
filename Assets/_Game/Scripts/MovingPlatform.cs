using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float maxHeight;
    [SerializeField] float moveSpeed;
    Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, transform.position.y + moveSpeed, 0) * Time.deltaTime;
        if (transform.position.y >= maxHeight)
        {
            transform.position = startPos;
        }
    }
}
