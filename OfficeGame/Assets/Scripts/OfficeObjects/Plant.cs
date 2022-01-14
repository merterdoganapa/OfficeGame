using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfficeObjects
{
    public class Plant : OfficeObject,IClickable
    {
        public void Click()
        {
            ClickedObjectController.Instance.SetClickedObject(gameObject);
        }
    }
}
