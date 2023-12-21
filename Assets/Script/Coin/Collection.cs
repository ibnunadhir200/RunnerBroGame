using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public AudioSource coinFx;

    private void OnTriggerEnter(Collider other)
    {
        coinFx.Play();
        ControlCoin.coinCount += 1;
        this.gameObject.SetActive(false);
    }
}
