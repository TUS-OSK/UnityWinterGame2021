using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class UiInjecter : MonoBehaviour
{
    IPlayerState player;
    IPuzzleState puzzle;
    [SerializeField] SceneState sceneState;

    [SerializeField] Text hp;
    [SerializeField] GameObject MenuCambas;
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        player.GetHP().Subscribe(
            x => { hp.text = x.ToString(); }
        );
    }
}
