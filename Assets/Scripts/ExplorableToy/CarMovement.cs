using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 5f;
    private float leftScreenEdge;
    private float rightScreenEdge;

    void Start()
    {
        leftScreenEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        rightScreenEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector3(leftScreenEdge, transform.position.y, transform.position.z);
        }
    }
}
