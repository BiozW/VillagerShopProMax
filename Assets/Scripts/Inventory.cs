using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Minecraft.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        public ItemData[] Items => itemList.ToArray();
        [SerializeField] public List<ItemData> itemList = new List<ItemData>();
        
        public ItemSpriteData[] ItemSprites => itemSprites.ToArray();
        [SerializeField] public List<ItemSpriteData> itemSprites = new List<ItemSpriteData>();

        public ItemData[] GetItemsByType(ItemType targetType)
        {
            //Create a list that will hold all the items that matched the targetType
            var resultList = new List<ItemData>();
            foreach (var itemData in itemList)
            {
                if (itemData.type == targetType)
                {
                    foreach (var itemSprite in ItemSprites)
                    {
                        if (itemData.displayName == itemSprite.displayName)
                        {
                            itemData.icon = itemSprite.icon;
                        }
                    }
                    resultList.Add(itemData);
                }
                //return resultList.ToArray();
            }
                   

            //Return the result as Array not List. Because we don't want caller to modify the result afterward.
            return resultList.ToArray();
        }
    }

    [Serializable]
    public class ItemData
    {
        public string displayName;
        public string description;
        public Sprite icon;
        public ItemType type;
        public int cost;
        public int count;
    }
    [Serializable]
    public class ItemSpriteData
    {
        public string displayName;
        public Sprite icon;
    }

    public enum ItemType
    {
        Weapon, 
        Food, 
        Material, 
        Others
    }
}