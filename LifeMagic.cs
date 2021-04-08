using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeMagic : MonoBehaviour
{
    public Image lifeBar;
    public Image manaBar;
    public Text lifeText;
    public Text manaText;

    public float myLife;
    public float myMana;

    private float currentLife;
    private float currentMana;
    private float calculateLife;

    void Start()
    {
        currentLife = myLife;
        currentMana = myMana;
    }

    void Update()
    {
        if (currentLife >= 0)
        {
            calculateLife = currentLife / myLife;
            lifeBar.fillAmount = Mathf.MoveTowards(lifeBar.fillAmount, calculateLife, Time.deltaTime);
            lifeText.text = "" + (int)currentLife;
        }
        else
        {
            //Game Over Scene
        }
        

        if (currentMana < myMana)
        {
            manaBar.fillAmount = Mathf.MoveTowards(manaBar.fillAmount, 1f, Time.deltaTime * 0.1f);
            currentMana = Mathf.MoveTowards(currentMana / myMana, 1f, Time.deltaTime * 0.1f) * myMana;
        }
        if (currentMana < 0)
        {
            currentMana = 0;
        }

        manaText.text = "" + Mathf.FloorToInt(currentMana);

        
    }

    public void Damage(float damage)
    {
        currentLife -= damage;
    }
    public void ReduceMana(float mana)
    {
        if (mana <= currentMana)
        {
            currentMana -= mana;
            manaBar.fillAmount -= mana / myMana;
        }
        else
        {
            //Not enough mana!
        }
        
    }
}
