using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPlayer : MonoBehaviour
{
    private bool allowedAttack = false;
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Player"&&allowedAttack==false)
        {
            collision.collider.GetComponent<playerHealth>().takeDamage(50);
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player" && allowedAttack == true)
        {
            allowedAttack = false;
        }
    }
}
