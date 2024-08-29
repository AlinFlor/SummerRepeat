using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public List<GameObject> locks; 
   // public List<GameObject> selectImg; 
    public List<Button> button; 

    private int currentLevel; 
    private int previousSelectedLevel; 

    // Start is called before the first frame update
    void Start()
    {
        // Load the unlocked level and previously selected level from PlayerPrefs
        currentLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); 
        previousSelectedLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        Debug.LogError("Current level " + currentLevel);
        Debug.LogError("Previously selected level " + previousSelectedLevel);

        UpdateLevelUI();
    }

    // Update the UI based on the current unlocked level
    void UpdateLevelUI()
    {
        for (int i = 0; i < locks.Count; i++)
        {
            if (i < currentLevel)
            {
                // Unlock the level
                locks[i].SetActive(false); // Hide the lock
                button[i].interactable = true; // Enable button interaction
            }
            else
            {
                // Keep the level locked
                locks[i].SetActive(true); // Show the lock
                button[i].interactable = false; // Disable button interaction
            }

            // Update the selection image
            //if (i == previousSelectedLevel - 1)
            //{
            //    selectImg[i].SetActive(true); // Show the select image for the previously selected level
            //}
            //else
            //{
            //    selectImg[i].SetActive(false); // Hide the select image for other levels
            //}
        }
    }

    public void SelectLevel(int level)
    {
        // Save the newly selected level
        PlayerPrefs.SetInt("CurrentLevel", level);

        // Update the UI immediately to reflect the selection change
        previousSelectedLevel = level;
        UpdateLevelUI();

        // Show the loading screen or perform any other actions required
    }
}
