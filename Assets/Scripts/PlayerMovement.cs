using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 1.0f;

    public float moveSpeed = 0.01f;

    public float turnAmount;
    public float moveAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turnAmount = Input.GetAxis("Horizontal") * turnSpeed;
        transform.Rotate(0, 0, -turnAmount);

        moveAmount = Input.GetAxis("Vertical") * moveSpeed;
        transform.Translate(0, moveAmount, 0);
    }

}

