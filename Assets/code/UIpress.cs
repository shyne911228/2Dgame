using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIpress : MonoBehaviour
{
    public AudioSource au;
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void sound()
    {
        au.Play();
    }
    /*public void UIenable()
    {

    }*/
}
