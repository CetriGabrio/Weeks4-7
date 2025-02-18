using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject carPrefab;
    public Button spawnButton;

    // Start is called before the first frame update
    void Start()
    {
        spawnButton.onClick.AddListener(SpawnCar);
    }

    void SpawnCar()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);
        Instantiate(carPrefab, spawnPosition, Quaternion.identity);
    }
}
