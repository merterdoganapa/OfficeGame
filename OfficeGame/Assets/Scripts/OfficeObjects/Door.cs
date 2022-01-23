using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OfficeObjects
{
    public class Door : OfficeObject
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private RawImage circle;
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

        public void StartBlinkingAnimation()
        {
            circle.gameObject.SetActive(true);
            circle.DOFade(0, .5f).SetLoops(-1, LoopType.Yoyo);
            circle.transform.DOLocalRotate(Vector3.forward * 359, 1, RotateMode.FastBeyond360).SetLoops(-1,LoopType.Restart);
        }

        public void KillAnimations()
        {
            circle.gameObject.SetActive(false);
            circle.DOKill();
            circle.transform.DOKill();
        }

    }

}