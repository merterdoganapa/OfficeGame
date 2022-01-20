using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;

    public static MenuController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OpenMenu();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMenu();
        }
    }

    public void OnPauseButtonClick()
    {
        OpenMenu();
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

    public void OpenMenu() {
        pauseMenuPanel.SetActive(true);
        pauseMenuPanel.GetComponent<Image>().DOFade(.6f, 1);
    }

    public void CloseMenu() {
        pauseMenuPanel.GetComponent<Image>().DOFade(0f, 1);
        pauseMenuPanel.SetActive(false);
    }
}
