using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfficeObjects
{
    public class Door : OfficeObject
    {
        [SerializeField] private AudioSource audioSource;
        bool isOpened = false;

        public override void Awake()
        {
            base.Awake();
            isOpened = false;
        }

        public override void Click()
        {
            if (ClickedObjectController.canClickable[objectName] && !isOpened)
            {
                base.Click();
                ClickedObjectController.Instance.OnDoorClick(this);
                StartCoroutine(RotateDoor());
            }
        }

        IEnumerator RotateDoor()
        {
            isOpened = true;
            Vector3 desiredRotation = new Vector3(0, -45, 0);
            audioSource.Play();
            yield return transform.DORotate(desiredRotation, 3.3f).WaitForCompletion();
            audioSource.Stop();
        }
    }

}