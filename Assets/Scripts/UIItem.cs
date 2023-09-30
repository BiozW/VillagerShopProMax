using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.U2D;
using UnityEngine.EventSystems;

namespace Minecraft.InventorySystem
{
    public class UIItem : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
    {
        public GameObject ItemIcon;
        [SerializeField] TMP_Text costText;
        [SerializeField] TMP_Text countText;
        [SerializeField] Sprite itemImage;
        [SerializeField] Image pointerImage;
        public PurchaseManager purchase;
        public TextMeshProUGUI descriptionShow;

        public string description_text;


        public void SetData(UIItem_Data data)
        {
            descriptionShow.text = data.itemData.description;
            description_text = data.itemData.description;
            purchase.cost = data.itemData.cost;
            costText.text = "" + data.itemData.cost;
            countText.text = "" +  data.itemData.count;
            if(data.itemData.count == 1)
            {
                countText.text = "";
            }
            itemImage = data.itemData.icon;
            Image imageComponent = ItemIcon.GetComponent<Image>();
            imageComponent.sprite = data.itemData.icon;
            pointerImage.gameObject.SetActive(data.isSelected);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            descriptionShow.text = description_text;
            pointerImage.gameObject.SetActive(true);
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            descriptionShow.text = "";
            pointerImage.gameObject.SetActive(false);
        }

    }

    //Create a DTO class that hold information of the item and also tell is the item is selected.
    public class UIItem_Data
    {
        public ItemData itemData;
        public bool isSelected;

        public UIItem_Data(ItemData itemData, bool isSelected)
        {
            this.itemData = itemData;
            this.isSelected = isSelected;
        }
    }
    
    

}