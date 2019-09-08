using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Class for shanging scene and functions needed for this
public class changeScene : MonoBehaviour
{
    // changes scene to the specified scene
    public void ChangeScene(string scene) {
        makeCursorVisible();    // Makes cursor visible, is undone in gameScene, inefficient
        SceneManager.LoadScene(scene);  // Loads the provided scene
    }

    public void quitGame()
    {
        Application.Quit();
    }

    // Makes cursor vivisble
    public void makeCursorVisible()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
