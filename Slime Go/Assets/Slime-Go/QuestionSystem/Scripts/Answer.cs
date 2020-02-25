using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestionSystem
{
    public abstract class Answer : ScriptableObject 
    {
        [SerializeField]
        private string text;

        public string GetText(){
            return text;
        }

        public abstract void Action();
    }
    
}