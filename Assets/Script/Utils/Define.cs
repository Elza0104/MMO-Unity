using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{
    public enum CameraMode
    {
        QueterView,
        Raview
    }
    public enum MouseEvent
    {
        Press,
        PointerDown,
        PointerUp,
        Click
    }

    public enum UIEvent
    {
        Click,
        Drag
    }

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
        Shop,
    }
    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount
    }

    public enum Layer
    {
        Monster = 6,
        Ground = 7,
        Block = 8,
    }
}
