using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeObjects;
using DG.Tweening;

public class ClickedObjectController : MonoBehaviour
{
    [SerializeField] private GameObject waterDispenserObject;
    private GameObject prevClickedGameObject;
    private GameObject clickedObject;
    private Glass trashGlass;
    public static Dictionary<string, bool> canClickable;
    public static ClickedObjectController Instance;

    public void Awake()
    {
        Instance = this;
        canClickable = new Dictionary<string, bool>
        {
            {"Pen",true},
            {"WhiteBoard",false},
            {"Glass",false},
            {"WaterDispenser",false},
            {"Plant",false},
            {"Bin",false },
            {"Door",false },
        };
    }

    public GameObject GetClickedObject()
    {
        return clickedObject;
    }

    public void SetClickedObject(GameObject gameObject)
    {
        if(clickedObject != gameObject)
        {
            prevClickedGameObject = clickedObject;
            clickedObject = gameObject;
        }
    }

    void UpdateClickableDict(string key,bool value) {
        canClickable[key] = value;
    }

    public void OnPenClick(Pen pen) {
        UpdateClickableDict("WhiteBoard", true);
        TaskController.Instance.TryNextTask(1);
    }

    public void OnGlassClick(Glass glass, bool isTrashable)
    {
        if (!isTrashable)
        {
            WaterDispenser waterDispenser = waterDispenserObject.GetComponent<WaterDispenser>();
            waterDispenser.PlaceGlass(glass);
            UpdateClickableDict("WaterDispenser", true);
            TaskController.Instance.TryNextTask(3);
        }
    }

    public void OnWaterDispenserClick(WaterDispenser waterDispenser) {
        UpdateClickableDict("Plant", true);
        TaskController.Instance.TryNextTask(4);
    }

    public void OnBoardClick(WhiteBoard board) {
        if (prevClickedGameObject != null && prevClickedGameObject.GetComponent<Pen>() != null)
        {
            Pen pen = prevClickedGameObject.GetComponent<Pen>();
            Color penColor = pen.GetColor();
            board.ChangeBoardColor(penColor);
            UpdateClickableDict("Glass", true);
            TaskController.Instance.TryNextTask(2);
        }
    }

    public void OnPlantClick(Plant plant) {
        WaterDispenser waterDispenser = waterDispenserObject.GetComponent<WaterDispenser>();
        
        if (!waterDispenser.IsGlassFull()) return;

        Glass glass = waterDispenser.GetGlass();
        waterDispenser.SetGlass(null);
        if (!canClickable["Bin"])
        {
            StartCoroutine(PourWaterToPlant(plant, glass));
            UpdateClickableDict("Bin", true);
            TaskController.Instance.TryNextTask(5);
        }
    }

    public void OnBinClick(Bin bin) {
        if (trashGlass == null) return;
        if (!canClickable["Door"]) { 
            StartCoroutine(ThrowGlassIntoBin(bin, trashGlass));
            UpdateClickableDict("Door", true);
            TaskController.Instance.TryNextTask(6);
        }
    }

    public void OnDoorClick(Door door) {
        FinishGame();
    }

    void FinishGame() {
        TaskController.Instance.DestroyTasks();
    }

    IEnumerator ThrowGlassIntoBin(Bin bin,Glass glass) {
        yield return glass.transform.DOMove(bin.transform.position + Vector3.up * 0.5f,3f).WaitForCompletion();
        yield return glass.transform.DOMove(bin.transform.position, .75f).WaitForCompletion();
        bin.PlaySound();
        trashGlass = null;
    }

    IEnumerator PrepareForPour(Plant plant,Glass glass,GameObject glassModel) {
        
        Vector3 plantPosition = plant.transform.position;
        Vector3 desiredPosition = new Vector3(plantPosition.x + 0.1f, plantPosition.y + 0.5f, plantPosition.z) * plant.transform.localScale.x;
        yield return glass.transform.DOMove(desiredPosition, 3).WaitForCompletion();
        Vector3 desiredRotation = glassModel.transform.eulerAngles + Vector3.forward * 45f;
        yield return glassModel.transform.DORotate(desiredRotation, 1).WaitForCompletion();
    }

    IEnumerator PourWaterToPlant(Plant plant,Glass glass) {
        GameObject glassModel = glass.transform.Find("Cup").gameObject;
        yield return PrepareForPour(plant, glass, glassModel);
        StartCoroutine(glass.PourGlass());
        yield return plant.Grow();
        yield return glassModel.transform.DORotate(Vector3.zero, 1).WaitForCompletion();
        trashGlass = glass;
    }
}
