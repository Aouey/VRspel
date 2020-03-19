using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public static bool HasRedKey = false;
    public static bool HasBlueKey = false;

    // Start is called before the first frame update
   

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
