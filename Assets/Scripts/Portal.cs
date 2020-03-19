using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Variables.HasRedKey || Variables.HasBlueKey)
            {
                Destroy(gameObject);
            }

        }
    }
}
