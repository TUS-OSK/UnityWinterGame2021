using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SceneStateManeger : MonoBehaviour
{
    IPlayerState player;
    IPuzzleState puzzle;
    IKeyPad keyPad;
    [SerializeField] SceneState sceneState;

    GameMode statebaf;

    private void Start()
    {
        Init();
    }
    private void Init()
    {
        player.GetHP().Where(x => x <= 0).Subscribe(
            _ => { if (sceneState.gameMode != GameMode.clear) sceneState.gameMode = GameMode.gameover; }
        );

        keyPad.PhaseChangeKey().Where(x => x == true).Subscribe(
            _ =>
            {
                if (sceneState.gameMode == GameMode.shooting) sceneState.gameMode = GameMode.puzzle;
                else if (sceneState.gameMode == GameMode.puzzle) sceneState.gameMode = GameMode.shooting;
            }
        );

        keyPad.MenuKey().Where(x => x == true).Subscribe(
            _ =>
            {
                if (sceneState.gameMode != GameMode.gameover && sceneState.gameMode != GameMode.clear)
                {
                    statebaf = sceneState.gameMode;
                    sceneState.gameMode = GameMode.menu;
                }
            }
        );

        puzzle.ClearFlag().Where(x => x == true).Subscribe(
            _ =>
            {
                sceneState.gameMode = GameMode.clear;
            }
        );
    }
}
