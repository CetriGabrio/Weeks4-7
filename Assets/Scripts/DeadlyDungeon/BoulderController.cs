using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderController : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 velocity;
    public GameObject player; 

    void Start()
    {
        velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * speed;
    }

    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(this.transform.position);

        if (screenPosition.y > Screen.height || screenPosition.y < 0f)
        {
            velocity.y = -velocity.y;
        }

        if (screenPosition.x > Screen.width || screenPosition.x < 0f)
        {
            velocity.x = -velocity.x;
        }

        CheckCollisionWithPlayer();
    }

    void CheckCollisionWithPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log("Distance to player: " + distance); 
        if (distance < 1f) 
        {
            Debug.Log("Collision with player detected!"); 
            HealthBar healthBar = player.GetComponent<HealthBar>();
            if (healthBar != null)
            {
                healthBar.DamagePlayer(10);
                Debug.Log("Player health after damage: " + healthBar.curHealth); 
            }
        }
    }
}
