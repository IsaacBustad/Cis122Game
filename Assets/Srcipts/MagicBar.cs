// Written by Mahlet Asmare
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagicBar : MonoBehaviour
{

  
    private Mana mana;
    private float barMaskWidth;
    private RectTransform barMaskRectTransform;
    private RawImage barRawImage;

    private void Awake()
    {
        barMaskRectTransform = transform.Find("BarMask").GetComponent<RectTransform>();
        barRawImage = transform.Find("BarMask").Find("Bar").GetComponent<RawImage>();

        barMaskWidth = barMaskRectTransform.sizeDelta.x;
        mana = new Mana();

         
    }

    private void Update()
    {
        mana.Update();

        
        Rect uvReact = barRawImage.uvRect;
        uvReact.x -= 1f * Time.deltaTime;
        barRawImage.uvRect = uvReact;

        Vector2 barMaskSizeDelta = barMaskRectTransform.sizeDelta;
        barMaskSizeDelta.x = mana.GetManaNormaliezed() * barMaskWidth;
        barMaskRectTransform.sizeDelta = barMaskSizeDelta;
    }
}

public class Mana
{
    public const int MANA_MAx = 100;
    private float manaAmount;
    private float manaRegenAmount;

    public Mana()
    {
        manaAmount = 0;
        manaRegenAmount = 30f;
    }

    public void Update()
    {
        manaAmount += manaRegenAmount * Time.deltaTime;
        manaAmount = Mathf.Clamp(manaAmount, 0f, MANA_MAx);
    }

    public void TrySpendMana(int amount)
    {
        if (manaAmount >= amount)
        {
            manaAmount -= amount;
        }
    }

    public float GetManaNormaliezed()
    {
        return manaAmount / MANA_MAx;
    }
  
   

}
