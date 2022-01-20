using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OfficeObjects;
using DG.Tweening;
using System;

public class TaskController : MonoBehaviour
{
    [SerializeField] private Transform taskPanel;
    [SerializeField] private GameObject taskPrefab;
    [SerializeField] private string[] taskArray;
    private int taskIndex = 0;

    public static TaskController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GenerateTasks();
    }

    private void GenerateTasks()
    {
        for (int i = 0; i < taskArray.Length; i++)
        {
            Task generatedTask = Instantiate(taskPrefab, taskPanel).GetComponent<Task>();
            generatedTask.UpdateText(taskArray[i]);
        }
    }

    public bool TryNextTask(int index)
    {
        if(index == taskIndex + 1)
        {
            taskPanel.GetChild(0).GetComponent<Task>().MinimizeObject();
            taskIndex = index;
            return true;
        }
        return false;
    }

    public void DestroyTasks() {
        for (int i = taskPanel.childCount - 1; i >= 0; i--)
        {
            taskPanel.GetChild(0).GetComponent<Task>().MinimizeObject();
        }
    }

}
