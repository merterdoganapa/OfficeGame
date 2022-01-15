using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace OfficeObjects
{
    public class Glass : OfficeObject, IClickable
    {
        [SerializeField] private Transform waterLevel;
        [SerializeField] private ParticleSystem glassParticleSystem;
        [SerializeField] private AudioSource pourWaterAudio;
        [SerializeField] private AudioSource pourGlassAudio;
        private bool isFull;
        private bool isTrashable;

        public override void Awake()
        {
            base.Awake();
            isFull = false;
            isTrashable = false;
        }

        public bool IsFull() {
            return isFull;
        }

        public void Click()
        {
            ClickedObjectController.Instance.SetClickedObject(gameObject);
            ClickedObjectController.Instance.OnGlassClick(this,isTrashable);
        }

        public IEnumerator PourWater()
        {
            Vector3 desiredScale = Vector3.one * 0.03f;
            pourWaterAudio.Play();
            waterLevel.gameObject.SetActive(true);
            waterLevel.DOScale(desiredScale, 6f);
            yield return waterLevel.DOLocalMoveY(0.14f, 6f).WaitForCompletion();
            pourWaterAudio.Stop();
            isFull = true;
        }

        public IEnumerator PourGlass() 
        {
            glassParticleSystem.Play();
            pourGlassAudio.Play();
            Vector3 desiredScale = Vector3.one * 0.02f;
            waterLevel.DOScale(desiredScale, 3.5f);
            yield return waterLevel.DOLocalMoveY(0.075f, 3.5f).WaitForCompletion();
            glassParticleSystem.Stop();
            pourGlassAudio.Stop();
            isFull = false;
            isTrashable = true;
            waterLevel.gameObject.SetActive(false);
        }
    }
}
