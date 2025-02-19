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

    private float carSpeed;
    private float carAcceleration;

    void Start()
    {
        UpdateCarPreview(carDropdown.value);

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
