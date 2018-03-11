using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    [SerializeField]
    private GameObject gObj;

    [SerializeField]
    private NotesList notesList;

    private void StateChangedFunc(object s, GameManager.GameState state)
    {
        switch (state)
        {
            case GameManager.GameState.CountDown:
                break;
            case GameManager.GameState.MainGame:
                SoundManager.Inst.PlayBGM("gameBGM1");
                notesList.ReadJsonFromResource("gameSound1");
                break;
            case GameManager.GameState.WaitForStart:
                break;
            default:
                break;
        }
    }

    // Use this for initialization
    void Start()
    {
        gObj.GetComponent<GameManager>().StateChanged += StateChangedFunc;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
