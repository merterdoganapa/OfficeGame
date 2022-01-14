using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfficeObjects
{
    public class WaterDispenser : OfficeObject, IClickable
    {
        [SerializeField] private GameObject glassPlaceHolder;
        private Glass glass;
        public void Click()
        {
            if (glass == null)
                return;
            else
                FillGlass();
        }
        void FillGlass() { 

        }
        public void PlaceGlass(Glass _glass) 
        {
            glass = _glass;
            glass.transform.position = glassPlaceHolder.transform.position;
        }
    }
}
