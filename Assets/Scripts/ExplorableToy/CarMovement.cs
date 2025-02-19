using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    //Variables for the inital speed and acceleration of cars
    public float speed = 5f;
    public float acceleration = 0f;

    //Variables for detecting the borders of the screen and allowing for the cars to perform actions when interacting with the borders
    private float leftScreenEdge;
    private float rightScreenEdge;

    void Start()
    {
        //Both the right and left borders are set to convert the viewport coordinates to the world view
        //This is essential as it allows for the borders to adapt to the game screen
        //Therefore, even if the resolution og the game changed, the borders won't change or break
        leftScreenEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        rightScreenEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        //Destroying the car gameobjects afer 5 seconds of being alive
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        //Increasing the speed of the car by the acceleration
        //Time.deltatime allows for the speed to increase at constant values over time
        speed += acceleration * Time.deltaTime;

        //Moving the car to the right in a liner path, multiplying it by the speed and Time.deltaTime
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        //As mentioned before, when the car hits the border of the screen, something will happen.
        //I implemented the "Pac-Man" effect that teleports the car to the opposite border when one is crossed
        //In this case, snce movement is only tot he right, cars will teleport to the left screen edge after crossing the right one
        //When this happens, the Y and Z value are not changed.
        if (transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector3(leftScreenEdge, transform.position.y, transform.position.z);
        }
    }

    //An additional function especially for initializing the speed and acceleration of the car
    public void Initialize(float speed, float acceleration)
    {
        this.speed = speed;
        this.acceleration = acceleration;

        //Debugging tools to ensure everything worked as intended
        //Debug.Log("Car Speed: " + speed);
        //Debug.Log("Car Acceleration: " + acceleration);
    }
}
