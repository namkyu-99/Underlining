using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Player;
    public GameObject Goal;
    public CameraUI CameraUI0;
    public GameUI gameUI;

    public bool isGameEnd;          // 게임이 종료됐는지

    float StartPosition;            // 시작점 좌표
    float EndPosition;              // 도착점 좌표

    public float Pass;              // 진행 거리
    public float Distance;          // 총 거리
    public float PlayTime;          // 진행 시간
    public int Grab;                // 수행 횟수
    public int Coin;                // 코인 개수
    public int TotalCoin;           // 총 코인 개수

    float yThreshold;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        isGameEnd = false;

        StartPosition = Player.transform.position.z;
        EndPosition = Goal.transform.position.z;
        
        Pass = 0.0f;
        Distance = Mathf.Abs(StartPosition - EndPosition);
        PlayTime = 0.0f;
        Grab = 0;
        Coin = 0;

        yThreshold = Player.transform.position.y - 1.0f;
    }

    void Update()
    {
        if(!isGameEnd)
        {
            if (StartPosition > EndPosition)
                Pass = StartPosition - Player.transform.position.z;
            else
                Pass = Player.transform.position.z - StartPosition;

            PlayTime += Time.deltaTime;

            if(Player.transform.position.y <= yThreshold)   // 떨어지면
            {
                GameEnd(false);                             // 게임 오버
                isGameEnd = true;
            }
        }
    }

    public void GameEnd(bool isGameClear)
    {
        if(!isGameEnd)
        {
            CameraUI0.gameObject.SetActive(false);
            gameUI.gameObject.SetActive(true);
            gameUI.GameEnd(isGameClear);
            isGameEnd = true;
        }
    }

    public void GrabCount()     // 수행 횟수 카운트
    {
        Grab++;
    }

    public void CoinCount()     // 코인 개수 카운트
    {
        Coin++;
    }
}