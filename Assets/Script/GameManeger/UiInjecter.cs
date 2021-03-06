using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class UiInjecter : MonoBehaviour
{
    [SerializeField] SceneStateManeger maneger;
    [SerializeField] Text hp;
    [SerializeField] Text movesText;
    [SerializeField] GameObject MenuCambas;
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        movesText.text = maneger.sceneState.moves.ToString();
        MenuCambas.SetActive(maneger.sceneState.gameMode == GameMode.menu);

    }

    private void Init()
    {
        maneger.player.GetHP().Subscribe(
            x => { hp.text = x.ToString(); }
        );
    }
}
