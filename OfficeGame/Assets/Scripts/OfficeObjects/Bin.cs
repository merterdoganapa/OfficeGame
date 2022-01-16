using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfficeObjects
{
    public class Bin : OfficeObject
    {
        [SerializeField] private AudioSource audioSource;
        public override void Click()
        {
            if (ClickedObjectController.canClickable[objectName]) 
            {
                base.Click();
                ClickedObjectController.Instance.OnBinClick(this);
            }
        }

        public void PlaySound()
        {
            audioSource.Play();
        }

        public void StopSound()
        {
            audioSource.Stop();
        }
    }
}
