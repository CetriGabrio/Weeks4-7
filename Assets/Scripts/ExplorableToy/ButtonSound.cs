using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    //Variable for getting the audiosource 
    private AudioSource audiosource;

    void Start()
    {
        //Getting the audiosource component attached to the intended gameobject
        audiosource = GetComponent<AudioSource>();
    }

    //Update function to play the sound when the a button is pressed
    //I used this script for both Dropdown and Spanw button, so I kept it general
    void Update()
    {
        if(audiosource != null)
        {
            audiosource.Play();
        }
    }
}
