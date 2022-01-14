using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfficeObjects { 
    public class WhiteBoard : OfficeObject, IClickable
    {
        public void Click()
        {
            GameObject prevClickedObject = ClickedObjectController.Instance.GetClickedObject();
            ClickedObjectController.Instance.SetClickedObject(gameObject);
            if (prevClickedObject != null && prevClickedObject.GetComponent<Pen>()!= null)
            {
                Pen pen = prevClickedObject.GetComponent<Pen>();
                Color penColor = pen.GetColor();
                ChangeBoardColor(penColor);
            }
        }
        
        void ChangeBoardColor(Color color)
        {
            Material newMaterial = MaterialExtensions.CreateMetarial("Standard", color);
            SetMeshMaterial(newMaterial);
        }
    }
}
