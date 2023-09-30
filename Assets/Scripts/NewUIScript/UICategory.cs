using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

namespace Minecraft.InventorySystem
{
    public class UICategory : MonoBehaviour
    {
        public GameObject UIIcon;
        public TextMeshProUGUI description;
        public UIItem UIItem;
        public NewInventoryPresenter InventoryPresenter;
        public string descriptionShow;
        public void OnPointerEnter(PointerEventData eventData)
        {
            description.text = descriptionShow;
           // description.text = "Show Four Items In Total";
            description.color = Color.yellow;
            Debug.Log("tid voy");
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            description.text = "";
            description.color = Color.white;
        }
    }
}
