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

    private float carSpeed = 5f;
    private float carAcceleration = 0.1f;

    void Start()
    {
        //if (carDropdown != null)
        //{
        //UpdateCarPreview(carDropdown.value);
        // }
        UpdateCarPreview(carDropdown.value);
        speedSlider.value = carSpeed;
        accelerationSlider.value = carAcceleration;
    }

    public void SetCarSpeed(float newSpeed)
    {
        carSpeed = newSpeed;
    }

    public void SetCarAcceleration(float newAcceleration)
    {
        carAcceleration = newAcceleration;
    }

    public void SpawnCar()
    {
        int selectedCarIndex = carDropdown.value;
        float yPosition = yPositionSlider.value;

        GameObject car = Instantiate(carPrefabs[selectedCarIndex], new Vector3(-10, yPosition, 0), Quaternion.identity);
        CarMovement carMovement = car.GetComponent<CarMovement>();
        carMovement.Initialize(carSpeed, carAcceleration);
    }

    private void UpdateCarPreview(int index)
    {
        carPreview.sprite = carPrefabs[index].GetComponent<SpriteRenderer>().sprite;
    }
}
