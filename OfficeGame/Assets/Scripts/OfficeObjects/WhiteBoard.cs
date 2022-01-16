using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfficeObjects { 
    public class WhiteBoard : OfficeObject
    {
        public override void Click()
        {
            if (ClickedObjectController.canClickable[objectName])
            {
                base.Click();
                ClickedObjectController.Instance.OnBoardClick(this);
            }
        }
        
        public void ChangeBoardColor(Color color)
        {
            Material newMaterial = MaterialExtensions.CreateMetarial("Standard", color);
            SetMeshMaterial(newMaterial);
        }
    }
}
