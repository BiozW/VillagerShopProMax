using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class TestDoTween : MonoBehaviour
{
    public float fadeTime = 1f;
    public GridLayoutGroup ShopUI;
    //public GameObject<UIItem> gameObject = new GameObject<UIItem>();
    //[SerializeField] List<UIItem> itemUIList = new List<UIItem>();
    public void ItemAnimation()
    {
        Debug.Log("Triger");
    }
    /*IEnumerator ItemAnimation()
    {
        Debug.Log("Trigger");
        foreach (var item in itemUIList)
        {
            item.transform.localScale = Vector3.zero;
        }
        foreach (var item in itemUIList)
        {
            item.transform.DOScale(1f,fadeTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);
        }
    }*/

}


