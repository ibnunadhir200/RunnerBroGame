using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlCoin : MonoBehaviour
{
    public static int coinCount;
    public GameObject cointCountDisplay;
    public GameObject cointEndDisplay;

    private void Update()
    {
        cointCountDisplay.GetComponent<Text>().text = " " + coinCount;
        cointEndDisplay.GetComponent<Text>().text = " " + coinCount;
    }
}
