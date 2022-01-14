using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfficeObjects { 

    public class Pen : OfficeObject, IClickable
    {
        [SerializeField] private Color color;
        public void Click()
        {
            ClickedObjectController.Instance.SetClickedObject(gameObject);
        }
        public Color GetColor() {
            return color;
        }
    }
}
