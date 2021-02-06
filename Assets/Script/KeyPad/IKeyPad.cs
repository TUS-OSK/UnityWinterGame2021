using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IKeyPad
{
    //左クリック
    ReactiveProperty<bool> ShotKey();
    //Escキー
    ReactiveProperty<bool> MenuKey();
    //Spaceキー
    ReactiveProperty<bool> PhaseChangeKey();
    //右クリック
    ReactiveProperty<bool> RightClick();
    //左クリック
    ReactiveProperty<bool> LeftClick();
    //WASDキー
    ReactiveProperty<Vector2> InputVector();
    //マウスカーソル
    ReactiveProperty<Vector2> MouseCursurPosition();
}