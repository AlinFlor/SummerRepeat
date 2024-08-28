using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gameManager : MonoBehaviour
{
    private int numberOfKeys;
    public TextMeshProUGUI keys;

    private void Start()
    {
        Time.timeScale = 1;
    }
    public int getNumberOfKeys()
    {
        return numberOfKeys;
    }
    public void addNumberOfKeys()
    {
        numberOfKeys++;
        keys.text = "Keys Collected " + numberOfKeys;

    }
    
}
