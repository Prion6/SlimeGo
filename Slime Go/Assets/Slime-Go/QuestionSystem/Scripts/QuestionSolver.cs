using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace QuestionSystem
{
    public class QuestionSolver : MonoBehaviour
    {
        private Button button;
        private Text text;

        public Button Button { get => button; set => button = value; }
        public Text Text { get => text; set => text = value; }

        void Awake()
        {
            button = this.GetComponent<Button>();
            text = this.GetComponentInChildren<Text>();
        }

        public void SetText(string _text)
        {
            this.text.text = _text;
        }
        public void AddListener(UnityAction action)
        {
            this.button.onClick.AddListener(action);
        }
        public void RemoveListener(UnityAction action)
        {
            this.button.onClick.RemoveListener(action);
        }
        public void RemoveListener()
        {
            this.button.onClick.RemoveAllListeners();
        }
    }
}