using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject textLoad;
    public GameObject textPress;
    public Slider loadBar;
    public int sceneId;

    private void OnTriggerEnter(Collider other)
    {   
        LoadScene();
    }

    public void LoadScene()
    {
        loadingScreen.SetActive(true);

        StartCoroutine(LoadAsync(sceneId));
    }

    IEnumerator LoadAsync(int sceneId)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneId);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            loadBar.value = asyncLoad.progress;
            if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                textLoad.SetActive(false);
                textPress.SetActive(true);
                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;

                }
            }

            yield return null;
        }
    }
    
}
