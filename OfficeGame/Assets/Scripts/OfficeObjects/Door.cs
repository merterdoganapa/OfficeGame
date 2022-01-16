using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfficeObjects
{
    public class Door : OfficeObject
    {
        public override void Click()
        {
            if (ClickedObjectController.canClickable[objectName])
            {
                base.Click();
                ClickedObjectController.Instance.OnDoorClick(this);
            }
        }
    }

}