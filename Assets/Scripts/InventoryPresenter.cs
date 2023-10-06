using System;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;


namespace Minecraft.InventorySystem
{
    public class InventoryPresenter : MonoBehaviour
    {
        int currentItemIndex;
        int currentCategoryIndex;

        int maxShownItemCount;
        int maxCategoryCount = 3;

        [SerializeField] UIInventory ui;
        [SerializeField] Inventory inventory;
        [SerializeField] int pageSize;
        [SerializeField] string urlLoadPath;
        
        [SerializeField] List<CategoryInfo> categoryInfoList = new List<CategoryInfo>();
        [SerializeField] GameObject loadingScene;
        [SerializeField] TMP_Text loadText;
        public PurchaseManager purchaseManager;
        public ShopAnimation shopAnimation;

        private void Awake()
        {
            LoadScoreFromGoogleDrive();
        }
        void Start()
        {
            RefreshUI();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                PrevCategory();
                
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                NextCategory();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                PrevItem();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                NextItem();
            }
            //
            else if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                pageSize = 3;
                RefreshUI();
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                pageSize = 5;
                RefreshUI();
            }
            else if(Input.GetKey(KeyCode.Alpha3))
            {
                pageSize = 7;
                RefreshUI();
            }

            else if(Input.GetKey(KeyCode.F))
            {
            }
        }

        void PrevCategory()
        {
            if (currentCategoryIndex <= 0)
                return;
            
            currentCategoryIndex--;
            currentItemIndex = 0;
            RefreshUI();
        }

        void NextCategory()
        {
            if (currentCategoryIndex >= maxCategoryCount - 1)
                return;

            currentCategoryIndex++;
            currentItemIndex = 0;
            RefreshUI();
        }

        void PrevItem()
        {
            if (currentItemIndex <= 0)
                return;

            currentItemIndex--;
            RefreshUI();
        }

        void NextItem()
        {
            if (currentItemIndex >= maxShownItemCount -1)
                return;
            
            currentItemIndex++;
            RefreshUI();
        }

        [ContextMenu(nameof(RefreshUI))]
        void RefreshUI()
        {
            var currentCategoryInfo = categoryInfoList[currentCategoryIndex];
            ui.SetCategory(currentCategoryInfo);

            //From our int 'currentCategoryIndex', cast it into 'ItemType'.
            var currentCategory = (ItemType)currentCategoryIndex;
            
            //Get only items that matched current category.
            var itemsToDisplay = inventory.GetItemsByType(currentCategory);
            maxShownItemCount = itemsToDisplay.Length;
            
            //Clear everything and cancel if there are no items with the current category.
            if (maxShownItemCount <= 0)
            {
                ui.ClearAllItemUIs();
                return;
            }

            //Current item is retrieved from itemsToDisplay using 'currentItemIndex'
            var currentItem = itemsToDisplay[currentItemIndex];

            //This will hold list of UIItem_Data for the display of UIItem
            var uiDataList = new List<UIItem_Data>();

            //First find out what page we are in. 
            var currentPageIndex = currentItemIndex / pageSize;
            
            //Then find range of index that we want to draw.
            var startIndexToDisplay = currentPageIndex * pageSize;
            var endIndexToDisplay = startIndexToDisplay + pageSize -1;
            
            var i = 0;
            foreach (var item in itemsToDisplay)
            {
                //Select only item within start and end index and add to list.
                if (i >= startIndexToDisplay && i <= endIndexToDisplay)
                {
                    var uiData = new UIItem_Data(item, currentItem == item);
                    uiDataList.Add(uiData);
                }
              
                i++;
            }
            
            //Draw the results! Convert to array to prevent the results from being changed accidentally.
            ui.SetItemList(uiDataList.ToArray());
        }
        IEnumerator LoadScoreRoutine(string url)
        {
            UnityWebRequest webRequest = UnityWebRequest.Get(url);
            DownloadHandler handle = webRequest.downloadHandler;
            loadingScene.SetActive(true);
            webRequest.SendWebRequest();
            while (!webRequest.isDone)
            {
                loadText.text = "Loading: " + (int)(webRequest.downloadProgress * 100f) + "%";
                Debug.Log("0");
                yield return null;
            }
            loadingScene.SetActive(false);

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                var downloadedText = webRequest.downloadHandler.text;
                Debug.Log("Receive Data : " + downloadedText);
                inventory.itemList = JsonConvert.DeserializeObject<List<ItemData>>(downloadedText);
            }
            
            RefreshUI();
        }

        [ContextMenu(nameof(LoadScoreFromGoogleDrive))]
        void LoadScoreFromGoogleDrive()
        {
            StartCoroutine(LoadScoreRoutine(urlLoadPath));
        }
    }
}