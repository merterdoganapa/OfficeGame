using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfficeObjects { 

    public class Pen : OfficeObject
    {
        [SerializeField] private Color color;
        public override void Click()
        {
            if (ClickedObjectController.canClickable[objectName]) 
            { 
                ClickedObjectController.Instance.SetClickedObject(gameObject);
                ClickedObjectController.Instance.OnPenClick(this);
            }
        }
        public Color GetColor() {
            return color;
        }
    }
}
