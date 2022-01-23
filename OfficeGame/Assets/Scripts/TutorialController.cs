using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel;

    private void Awake() => OpenTutorial();

    void OpenTutorial()
    {
        Time.timeScale = 0;
        tutorialPanel.gameObject.SetActive(true);
    }
    
    public void CompleteTutorial()
    {
        tutorialPanel.gameObject.SetActive(false);
        PlayerPrefs.SetInt("TutorialCompleted", 1);
        Time.timeScale = 1;
    }

}
