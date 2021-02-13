using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

interface IPuzzleState
{
    ReactiveProperty<bool> ClearFlag();
}