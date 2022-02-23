using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private int m_difficultyLevel;
    [Range(1, 10)]
    [SerializeField] private int m_guessDifficultyLevel;

    public SpawnPlayerManager SpawnPlayerManager_;

    [SerializeField] private char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

    public char[] dictionary;                        // This is the word/item we're trying to identify split into letters, for now is initialised here but can be obtained from the game manager and split into this list on a per letter basis

    public char[] m_variablesToGuess;

    public char[] m_myGuess;

    public string m_dictionaryWord;
    public string m_guessedWord;

    //public TextMeshProUGUI[] inputFields;
    //public GameManager gameManager;

    public int counter = 0;

    public float m_guessDelay = 2f;
    public float m_restartDelay = 2.5f;

    //public FailHandSequence FailHandSequence_;

    //public ExtendArm ExtendArm_;

    //public GrabSequence GrabSequence_GrabObject;

    //public TextMeshProUGUI EnemyTyping;

    //public Animator Typing;



    // Start is called before the first frame update
    void Start()
    {
        DelayBefore();

        SelectRandomAnswer(m_difficultyLevel);
        EnemyRangeRandomiser(m_guessDifficultyLevel);
        m_myGuess = new char[dictionary.Length];
        GuessLetter();
    }

    public void DelayBefore()
    {
        Invoke("RefreshEverything", 0.2f);
    }

    // Used on level reset
    [ContextMenu("Refresh Everything")]
    public void RefreshEverything()                 // Function to update the enemy dictionary
    {
        //EnemyTyping.text = "";
        // Reset counter to 0;
        counter = 0;

        // Clear Dictionary
        dictionary = null;

        // Select random answer to guess
        SelectRandomAnswer(m_difficultyLevel);

        // Refresh the variables to guess from as well
        EnemyRangeRandomiser(m_guessDifficultyLevel);

        // Refresh Guess size as well
        m_myGuess = new char[dictionary.Length];

        // Clear both word fields
        m_dictionaryWord = null;
        m_guessedWord = null;

        // Start guessing on Refresh
        GuessLetter();
    }

    public void SelectRandomAnswer(int range)
    {
        switch (range)
        {
            case 1:
                dictionary = CodeManager.Instance.DictionaryManager_.m_longestWord.ToLower().ToCharArray();
                break;
            case 2:
                dictionary = CodeManager.Instance.DictionaryManager_.m_answerDictionary[Random.Range(0, (CodeManager.Instance.DictionaryManager_.m_answerDictionary.Capacity - 9))].ToLower().ToCharArray();  //0 to 1 since capacity is always 10 thus the subtraction
                break;
            case 3:
                dictionary = CodeManager.Instance.DictionaryManager_.m_answerDictionary[Random.Range(0, (CodeManager.Instance.DictionaryManager_.m_answerDictionary.Capacity - 8))].ToLower().ToCharArray(); // 0 to 2
                break;
            case 4:
                dictionary = CodeManager.Instance.DictionaryManager_.m_answerDictionary[Random.Range(0, (CodeManager.Instance.DictionaryManager_.m_answerDictionary.Capacity - 7))].ToLower().ToCharArray(); // 0 to 3
                break;
            case 5:
                dictionary = CodeManager.Instance.DictionaryManager_.m_answerDictionary[Random.Range(0, (CodeManager.Instance.DictionaryManager_.m_answerDictionary.Capacity - 6))].ToLower().ToCharArray(); // 0 to 4
                break;
            case 6:
                dictionary = CodeManager.Instance.DictionaryManager_.m_answerDictionary[Random.Range(0, (CodeManager.Instance.DictionaryManager_.m_answerDictionary.Capacity - 5))].ToLower().ToCharArray(); // 0 to 5
                break;
            case 7:
                dictionary = CodeManager.Instance.DictionaryManager_.m_answerDictionary[Random.Range(0, (CodeManager.Instance.DictionaryManager_.m_answerDictionary.Capacity - 4))].ToLower().ToCharArray(); // 0 to 6
                break;
            case 8:
                dictionary = CodeManager.Instance.DictionaryManager_.m_answerDictionary[Random.Range(0, (CodeManager.Instance.DictionaryManager_.m_answerDictionary.Capacity - 3))].ToLower().ToCharArray(); // 0 to 7
                break;
            case 9:
                dictionary = CodeManager.Instance.DictionaryManager_.m_answerDictionary[Random.Range(0, (CodeManager.Instance.DictionaryManager_.m_answerDictionary.Capacity - 2))].ToLower().ToCharArray(); // 0 to 8
                break;
            case 10:
                dictionary = CodeManager.Instance.DictionaryManager_.m_answerDictionary[Random.Range(0, (CodeManager.Instance.DictionaryManager_.m_answerDictionary.Capacity - 1))].ToLower().ToCharArray(); // 0 to 9
                break;
        }
    }

    public void EnemyRangeRandomiser(int range)
    {
        switch (range)
        {
            case 1:
                m_variablesToGuess = new char[m_guessDifficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                break;
            case 2:
                m_variablesToGuess = new char[m_guessDifficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i=1; i < m_guessDifficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 3:
                m_variablesToGuess = new char[m_guessDifficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_guessDifficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 4:
                m_variablesToGuess = new char[m_guessDifficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_guessDifficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 5:
                m_variablesToGuess = new char[m_guessDifficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_guessDifficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 6:
                m_variablesToGuess = new char[m_guessDifficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_guessDifficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 7:
                m_variablesToGuess = new char[m_guessDifficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_guessDifficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 8:
                m_variablesToGuess = new char[m_guessDifficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_guessDifficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 9:
                m_variablesToGuess = new char[m_guessDifficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_guessDifficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
            case 10:
                m_variablesToGuess = new char[m_guessDifficultyLevel];
                m_variablesToGuess[0] = dictionary[counter];
                for (int i = 1; i < m_guessDifficultyLevel; i++)
                {
                    m_variablesToGuess[i] = alphabet[Random.Range(0, alphabet.Length)];
                }
                break;
        }
    }


    // Used on level reset
    [ContextMenu("Randomise Letters to Guess")]
    public void Randomise()
    {
        EnemyRangeRandomiser(m_guessDifficultyLevel);
    }

    [ContextMenu("Guess a Letter")]
    public void GuessLetter()
    {
        // Guesses a letter within the range and adds it to the array
        m_myGuess[counter] = m_variablesToGuess[Random.Range(0, m_guessDifficultyLevel)];

        //EnemyTyping.SetText(EnemyTyping.text + "" + m_myGuess[counter].ToString().ToUpper());
        //Typing.Play("Bounce", -1, 0);

        EnemyRangeRandomiser(m_guessDifficultyLevel);
        counter++;
       

        //ExtendArm_.IncreaseSize();

        switch (counter != dictionary.Length)
        {
            case true:                
                m_variablesToGuess[0] = dictionary[counter];
                StartCoroutine(GuessAfterDelay(m_guessDelay));
                break;
            case false:
                // Validate word created
                EnemyValidationCheck();
                break;
        }
    }

    [ContextMenu("Validation Check")]
    public void EnemyValidationCheck()
    {
        m_guessedWord = new string(m_myGuess);

        switch (CodeManager.Instance.DictionaryManager_.m_answerDictionary.Contains(m_guessedWord))
        {
            case true:
                Debug.Log("Correct!");
                SpawnPlayerManager_.MassSpawn(m_guessedWord.Length);
                // Game Over Fn
                break;
            case false:
                Debug.Log("Wrong!");
                StartCoroutine(PauseBeforeRestart(m_restartDelay));
                break;
        }

        RefreshEverything();
    }


    [ContextMenu("Restart Guess")]
    public void Restart()
    {
        //EnemyTyping.text = "";
        m_myGuess = new char[dictionary.Length];
        counter = 0;
        m_variablesToGuess[0] = dictionary[counter];
        GuessLetter();
    }

    IEnumerator GuessAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GuessLetter();
    }

    IEnumerator PauseBeforeRestart(float delay)
    {
        //Slap Back
        //FailHandSequence_.StartFailSequence();

        yield return new WaitForSeconds(delay);
        Restart();
    }

    public void StopAllJobs()
    {
        StopAllCoroutines();
    }
}
