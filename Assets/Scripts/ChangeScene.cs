using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public ShopAnimation shopAnimation;
    public GameObject ShopUI;
    public void changeSceneToNewScene()
    {
        SceneManager.LoadScene("VerticalUI");
    }

    public void changeSceneToMainScene()
    {
        SceneManager.LoadScene("HorizonUI");
    }

    public void CloseShopUI()
    {
        ShopUI.SetActive(false);
    }
}
