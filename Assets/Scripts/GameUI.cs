using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUI : MonoBehaviour
{
    public GameObject GameClear;
    public GameObject GameOver;
    public CameraUI CameraUI1;
    public TextMeshProUGUI MapText;

    public AudioSource GameClearSound0;
    public AudioSource GameClearSound1;
    public AudioSource GameOverSound;

    public void GameEnd(bool isGameClear)
    {
        if (isGameClear)
        {
            GameClear.SetActive(true);
            GameClearSound0.Play();
            GameClearSound1.Play();
        }
        else
        {
            GameOver.SetActive(true);
            GameOverSound.Play();
        }

        switch(SceneManager.GetActiveScene().name)
        {
            case "Canyon":
                MapText.text = "플레이한 맵: 협곡";
                break;
            case "SnowMountain":
                MapText.text = "플레이한 맵: 설산";
                break;
            case "City":
                MapText.text = "플레이한 맵: 도시";
                break;
        }

        CameraUI1.UpdateUI();
    }

    public void RestartButton()
    {
        Invoke("Restart", 0.5f);
    }

    public void TitleButton()
    {
        Invoke("Title", 0.5f);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Title()
    {
        SceneManager.LoadScene("Title");
    }
}