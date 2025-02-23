using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int lives = 3;
    //Made public so things can acsess it
    public int pickups = 0;

    void Awake()
    {
        pickups = 0;
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void DecreaseLives()
    {
        lives--;
    }

    public int GetLives()
    {
        return lives;
    }

    //Used to increase pickup count for Varaible and display
    public void IncreasePickups()
    {

        pickups++;
    }

    //Used for collection for variable and dipslay purposes.
    public int GetPickups()
    {
        return pickups;
    }
}
