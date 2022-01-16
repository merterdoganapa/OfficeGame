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
    
    public void StartIntroAnimation()
    {
        StartCoroutine(IntroAnimationTask());
    }

    public void StartOutroAnimation() {
        StartCoroutine(OutroAnimationTask());
    }

    IEnumerator IntroAnimationTask() {
        taskImage.DOFade(.7f, 2f);
        taskText.DOFade(1f, 2f);
        yield return taskImage.GetComponent<RectTransform>().DOAnchorPosY(-220, 2);
    }

    IEnumerator OutroAnimationTask() {
        taskText.DOFade(0f, 1f);
        taskImage.DOFade(0f, 1f);
        RectTransform rect = taskImage.GetComponent<RectTransform>();
        yield return rect.DOAnchorPosX(200, 1).WaitForCompletion();
        rect.anchoredPosition = new Vector2(-200, -500);
    }

    public string GetText() {
        return taskText.text;
    }


}
