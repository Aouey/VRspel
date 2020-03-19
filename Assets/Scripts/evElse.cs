using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class evElse : MonoBehaviour
{

    public RawImage RedKey;
    public RawImage BlueKey;

    private void Awake()
    {
        RedKey.enabled = false;
        BlueKey.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case ("BlueKey"):
                PickUpKey(other, BlueKey);
                Variables.HasBlueKey = true;
                break;
            case ("RedKey"):
                PickUpKey(other, RedKey);
                Variables.HasRedKey = true;
                break;

        }
    }

    void PickUpKey(Collider Col, RawImage key)
    {
        Destroy(Col.gameObject);
        key.enabled = true;
    }
}
