using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public Button spawnButton;
    public Slider speedSlider;
    public Slider accelerationSlider;
    public Slider yPositionSlider;
    public TMP_Dropdown carDropdown;
    public Image carPreview;
    public Sprite[] carSprites; 

    private float carSpeed = 5f;
    private float carAcceleration = 0.1f;
    private int previousDropdownValue = -1;

    void Start()
    {
        carPreview.sprite = null;

        UpdateCarPreview(carDropdown.value);

        speedSlider.value = carSpeed;
        accelerationSlider.value = carAcceleration;

        carSpeed = speedSlider.value;
        carAcceleration = accelerationSlider.value;

        previousDropdownValue = carDropdown.value;
    }

    void Update()
    {
        carSpeed = speedSlider.value;
        carAcceleration = accelerationSlider.value;

        if (carDropdown.value != previousDropdownValue)
        {
            UpdateCarPreview(carDropdown.value);
            previousDropdownValue = carDropdown.value;
        }
    }

    public void SpawnCar()
    {
        int selectedCarIndex = carDropdown.value;
        float yPosition = yPositionSlider.value;

        GameObject car = Instantiate(carPrefabs[selectedCarIndex], new Vector3(-10, yPosition, 0), Quaternion.identity);
        CarMovement carMovement = car.GetComponent<CarMovement>();
        carMovement.Initialize(carSpeed, carAcceleration);

        //Debug.Log("Spawning car with speed: " + carSpeed + " and acceleration: " + carAcceleration);
    }

    private void UpdateCarPreview(int index)
    {
        if (index >= 0 && index < carSprites.Length)
        {
            carPreview.sprite = carSprites[index];
            //Debug.Log("Updated car preview for car index: " + index);
        }
    }
}
