using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateInjector : MonoBehaviour
{
    //StateSceneManegerに渡す用
    //その内不要になる

    public GameObject playerOwner;
    public GameObject puzzleOwner;
    public GameObject keyPadOwner;

    public IPlayerState GetPlayer()
    {
        return playerOwner.GetComponent<IPlayerState>();
    }

    public IPuzzleState GetPuzzle()
    {
        return puzzleOwner.GetComponent<IPuzzleState>();
    }

    public IKeyPad GetKeyPad()
    {
        return keyPadOwner.GetComponent<IKeyPad>();
    }
}
