using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class UiInjecter : MonoBehaviour
{
    [SerializeField] SceneStateManeger maneger = null;
    [SerializeField] Text hp = null;
    [SerializeField] Text movesText = null;
    [SerializeField] UiCambas menuCambas = null;
    [SerializeField] UiCambas shootingCambas = null;
    [SerializeField] UiCambas puzzleCambas = null;
    [SerializeField] UiCambas clearCambas = null;
    [SerializeField] UiCambas gameoverCambas = null;

    Dictionary<GameMode, UiCambas> CambasDictionary = new Dictionary<GameMode, UiCambas>();

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        //InSpectorにそれらしいデータ型を対応させるのが面倒なのでゴリ押しした
        movesText.text = maneger.sceneState.moves.ToString();
        foreach (KeyValuePair<GameMode, UiCambas> cambas in CambasDictionary)
        {
            cambas.Value.gameObject.SetActive(maneger.sceneState.gameMode == cambas.Key);
        }

    }

    private void Init()
    {
        //Dictionaryに登録
        if (menuCambas != null) CambasDictionary.Add(GameMode.menu, menuCambas);
        if (shootingCambas != null) CambasDictionary.Add(GameMode.shooting, shootingCambas);
        if (puzzleCambas != null) CambasDictionary.Add(GameMode.puzzle, puzzleCambas);
        if (clearCambas != null) CambasDictionary.Add(GameMode.clear, clearCambas);
        if (gameoverCambas != null) CambasDictionary.Add(GameMode.gameover, gameoverCambas);
        maneger.player.GetHP().Subscribe(
            x => { hp.text = x.ToString(); }
        );
    }
}
