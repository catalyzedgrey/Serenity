using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public Fungus.Flowchart lvl9Flow;
    public Fading fading;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public IEnumerator LoadScene()
    {
        float fadeTime = fading.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public IEnumerator FadeOutMirai()
    {
        float fadeTime = fading.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.Quit();

    }


}
