using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class KeyboardManager : MonoBehaviour
{
    
    public char[] m_typedLetter;
    public string m_tempHold;

    public int counter = 0;

    public TMP_InputField inputField;
    public TextMeshProUGUI question;

    public string m_guessedWord;

    public float m_restartDelay = 2.5f;

    public SpawnPlayerManager SpawnPlayerManager_;

    public SpawnLetters SpawnLetters_;

    // Start is called before the first frame update
    void Start()
    {
        RefreshEverything();
    }

    public void KeyPressed(string _key)
    {
        ValidationCheck(_key);
    }
    

    public void BackSpace()
    {
        if (counter > 0) //Check if we are at the start of the word
        {
            counter--;
            m_tempHold = m_tempHold.Remove(m_tempHold.Length - 1);
        }
    }


    public void Enter()
    {
        m_guessedWord = m_tempHold;

        string newtemp = m_guessedWord.Replace(" ", "");
        Debug.Log(newtemp.Length);


        switch (CodeManager.Instance.DictionaryManager_.m_answerDictionary.Contains(m_guessedWord)) // Check if word exist in dictionary
        {
            case true:  
                //TODO
                // If true then get word length 
                Debug.Log("" + m_guessedWord.Length);
                SpawnPlayerManager_.MassSpawn(m_guessedWord.Length);

                Debug.Log("Create path size based of number length");

                switch (m_guessedWord.Length == CodeManager.Instance.DictionaryManager_.m_longestWord.Length) // Just for perfect effect or sth of the sort
                {
                    case true:
                        //TO DO LONG WORD
                        Debug.Log("Case for when Equal");
                        Debug.Log("Display perfect effect or sth of the sort");
                        break;
                    case false:
                        break;
                }
                //RefreshEverything();    
                break;
            case false:
                Debug.Log("Wrong Answer, Clear board or sth");
                //Restart();
                break;
        }

        StartCoroutine(SwitchLoop());   
        Invoke("TriggerRestart", 2f);
    }


    IEnumerator SwitchLoop() 
    {
        for (int i = SpawnLetters_.Spawned.Count - 1; i >= 0; i--) 
        {
            SpawnLetters_.Spawned[i].GetComponent<SwitchLetter>().Switch();
            yield return new WaitForSeconds(0.18f);
        }
    }


    public void TriggerRestart() 
    {
        Restart();
    }

    public void ValidationCheck(string letter)
    {
        m_typedLetter = letter.ToLower().ToCharArray();
        m_tempHold = m_tempHold +""+  m_typedLetter[0].ToString();
        counter++;
    }

    public void Restart()
    {
        counter = 0;
        m_tempHold = "";
        ClearFields(inputField);
    }

    public void ClearFields(TMP_InputField inputFields)
    {
        inputFields.text = "";
    }

    IEnumerator DelayBeforeRestart(float delay)
    {
        yield return new WaitForSeconds(delay);
        Restart();
    }

    // Used on level reset
    public void RefreshEverything()                 
    {
        counter = 0;
        m_tempHold = "";
        question.text = CodeManager.Instance.DictionaryManager_.m_questionDictionary[0];
    }
}
