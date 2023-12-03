using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public void CanyonButton()
    {
        Invoke("Canyon", 0.5f);
    }

    public void SnowMountainButton()
    {
        Invoke("SnowMountain", 0.5f);
    }

    public void CityButton()
    {
        Invoke("City", 0.5f);
    }

    public void ExitButton()
    {
        Invoke("Exit", 0.5f);
    }

    void Canyon()
    {
        SceneManager.LoadScene("Canyon");
    }

    void SnowMountain()
    {
        SceneManager.LoadScene("SnowMountain");
    }

    void City()
    {
        SceneManager.LoadScene("City");
    }

    void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}