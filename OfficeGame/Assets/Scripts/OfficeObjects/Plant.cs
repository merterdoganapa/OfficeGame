using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace OfficeObjects
{
    public class Plant : OfficeObject
    {
        [SerializeField] private Transform plantTransform;
        public override void Click()
        {
            if (ClickedObjectController.canClickable[objectName])
            {
                base.Click();
                ClickedObjectController.Instance.OnPlantClick(this);
            }
        }

        public IEnumerator Grow() {
            yield return new WaitForSecondsRealtime(1f);
            plantTransform.DOLocalMoveY(-0.025f, 3f);
            yield return plantTransform.DOScale(plantTransform.localScale * 1.25f, 3f).WaitForCompletion();
        }
    }
}
