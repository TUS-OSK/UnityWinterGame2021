using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SceneStateManeger : MonoBehaviour
{
    //*インターフェースで取れないので応急処置的対応
    public StateInjector injector;

    public IPlayerState player;
    public IPuzzleState puzzle;
    IKeyPad keyPad;
    [SerializeField] public SceneState sceneState;

    GameMode statebaf;
    int totalGetMoves = 0;

    private void Awake()
    {
        player = injector.GetPlayer();
        puzzle = injector.GetPuzzle();
        keyPad = injector.GetKeyPad();
        Init();
    }

    private void Init()
    {
        player.GetHP().Where(x => x <= 0).Subscribe(
            _ => { if (sceneState.gameMode != GameMode.clear) sceneState.gameMode = GameMode.gameover; }
        );

        player.GetMoves().Where(x => x != totalGetMoves).Subscribe(
            x => { sceneState.moves += x - totalGetMoves; totalGetMoves = x; }
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
