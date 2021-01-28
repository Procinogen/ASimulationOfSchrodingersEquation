using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIValues : MonoBehaviour
{
    public display waveFuncDisplay;
    public Slider nsubx;
    public Text nsubxText;
    public Slider nsuby;
    public Text nsubyText;


    // Update is called once per frame
    void Update()
    {
        waveFuncDisplay.nx = (int)nsubx.value;
        nsubxText.text = "nₓ: " + nsubx.value;
        waveFuncDisplay.ny = (int)nsuby.value;
        nsubyText.text = "nᵧ: " + nsuby.value;
    }
}
