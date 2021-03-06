using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IPuzzleState
{
    ReactiveProperty<bool> ClearFlag();
}