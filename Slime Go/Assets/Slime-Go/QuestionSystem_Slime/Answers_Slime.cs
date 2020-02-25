using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestionSystem;
using Slime;

namespace QuestionSystem.Slime
{
    [CreateAssetMenu(fileName = "New Answer Slime", menuName = "Answer Slime Data", order = 52)]
    public class Answers_Slime : Answer 
    {

        [SerializeField]
        private List<SlimeType> types;
        public List<SlimeType> Types { get => types; set => types = value; }

        public override void Action()
        {
            QuestionSystem_Slime.answers.Add(this);
        }
        
    }
}