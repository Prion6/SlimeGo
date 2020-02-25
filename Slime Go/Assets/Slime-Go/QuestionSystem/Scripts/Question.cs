using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestionSystem
{
    [CreateAssetMenu(fileName = "New Question", menuName = "Question Data", order = 51)]
    public class Question : ScriptableObject
    {
        [SerializeField]
        private string text;
        [SerializeField]
        private List<Answer> answers = new List<Answer>();

        public string Text { get => text; }      

        public void AnswerAction(int i)
        {
            try{
                answers[i].Action();
            }
            catch{
                Debug.LogWarning("[ERROR index]");
            }
        }

        public int GetAnswersLength()
        {
            return answers.Count;
        }

        internal string GetAnswerText(int i)
        {
            try{
                return answers[i].GetText();
            }
            catch{
                return "[ERROR]";
            }
        }
    }
}