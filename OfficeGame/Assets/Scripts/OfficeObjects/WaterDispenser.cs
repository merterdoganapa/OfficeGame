using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

namespace OfficeObjects
{
    public class WaterDispenser : OfficeObject, IClickable
    {
        [SerializeField] private GameObject glassPlaceHolder;
        [SerializeField] private ParticleSystem glassParticalSys;
        private Glass glass;
        private bool isGlassArrived;

        public override void Awake()
        {
            base.Awake();
            isGlassArrived = false;
        }

        public void Click()
        {
            if (glass == null)
                return;
            else if(isGlassArrived && !glass.IsFull())
                StartCoroutine(PourWaterToGlass());
        }
        IEnumerator PourWaterToGlass() {
            glassParticalSys.Play();
            yield return glass.PourWater();
            glassParticalSys.Stop();
        }
        public void PlaceGlass(Glass _glass) 
        {
            SetGlass(_glass);
            IEnumerator Move()
            {
                yield return glass.transform.DOMove(glassPlaceHolder.transform.position, 3f).WaitForCompletion();
                isGlassArrived = true;
            }
            StartCoroutine(Move());
        }

        public void SetGlass(Glass _glass) {
            glass = _glass;
        }

        public bool IsGlassFull() {
            return glass != null && glass.IsFull();
        }
        public Glass GetGlass()
        {
            return glass;
        }
    }
}
