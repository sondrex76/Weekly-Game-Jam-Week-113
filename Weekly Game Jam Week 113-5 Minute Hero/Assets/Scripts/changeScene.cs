using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public string scene;                // scene name

    // changes scene to the specified scene
    public void ChangeScene() {
        SceneManager.LoadScene(scene);  // Loads the provided scene
    }
}
