using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace QuestionSystem
{
    public class QuestionManager : MonoBehaviour
    {
        private int aux = 0;
        public Text questionText;
        private Question actualQuestion;
        public RectTransform buttonParent;
        public QuestionSolver solver_Pref;
        public List<Question> questions;
        public List<Question> gameQuestions;
        private List<QuestionSolver> buttons = new List<QuestionSolver>();
        private List<Question> erasedQuestions = new List<Question>();

       
        //[Header("WARNING: THIS VAR SHOULD BE LESS THAN QUESTION PULL LENGHT")]
        public int questionsAmount;

        public UnityEvent evn;

        // Start is called before the first frame update
        void Start()
        {
            if (questionsAmount > questions.Count) questionsAmount = questions.Count;
            //initialization for game questions
            for (int i = 0; i < questionsAmount; i++)
            {
                int value = Random.Range(0, questions.Count);
                gameQuestions.Add(questions[value]);
                erasedQuestions.Add(questions[value]);
                questions.Remove(questions[value]);
            }
            for (int i = 0; i < erasedQuestions.Count; i++)
            {
                questions.Add(erasedQuestions[i]);
            }
            erasedQuestions = new List<Question>();
            /*for (int i = 0; i < gameQuestions.Count; i++)
            {
                Debug.Log(gameQuestions[i]);
            }*/
            actualQuestion = gameQuestions[aux];
            questionText.text = actualQuestion.Text;

            for (int i = 0; i < actualQuestion.GetAnswersLength(); i++)
            {
                QuestionSolver newSolver = Instantiate(solver_Pref, buttonParent);
                newSolver.SetText(actualQuestion.GetAnswerText(i));
                buttons.Add(newSolver);
                var temp = i;
                newSolver.AddListener(delegate { actualQuestion.AnswerAction(temp); });
                newSolver.AddListener(delegate { SetNextQuestion(); });
            }
        }

        public void SetNextQuestion()
        {

            for (int i = 0; i < buttons.Count; i++)
                Destroy(buttons[i].gameObject);
            
            buttons = new List<QuestionSolver>();
            aux++;
            if (aux < gameQuestions.Count)
            {           
                actualQuestion = gameQuestions[aux];

                questionText.text = actualQuestion.Text; 
                for (int i = 0; i < actualQuestion.GetAnswersLength(); i++)
                {
                    QuestionSolver newSolver = Instantiate(solver_Pref, buttonParent);
                    newSolver.SetText(actualQuestion.GetAnswerText(i));
                    buttons.Add(newSolver);
                    var temp = i;
                    newSolver.AddListener(delegate { actualQuestion.AnswerAction(temp); });
                    newSolver.AddListener(delegate { SetNextQuestion(); });
                }
            }
            else
            {
                questionText.text = "";
                QuestionSolver newSolver = Instantiate(solver_Pref, buttonParent);
                newSolver.SetText("Your Slime is...");
                buttons.Add(newSolver);
                newSolver.AddListener(evn.Invoke);
            }
        }
    }


}