using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfficeObjects
{
    public class Bin : OfficeObject, IClickable
    {
        [SerializeField] private AudioSource audioSource;
        public void Click()
        {
            ClickedObjectController.Instance.SetClickedObject(gameObject);
            ClickedObjectController.Instance.OnBinClick(this);
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
