using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsableButton : MonoBehaviour
{
    public int amount = 0;

    public Button button;
    public Text number;

    internal void SetAmount(int n)
    {
        amount = n;
        number.text = n.ToString();
    }
}
