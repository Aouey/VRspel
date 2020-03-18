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

    public void ChangeKey(bool Blue, bool Red)
    {
        if (Blue == true)
        {
            HasBlueKey = !HasBlueKey;
        }

        if (Red == true)
        {
            HasRedKey = !HasRedKey;
        }

    }

}
