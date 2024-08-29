using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setAnimator : MonoBehaviour
{
    public Animator anim;
    public gameManager manager;
        

    public void openDoor()
    {
        if (manager.getNumberOfKeys() == 3)
        {
            anim.SetBool("open", true);
        }
        else
        {
            Debug.Log("not enough keys");
        }
    }
   



}
