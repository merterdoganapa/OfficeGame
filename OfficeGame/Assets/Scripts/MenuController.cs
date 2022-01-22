using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject finishMenuPanel;

    public static MenuController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OpenPauseMenu();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMenu();
        }
    }

    public void OnPauseButtonClick()
    {
        OpenPauseMenu();
    }
    public void OnRestartButtonClick() {
        SceneManager.LoadScene(0);
    }

    public void OnExitButtonClick() {
        Application.Quit();
    }

    public void OnCloseButtonClick() {
        CloseMenu();
    }

    public void OpenPauseMenu() {
        StartAnimation(pauseMenuPanel);
    }

    public void OpenFinishMenu()
    {
        StartAnimation(finishMenuPanel);
    }

    void StartAnimation(GameObject gameObject)
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<Image>().DOFade(.6f, 1);
    }


    public void CloseMenu() {
        pauseMenuPanel.GetComponent<Image>().DOFade(0f, 1);
        pauseMenuPanel.SetActive(false);
    }
}
