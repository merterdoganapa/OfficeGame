using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Task : MonoBehaviour
{
    [SerializeField] private Text taskText;
    [SerializeField] private Image taskImage;

    public void UpdateText(string text)
    {
        taskText.text = text;
    }

    public void MinimizeObject() {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 sizeDelta = rectTransform.sizeDelta;
        Vector2 derivedSizeDelta = new Vector2(sizeDelta.x, -20);
        IEnumerator Do() {
            Color derivedColor = new Color(255, 255, 255, 0);
            taskText.DOColor(derivedColor, .3f);
            yield return rectTransform.DOSizeDelta(derivedSizeDelta, .5f).WaitForCompletion();
            Destroy(gameObject);
        }
        StartCoroutine(Do());
    }
    
    public void StartIntroAnimation()
    {
        StartCoroutine(IntroAnimationTask());
    }

    public void StartOutroAnimation() {
        StartCoroutine(OutroAnimationTask());
    }

    IEnumerator IntroAnimationTask() 
    {
        taskImage.DOFade(.7f, 1f);
        taskText.DOFade(1f, 1f);
        yield return taskImage.GetComponent<RectTransform>().DOAnchorPosY(-220, 2);
     }

    IEnumerator OutroAnimationTask() {
        taskText.DOFade(0f, .5f);
        taskImage.DOFade(0f, .5f);
        RectTransform rect = taskImage.GetComponent<RectTransform>();
        yield return rect.DOAnchorPosX(200, .5f).WaitForCompletion();
        rect.anchoredPosition = new Vector2(-200, -400);
    }

    public string GetText() {
        return taskText.text;
    }


}
