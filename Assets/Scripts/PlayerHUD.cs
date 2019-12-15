using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{

    [SerializeField]
    RectTransform healthBarFill;

    public PlayerScript controller;

    [SerializeField]
    Text ammoText;
    
    

    public void SetHealth (PlayerScript _controller)
    {
        controller = _controller;
    }


    void SetHealthBar (float _amount)
    {
        healthBarFill.localScale = new Vector3(controller.GetPlayerHealthAmount(), 1f, 1f);
    }

   private void Update()
   {
        SetHealthBar (controller.GetPlayerHealthAmount());
   }

    void SetAmmoAmount (int _amount)
    {
        ammoText.text = _amount.ToString();
    }
}
