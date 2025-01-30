using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float hourSpeeds = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 minSpeed = transform.eulerAngles;
        minSpeed.z -= hourSpeeds;
        transform.eulerAngles = minSpeed;

    }
}
