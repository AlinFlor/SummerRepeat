using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactScript : MonoBehaviour
{
    public Camera cam; // Reference to the third-person camera
    public float rayDistance = 100f; // Maximum distance for the ray
    public gameManager manager;
    public GameObject interactBtn;
    public AudioSource pickAudio, doorAudio;
    void Update()
    {
      
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

      
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
          
            //Debug.Log("Hit: " + hit.collider.gameObject.name);
            if (hit.transform.tag == "keys")
            {
                interactBtn.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickAudio.Play();
                    interactBtn.SetActive(false);
                    manager.addNumberOfKeys();
                    Destroy(hit.transform.gameObject);
                }
            }
            else
            {
                interactBtn.SetActive(false);
            }

            if(hit.transform.tag=="door")
            {
                interactBtn.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    doorAudio.Play();
                    interactBtn.SetActive(false);
                    hit.transform.GetComponent<setAnimator>().openDoor();
                }
                
            }

          
        }
        else
        {
            interactBtn.SetActive(false);
        }
    }



}
