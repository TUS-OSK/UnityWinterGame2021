using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IPlayerState
{
    ReactiveProperty<int> GetHP();
    ReactiveProperty<int> GetMoves();
}