using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkVictory : MonoBehaviour
{
    void Update()
    {
        if (transform.childCount == 0)  // Checks if all children(enemies) are dead
        {   
            // Resets cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            // Changes scene
            SceneManager.LoadScene("YouWon");
        }
    }
}
