using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    #region editor component
    [SerializeField]
    private Animator CountDownAnimation;

    // 初回タッチ用ダミー（全画面タッチ判定用）
    [SerializeField]
    private GameObject TouchDummy;


    #endregion

    #region state
    public enum GameState
    {
        WaitForStart,       // スタート待ち
        CountDown,          // カウントダウン中
        MainGame,           // メインゲーム中
    }

    private GameState State = GameState.WaitForStart;
    #endregion

    // 状態変更イベント
    public event EventHandler<GameState> StateChanged;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartCountDown()
    {
        if (State == GameState.WaitForStart)
        {
            CountDownAnimation.SetTrigger("StartGame");
            ChangeGameState(GameState.CountDown);

            TouchDummy.SetActive(false);
        }
    }

    public void ChangeGameState(GameState state)
    {
        State = state;

        switch (State)
        {
            case GameState.WaitForStart:
                break;
            case GameState.CountDown:
                // カウントダウン開始時には特に何もしない
                break;
            case GameState.MainGame:
                // メインゲームの開始
                break;
        }

        // イベントの通知
        StateChanged?.Invoke(this, state);
    }
}
