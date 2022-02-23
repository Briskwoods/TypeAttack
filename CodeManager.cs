using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeManager : MonoBehaviour
{
    private static CodeManager _instance;
    public static CodeManager Instance { get { return _instance; } }

    public KeyboardManager KeyboardManager_;
    public GameManager GameManager_;
    public DictionaryManager DictionaryManager_;
    public Test Test_;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
