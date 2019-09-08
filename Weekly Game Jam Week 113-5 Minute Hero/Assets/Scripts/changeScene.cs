using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    // changes scene to the specified scene
    public void ChangeScene(string scene) {
        SceneManager.LoadScene(scene);  // Loads the provided scene
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
