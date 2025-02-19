using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    //All the UI variables.
    //I decided to keep every variable in a single script rather than separating them in multiple scripts
    //simply to be able to manage everything from a central piece. In fact, in Unity, the UI Menu Canva 
    //has all the variables, prefabs and sprites. 
    public GameObject[] carPrefabs;
    public Button spawnButton;
    public Slider speedSlider;
    public Slider accelerationSlider;
    public Slider yPositionSlider;
    public TMP_Dropdown carDropdown;
    public Image carPreview;
    public Sprite[] carSprites; 

    //Variables for the car speed and acceleration which will be called by the sliders
    private float carSpeed = 5f;
    private float carAcceleration = 0.1f;

    //Variable to properly update the image preview based on the option selected in the dropdown menu
    private int previousDropdownValue = -1;

    void Start()
    {
        //Safety check to make sure that the initial image preview is not incorrectly assigned
        carPreview.sprite = null;

        //Updating the car preview based on the option selected in the dropdown menu
        UpdateCarPreview(carDropdown.value);
        previousDropdownValue = carDropdown.value;

        //Initializing the initial slider values 
        speedSlider.value = carSpeed;
        accelerationSlider.value = carAcceleration;

        //Setting the initial values for both car speed and car acceleration based on the values of the sliders
        carSpeed = speedSlider.value;
        carAcceleration = accelerationSlider.value;

    }

    void Update()
    {
        //Updating the car speed and acceleration based on the slider values
        carSpeed = speedSlider.value;
        carAcceleration = accelerationSlider.value;

        //The if statements checks if the current car option is different from the previously selected car option
        //If it is, it also changes the preview image for the car, allowing players to see what they selected
        if (carDropdown.value != previousDropdownValue)
        {
            UpdateCarPreview(carDropdown.value);
            previousDropdownValue = carDropdown.value;
        }
    }

    //I created a seprate function to organize eveeryhting that needs to happen when a car is spawned
    public void SpawnCar()
    {
        //Getting the car sprite from the dropdown menu
        int selectedCarIndex = carDropdown.value;

        //Getting the y-position from the slider
        float yPosition = yPositionSlider.value;

        //Instantiating the car prefab at the specified position, which is defined by the Spawn Point slider 
        GameObject car = Instantiate(carPrefabs[selectedCarIndex], new Vector3(-10, yPosition, 0), Quaternion.identity);

        //Calling the car speed and acceleration when a car is instantiated
        CarMovement carMovement = car.GetComponent<CarMovement>();
        carMovement.Initialize(carSpeed, carAcceleration);

        //Debug.Log("Spawning car with speed: " + carSpeed + " and acceleration: " + carAcceleration);
    }

    //I created an additional function for the preview of the car selected in the dropdown menu
    //Paired with the if statements before, both of them are called in the game by the dropdown menu
    private void UpdateCarPreview(int index)
    {
        //Since there are several sprites for cars, this if statement checks what sprite number is being called and update it
        if (index >= 0 && index < carSprites.Length)
        {
            carPreview.sprite = carSprites[index];
            //Below is a debugging tool I uused to make sure that the preview was working correctly
            //Debug.Log("Updated car preview for car index: " + index);
        }
    }
}
