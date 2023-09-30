using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Minecraft.InventorySystem
{
    public class PurchaseManager : MonoBehaviour
    {
        public EmeraldManager EManager;
        public int cost = 0;

        public void Purchase()
        {
            if (EManager.GetCurrentCurrency() >= cost)
            {
                EManager.UpdateCurrency(-cost);
            }
        }

    }
}


