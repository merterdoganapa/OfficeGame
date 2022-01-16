using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OfficeObjects;
using DG.Tweening;

public class TaskController : MonoBehaviour
{
    [SerializeField] private Task newTask;
    [SerializeField] private Task oldTask;
    [Space()]
    [SerializeField] private string[] taskArray;
    private int taskIndex = 0;

    public static TaskController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        NextTask(0);
    }

    void UpdateTaskText(int taskIndex) {
        string taskString = taskArray[taskIndex];
        newTask.UpdateText(taskString);
    }

    public void TryNextTask(int index) {
        if (index == taskIndex + 1) 
        {
            SwapTask();
            NextTask(index);
            oldTask.StartOutroAnimation();
        }
    }

    void SwapTask() {
        Task tmpTask = newTask;
        newTask = oldTask;
        oldTask = tmpTask;
    }

    void NextTask(int index) {
        taskIndex = index;
        UpdateTaskText(taskIndex);
        newTask.StartIntroAnimation();
    }

}
