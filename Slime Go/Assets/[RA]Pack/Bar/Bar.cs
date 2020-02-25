using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bar : MonoBehaviour
{
    public Image image;

    public float Amount
    {
        get { return image.fillAmount; }
        set { image.fillAmount = Mathf.Clamp(value,0,1); }
    }

    public void AddPercentage(float amount)
    {
        image.fillAmount = Mathf.Clamp(image.fillAmount + amount, 0, 1);
    }
}
