using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    bool HasRedKey;
    bool HasBlueKey;

    // Start is called before the first frame update
    void Start()
    {
        HasRedKey = false;
        HasBlueKey = false;
    }

    public void RedKey()
    {
        HasRedKey = !HasRedKey;
    }

    public void BlueKey()
    {
        HasBlueKey = !HasBlueKey;
    }
}
