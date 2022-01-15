using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfficeObjects
{
    public class Door : OfficeObject, IClickable
    {
        public void Click()
        {
            ClickedObjectController.Instance.SetClickedObject(gameObject);
            ClickedObjectController.Instance.OnDoorClick(this);
        }
    }

}