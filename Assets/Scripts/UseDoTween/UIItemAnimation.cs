using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIItemAnimation : MonoBehaviour
{
    public float fadeTime = 1f;
    public List<GameObject> items = new List<GameObject>();

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

}
