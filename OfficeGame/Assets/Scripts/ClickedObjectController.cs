using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeObjects;

public class ClickedObjectController : MonoBehaviour
{
    [SerializeField] private GameObject waterDispenserObject;
    private GameObject clickedObject;
    public static ClickedObjectController Instance;

    public void Awake()
    {
        Instance = this;
    }

    public GameObject GetClickedObject()
    {
        return clickedObject;
    }

    public void SetClickedObject(GameObject gameObject) {
        clickedObject = gameObject;
    }

    public void OnGlassClick(Glass glass) {
        WaterDispenser waterDispensor = waterDispenserObject.GetComponent<WaterDispenser>();
        waterDispensor.PlaceGlass(glass);
    }

    public void OnPlantClick() { 
        // TODO Add glass Animation
    }
}
