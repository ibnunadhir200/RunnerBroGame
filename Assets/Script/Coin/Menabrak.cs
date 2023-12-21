using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menabrak : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public AudioSource nabrakBatu;
    public GameObject mainCam;
    public GameObject levelControl;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        charModel.GetComponent<Animator>().Play("Backwaard");
        nabrakBatu.Play();
        mainCam.GetComponent<Animator>().enabled = true;
        levelControl.GetComponent<Jarak>().enabled = false;
        levelControl.GetComponent<EndGame>().enabled = true;
    }
}
