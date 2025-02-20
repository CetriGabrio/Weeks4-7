using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * moveHorizontal * moveSpeed * Time.deltaTime);

        float moveUp = Input.GetAxis("Vertical");

        transform.Translate(Vector2.up * moveUp * moveSpeed * Time.deltaTime);
    }
}
