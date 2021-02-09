using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public static GameState state;
    public bool gc_playing;

    // Start is called before the first frame update
    void Awake()
    {
        state = this;
    }
}
