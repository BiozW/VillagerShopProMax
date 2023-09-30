using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minecraft.InventorySystem
{
    public interface CurrencyManager
    {
        int GetCurrentCurrency();
        void UpdateCurrency(int amount);
    }
}

