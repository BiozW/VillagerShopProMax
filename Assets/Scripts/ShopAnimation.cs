using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShopAnimation : MonoBehaviour
{
    public float fadeTime = 1f;
    public CanvasGroup ShopUI;
    public CanvasGroup ScreenAndChangeButton;
    public RectTransform rectTransform;
    public List<GameObject> items = new List<GameObject>();

    public void ShopIn()
    {
        ShopUI.alpha = 0f;
        ScreenAndChangeButton.alpha = 0f;
        rectTransform.transform.localPosition =  new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f,0f), fadeTime, false).SetEase(Ease.InOutQuint);
        ShopUI.DOFade(1, fadeTime);
        ScreenAndChangeButton.DOFade(1,fadeTime);
        StartCoroutine("ItemAnimation");
    }

    public void ShopOut()
    {
        ShopUI.alpha = 1f;
        ScreenAndChangeButton.alpha = 1f;
        rectTransform.transform.localPosition =  new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f,-1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        ShopUI.DOFade(0, fadeTime);
        ScreenAndChangeButton.DOFade(0,fadeTime);
    }

    IEnumerator ItemAnimation()
    {
        foreach (var item in items)
        {
            item.transform.localScale = Vector3.zero;
        }
        foreach (var item in items)
        {
            item.transform.DOScale(1f,fadeTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void Clear()
    {
        items.Clear();
    }
}
