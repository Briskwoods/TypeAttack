using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DictionaryManager : MonoBehaviour
{
    public List<string> m_questionDictionary = new List<string>();
    public List<string> m_answerDictionary = new List<string>();   // Working Size of 10 answers to use in difficulty levels for the enemy
    public string m_longestWord;
    public FetchManager FetchManager_;

    void Start()
    {
        RefreshDictionary();
        m_longestWord = m_answerDictionary.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
    }

    public void RefreshLongestWord()
    {
        m_longestWord = m_answerDictionary.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
    }

    [ContextMenu("RefreshDictionary")]
    public void RefreshDictionary()
    {
        // Add code to get the next question from file/external source
        // Add code to get answers from external source and put them into the answer dictionary
        //i.e
        FetchManager_.RequestQuestion();

        m_longestWord = m_answerDictionary.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
        CodeManager.Instance.KeyboardManager_.m_tempHold = "";
    }
}
