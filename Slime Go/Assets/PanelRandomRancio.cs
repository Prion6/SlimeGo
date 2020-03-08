using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelRandomRancio : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        if(Globals.mesageCatcher.Equals(""))
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            text.text = Globals.mesageCatcher;
        }
    }


}
