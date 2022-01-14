using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfficeObjects
{
    public class Glass : OfficeObject, IClickable
    {
        public void Click()
        {
            ClickedObjectController.Instance.SetClickedObject(gameObject);
            ClickedObjectController.Instance.OnGlassClick(this);
        }
    }
}
