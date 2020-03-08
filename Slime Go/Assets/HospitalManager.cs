using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataSystem;
using System;
using UnityEngine.UI;

public class HospitalManager : MonoBehaviour
{
    public Button solver_Pref;
    private RectTransform buttonParent;
    private List<Button> buttons;

    private void Start()
    {
        buttons = new List<Button>();
        buttonParent = FindObjectOfType<ICanvasMain>().gameObject.GetComponent<RectTransform>();
    }

    private void OnMouseDown()
    {
        try
        {
            var d = DataManager.LoadData<Data>();
            var acount = d.GetAcount(Globals.playerName);
            for (int i = 0; i < acount.player.items.Count; i++)
            {
                acount.player.slimes[i].life = acount.player.slimes[i].maxLife;
            }

            Button newSolver = Instantiate(solver_Pref, buttonParent);

            Vector3 pos = newSolver.transform.position;
            pos.x += 43f;
            newSolver.transform.position = pos;


            newSolver.GetComponentInChildren<Text>().text = "¡Slimes Curados!";
            buttons.Add(newSolver);

            Debug.Log("cura2");
            StartCoroutine(fadeButton(buttons[0], false, 3));


            DataManager.SaveData<Data>(d);
        }
        catch (Exception e)
        {
            Debug.Log("no cura2");
        }
    }

    /*IEnumerator Curando()
    {
        Debug.Log("curando");
        buttons[0].GetComponent<MeshRenderer>().material.color = Color.Lerp(buttons[0].GetComponent<MeshRenderer>().material.color, new Color(0, 0, 0, 0), 5 * Time.deltaTime);
        yield return new WaitForSeconds(5);
        buttons[0].Destroy();
    }*/

    IEnumerator fadeButton(Button button, bool fadeIn, float duration)
    {

        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0;
            b = 1;
        }
        else
        {
            a = 1;
            b = 0;
        }

        Image buttonImage = button.GetComponent<Image>();
        Text buttonText = button.GetComponentInChildren<Text>();

        //Enable both Button, Image and Text components
        if (!button.enabled)
            button.enabled = true;

        if (!buttonImage.enabled)
            buttonImage.enabled = true;

        if (!buttonText.enabled)
            buttonText.enabled = true;

        //For Button None or ColorTint mode
        Color buttonColor = buttonImage.color;
        Color textColor = buttonText.color;

        //For Button SpriteSwap mode
        ColorBlock colorBlock = button.colors;


        //Do the actual fading
        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);
            //Debug.Log(alpha);

            if (button.transition == Selectable.Transition.None || button.transition == Selectable.Transition.ColorTint)
            {
                buttonImage.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, alpha);//Fade Traget Image
                buttonText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);//Fade Text
            }
            else if (button.transition == Selectable.Transition.SpriteSwap)
            {
                ////Fade All Transition Images
                colorBlock.normalColor = new Color(colorBlock.normalColor.r, colorBlock.normalColor.g, colorBlock.normalColor.b, alpha);
                colorBlock.pressedColor = new Color(colorBlock.pressedColor.r, colorBlock.pressedColor.g, colorBlock.pressedColor.b, alpha);
                colorBlock.highlightedColor = new Color(colorBlock.highlightedColor.r, colorBlock.highlightedColor.g, colorBlock.highlightedColor.b, alpha);
                colorBlock.disabledColor = new Color(colorBlock.disabledColor.r, colorBlock.disabledColor.g, colorBlock.disabledColor.b, alpha);

                button.colors = colorBlock; //Assign the colors back to the Button
                buttonImage.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, alpha);//Fade Traget Image
                buttonText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);//Fade Text
            }
            else
            {
                Debug.LogError("Button Transition Type not Supported");
            }

            yield return null;
        }

        if (!fadeIn)
        {
            //Disable both Button, Image and Text components
            buttonImage.enabled = false;
            buttonText.enabled = false;
            button.enabled = false;
        }
    }

}
