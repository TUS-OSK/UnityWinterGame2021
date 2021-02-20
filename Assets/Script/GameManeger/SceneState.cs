using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneState : MonoBehaviour
{
    public GameMode gameMode;
    public int moves;
}

public enum GameMode
{
    menu, shooting, puzzle, clear, gameover
}
