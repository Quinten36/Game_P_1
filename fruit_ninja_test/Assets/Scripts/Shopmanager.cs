using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopmanager : MonoBehaviour
{

    public GameObject ShopWindow;
    private bool IsShopOpen;

    public Gradient[] skins;
    public TrailRenderer trail;

    // Start is called before the first frame update
    void Start()
    {
        IsShopOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop()
    {
        if (!IsShopOpen)
        {
            ShopWindow.gameObject.SetActive(true);
            IsShopOpen = true;
            Time.timeScale = 0;
        } 
        else
        {
            ShopWindow.gameObject.SetActive(false);
            IsShopOpen = false;
            Time.timeScale = 1;
        }
    }

    public void BuySkin(int SkinNummer)
    {
        switch (SkinNummer)
        {
            case 1:
                print("Je heb skin 1 gekocht");
                trail.GetComponent<TrailRenderer>().colorGradient = skins[0];
                break;
            case 2:
                print("Je heb skin 2 gekocht");
                trail.GetComponent<TrailRenderer>().colorGradient = skins[1];
                break;
            case 3:
                print("Je heb skin 3 gekocht");
                trail.GetComponent<TrailRenderer>().colorGradient = skins[2];
                break;
            case 4:
                print("Je heb skin 4 gekocht");
                trail.GetComponent<TrailRenderer>().colorGradient = skins[3];
                break;
            default:
                break;
        }
    }
}
