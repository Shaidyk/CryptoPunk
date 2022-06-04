using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrigerNewScene : MonoBehaviour
{
    private SceneLoader sceneLoader;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter to triger");
        Debug.Log(other.name);
        SceneManager.LoadScene(1);
    }
}
