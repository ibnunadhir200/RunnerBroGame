using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countMulai;
    public GameObject fadeIn;
    public AudioSource mulaiSound;
    public AudioSource readySound;

    private void Start()
    {
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(1.5f);
        countDown3.SetActive(true);
        mulaiSound.Play();
        yield return new WaitForSeconds(1);
        countDown2.SetActive(true);
        mulaiSound.Play();
        yield return new WaitForSeconds(1);
        countDown1.SetActive(true);
        mulaiSound.Play();
        yield return new WaitForSeconds(1);
        countMulai.SetActive(true);
        readySound.Play();
        PlayerMovement.canMove = true;
    }
}
