using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUI : MonoBehaviour
{
    public Image HealthBar;

    private void Start()
    {
        HealthBar.fillAmount = GetComponent<HealthAndDamage>().GetHealthRatio();
    }

    public void UpdateHealthBar(float NewHealthRatio)
    {

    }
}
