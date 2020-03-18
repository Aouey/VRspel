using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evElse : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case ("BlueKey"):
                PickUpKey(other);
                break;
            case ("RedKey"):
                PickUpKey(other);
                break;
        }
    }

    void PickUpKey(Collider Col)
    {
        Destroy(Col.gameObject);
    }
}
