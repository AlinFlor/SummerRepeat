using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class playerHealth : MonoBehaviour
{
    public float currentHealh = 0;
    public TextMeshProUGUI currentHealthTxt;
    private float maxHealth = 100;
    public AudioSource hurtAudio;

    private void Start()
    {
        currentHealh = maxHealth;
    }
    public void takeDamage(float damage)
    {
        hurtAudio.Play();
        transform.GetComponent<Animator>().Play("hit");
        currentHealh -= damage;
        currentHealthTxt.text = currentHealh.ToString();
        if(currentHealh<=0)
        {
            SceneManager.LoadScene("GameLoose");
            
           
        }
        
    }
}
