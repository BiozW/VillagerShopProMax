using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace Minecraft.InventorySystem
{
    public class UIInventory : MonoBehaviour
    {
        [Header("Category")]
        [SerializeField] TMP_Text categoryText;
        
        [Header("Current Item")]
        [SerializeField] Image currentItemIconImage;

        [Header("Item List")] 
        [SerializeField] UIItem itemUIPrefab;
        [SerializeField] List<UIItem> itemUIList = new List<UIItem>();

        public ShopAnimation shopAnimation;

        void Start()
        {
            itemUIPrefab.gameObject.SetActive(false);
        }

        public void SetCategory(CategoryInfo info)
        {
            categoryText.text = info.name;
        }
        

        public void SetItemList(UIItem_Data[] uiDatas)
        {
            //Clear and destroy created UIs first, before creating new ones.
            ClearAllItemUIs();
            foreach (var uiItemData in uiDatas)
            {
                //When creating a new UI, ALWAYS put it inside Canvas. and pass false for 'worldPositionStays'
                //This is because all UIs are always in Screen Space not World Space.
                var newItemUI = Instantiate(itemUIPrefab,itemUIPrefab.transform.parent,false);
                
                //Don't forget to enable it. Because the original UIItem was disabled from Start()
                newItemUI.gameObject.SetActive(true);
                shopAnimation.items.Add(newItemUI.gameObject);
                itemUIList.Add(newItemUI);
                newItemUI.SetData(uiItemData);

            }
        }

        //Destroy all created UIItem and then clear the list.
        public void ClearAllItemUIs()
        {
            foreach (UIItem uiItem in itemUIList)
                Destroy(uiItem.gameObject);
            
            itemUIList.Clear();
            shopAnimation.Clear();
        }
    }

    [Serializable]
    public class CategoryInfo
    {
        public string name;
        public Sprite icon;
    }
}