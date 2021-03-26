using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StatePicker : SceneState, IPlayerState, IPuzzleState
{
    [SerializeField] private int hpInSpector = 0;
    private ReactiveProperty<int> hpReact = new ReactiveProperty<int>();
    [SerializeField] private int getMovesInSpector = 0;
    private ReactiveProperty<int> getMovesReact = new ReactiveProperty<int>();

    [SerializeField] bool clearInSpector = false;
    private ReactiveProperty<bool> clearReact = new ReactiveProperty<bool>();

    private void Update()
    {
        hpReact.Value = hpInSpector;
        getMovesReact.Value = getMovesInSpector;
        clearReact.Value = clearInSpector;
    }
    public ReactiveProperty<int> GetHP()
    {
        return hpReact;
    }
    public ReactiveProperty<int> GetMoves()
    {
        return getMovesReact;
    }
    public ReactiveProperty<bool> ClearFlag()
    {
        return clearReact;
    }
}
