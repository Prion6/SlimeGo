using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slime;
using QuestionSystem;
using UnityEngine.UI;
using DataSystem;

namespace QuestionSystem.Slime
{
    public class QuestionSystem_Slime : MonoBehaviour
    {
        public static List<Answers_Slime> answers = new List<Answers_Slime>();
        public GameObject Slime;
        public List<Sprite> sprites;

        public void Check()
        {
            int lastValue = 0;
            int actualValue = 0;
            SlimeType type = (SlimeType)System.Enum.Parse(typeof(SlimeType), "Water");
            List <SlimeType> types = new List<SlimeType>();

            for (int i = 0; i < answers.Count; i++)
            {
                for (int j = 0; j < answers[i].Types.Count; j++)
                {
                    types.Add(answers[i].Types[j]);
                }
            }

            /*for (int j = 0; j < types.Count; j++)
            {
                Debug.Log(types[j]);
            }*/

            for (int i = 0; i < System.Enum.GetValues(typeof(SlimeType)).Length; i++)
            {
                //type = (SlimeType)i;
                for (int j = 0; j < types.Count; j++)
                {
                    // Debug.Log("son iguales " + ((SlimeType)i == (SlimeType)j));
                    //Debug.Log("son iguales  " + (SlimeType)i + " == " + types[j]);
                    if ((SlimeType)i == types[j]) lastValue++;
                    if (lastValue > actualValue)
                    {
                        actualValue = lastValue;
                        Debug.Log((SlimeType)i);
                        type = (SlimeType)i;

                        var data = DataManager.LoadData<Data>();
                        if (data == null) return;
                        var acount = data.GetAcount(Globals.playerName);
                        if (acount == null) return;
                         
                        acount.player.slimes.Add(new DataSystem.Slime("Slime "+ type.ToString(),25,25,10,type.ToString()));
                        DataManager.SaveData<Data>(data);

                        Slime.GetComponent<Image>().sprite = sprites[(int)type];
                    }
                }
                lastValue = 0;
                //Debug.Log("type" + type);
            }
            Slime.transform.localScale = new Vector3(2f,2.5f,2f);
            Slime.SetActive(true);
            //Debug.Log(type.ToString());
        }

    }
}