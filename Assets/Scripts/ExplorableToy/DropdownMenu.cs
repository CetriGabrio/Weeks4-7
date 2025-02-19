using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DropdownMenu : MonoBehaviour
{

    public TMP_Dropdown dropdown;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = dropdown.options[0].image;
    }

    public void onValueChanged(int index)
    {
        Debug.Log(dropdown.options[index].text);
        spriteRenderer.sprite = dropdown.options[index].image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
