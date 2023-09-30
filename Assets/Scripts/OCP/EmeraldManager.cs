using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Minecraft.InventorySystem
{
    public class EmeraldManager : MonoBehaviour, CurrencyManager
    {
        // Start is called before the first frame update
        public TMPro.TMP_Text emeraldText;
        public bool toggleInfinite = false;
        public int myemerald = 0;

        public int GetCurrentCurrency()
        {
            return myemerald;
        }

        public void UpdateCurrency(int amount)
        {
            myemerald += amount;
        }

        // Update is called once per frame
        void Update()
        {
            InfiniteEmerald();
            EmeraldUpdate();
        }

        public void InfiniteEmerald()
        {
            
            if (toggleInfinite == true)
            {
                if (myemerald <= 3)
                {
                    myemerald = 64;
                }
            }
            
        }

        public void EmeraldUpdate()
        {
            emeraldText.text = myemerald.ToString();
        }
    }
}


