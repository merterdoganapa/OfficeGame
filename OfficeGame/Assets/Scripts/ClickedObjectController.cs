using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeObjects;
using DG.Tweening;

public class ClickedObjectController : MonoBehaviour
{
    [SerializeField] private GameObject waterDispenserObject;
    private GameObject clickedObject;
    private Glass trashGlass;
    public static ClickedObjectController Instance;

    public void Awake()
    {
        Instance = this;
    }

    public GameObject GetClickedObject()
    {
        return clickedObject;
    }

    public void SetClickedObject(GameObject gameObject)
    {
        clickedObject = gameObject;
    }

    public void OnGlassClick(Glass glass,bool isTrashable) {
        if (!isTrashable)
        {
            WaterDispenser waterDispensor = waterDispenserObject.GetComponent<WaterDispenser>();
            waterDispensor.PlaceGlass(glass);
        }
    }

    public void OnPlantClick(Plant plant) {
        WaterDispenser waterDispenser = waterDispenserObject.GetComponent<WaterDispenser>();
        
        if (!waterDispenser.IsGlassFull()) return;

        Glass glass = waterDispenser.GetGlass();
        waterDispenser.SetGlass(null);
        StartCoroutine(PourWaterToPlant(plant, glass));
        
    }

    public void OnBinClick(Bin bin) {
        if (trashGlass == null) return;

        StartCoroutine(ThrowGlassIntoBin(bin, trashGlass));
    }

    public void OnDoorClick(Door door) {
        StartCoroutine(RotateDoor(door));
    }

    IEnumerator RotateDoor(Door door) {
        Vector3 desiredRotation = new Vector3(0, -45, 0);
        yield return door.transform.DORotate(desiredRotation, 2f).WaitForCompletion();
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
