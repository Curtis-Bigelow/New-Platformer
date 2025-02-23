using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStart : MonoBehaviour
{
  public void LoadNextScene()
    {
        SceneManager.LoadScene(1); //Used for the start button to start the game
    }
}
