using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonSpawn : MonoBehaviour
{
    public Button spawnButton;
    public GameObject carPrefab;  // Assign the car prefab in the Inspector
    public Transform spawnPoint;  // Assign the spawn point in the Inspector
    public float speed = 5f;

    public void SpawnCar()
    {
        GameObject car = Instantiate(carPrefab, spawnPoint.position, spawnPoint.rotation);
        StartCoroutine(MoveCar(car));
    }

    private IEnumerator MoveCar(GameObject car)
    {
        while (car != null && car.transform.position.x < Screen.width)
        {
            car.transform.Translate(Vector3.right * speed * Time.deltaTime);
            yield return null;
        }

        if (car != null)
        {
            Destroy(car);
        }

    }
}