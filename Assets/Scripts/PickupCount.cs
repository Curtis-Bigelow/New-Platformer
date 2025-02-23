using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupCount : MonoBehaviour
{
    public TMP_Text pickupText;
    // Start is called before the first frame update
    void Start()
    {
        //Check what level it is for number of pickups
        if(SceneManager.GetActiveScene().name == "Level01")
        {
            pickupText.SetText("Pickups collected: " + GameManager.instance.GetPickups() + " of 1");
        }
        if (SceneManager.GetActiveScene().name == "Level02")
        {
            pickupText.SetText("Pickups collected: " + GameManager.instance.GetPickups() + " of 2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Update it so it walways has the right number
        if (SceneManager.GetActiveScene().name == "Level01")
        {
            pickupText.SetText("Pickups collected: " + GameManager.instance.GetPickups() + " of 1");
        }
        if (SceneManager.GetActiveScene().name == "Level02")
        {
            pickupText.SetText("Pickups collected: " + GameManager.instance.GetPickups() + " of 2");
        }
    }
}
