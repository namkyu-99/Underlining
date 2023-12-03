using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CameraUI : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI PassText;        // 진행 거리
    public TextMeshProUGUI PlayTimeText;    // 진행 시간
    public TextMeshProUGUI GrabText;        // 수행 횟수
    public TextMeshProUGUI CoinText;        // 코인
    
    float playTime;
    int min;
    int sec;

    void Update()
    {
        if(!GameManager.instance.isGameEnd)
        {
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        slider.value = GameManager.instance.Pass / GameManager.instance.Distance;
        if(SceneManager.GetActiveScene().name == "SnowMountain")
        {
            float value = 40.1f / GameManager.instance.Distance;     // 40m 보정치
            PassText.text = $"{(int)(GameManager.instance.Pass * value)}m / {(int)(GameManager.instance.Distance * value)}m";
        }
        else
            PassText.text = $"{(int)GameManager.instance.Pass}m / {(int)GameManager.instance.Distance}m";

        playTime = GameManager.instance.PlayTime;
        min = (int)(playTime / 60);
        sec = (int)(playTime % 60);

        if(min == 0)
            PlayTimeText.text = $"진행 시간: {sec}초";
        else
            PlayTimeText.text = $"진행 시간: {min}분 {sec}초";

        GrabText.text = $"수행 횟수: {GameManager.instance.Grab}회";
        CoinText.text = $"코인: {GameManager.instance.Coin} / {GameManager.instance.TotalCoin}";
    }
}