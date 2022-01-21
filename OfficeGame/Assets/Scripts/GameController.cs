using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Intance;

    private void Awake()
    {
        Intance = this;
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame() {
        TaskController.Instance.GenerateTasks();
    }

    public void FinishGame()
    {
        TaskController.Instance.DestroyTasks();
        MenuController.Instance.OpenFinishMenu();
    }
}
