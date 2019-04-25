using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrainingGameManager :MonoBehaviour
{
    public TextMeshProUGUI textField;
    private string text;
    private int textIndex;
    public Keyboard keyboard;
    public GameObject activeKey;
    public GameObject [] keys;
    public Dictionary<string, GameObject> Key = new Dictionary<string, GameObject>();
    private string[] keyNames= { "`", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=", "BackSpace",
        "Tab", "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "[", "]", "\\",
        "CAPS","a","s","d","f","g","h","j","k","l",";","'","ENTER",
        "LEFTSHIFT","z","x","c","v","b","n","m",",",".","/","RIGHTSHIFT",
        "LEFTCRTL","LEFTALT","SPACE","RIGHTALT","RIGHTCRTL" };

    private string[] capsKeyNames ={"~","!","@","#","$","%","^","&","*","(",")","_","+",
        "Q","W","E","R","T","Y","U","I","O","P","{","}","|",
        "A","S","D","F","G","H","J","K","L",":","\"",
        "Z","X","C","V","B","N","M","<",">","?"};


    // Start is called before the first frame update
    void Start()
    {
        CreateDictionary();
        text = textField.text;
        

        /**
        *foreach (KeyValuePair<string, GameObject> k in Key)
        *{
        *    Debug.Log(k.Key + " " + k.Value);
        *}
        **/

        Debug.Log(Key.ContainsKey("`"));
        Debug.Log(Key["`"]);
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckCommandKeys())
            return;
        foreach (char letter in Input.inputString)
        {
            CheckLetter(letter.ToString());
            ChangeColor(letter.ToString());
        }
    }


    void CheckLetter(string letter)
    {
        if(textIndex>=text.Length)
        {
            return;
        }


        if (text[textIndex].Equals(letter))
        {
            keyboard.ChangeKeyColor(Key[letter.ToString()], true);
            textIndex++;
        }else
        {
            keyboard.ChangeKeyColor(Key[letter.ToString()], false);
            textIndex++;
        }

    }
    void ChangeColor(string letter)
    {
        if (activeKey != null)
        {
            activeKey.GetComponent<Image>().color = Color.white;
        }
        activeKey = Key[letter.ToString()];
        Debug.Log(activeKey);
        activeKey.GetComponent<Image>().color=Color.green;
    }

    void CreateDictionary()
    {
        for(int i=0; i<58; i++)
        {
            Key.Add(keyNames[i], keys[i]);
        }

        for (int i = 0; i < 13; i++)
        {
            Key.Add(capsKeyNames[i], keys[i]);
        }
        for (int i = 15; i < 28; i++)
        {
            Key.Add(capsKeyNames[i-2], keys[i]);
        }
        for (int i = 29; i < 40; i++)
        {
            Key.Add(capsKeyNames[i-3], keys[i]);
        }
        for (int i = 42; i < 52; i++)
        {
            Key.Add(capsKeyNames[i-5], keys[i]);
        }


    }
    bool CheckCommandKeys()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ChangeColor("BackSpace");
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeColor("Tab");
            return true;
        }
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            ChangeColor("CAPS");
            return true;
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            ChangeColor("ENTER");
            return true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ChangeColor("LEFTSHIFT");
            return true;
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            ChangeColor("RIGHTSHIFT");
            return true;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ChangeColor("LEFTCRTL");
            return true;
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            ChangeColor("LEFTALT");
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor("SPACE");
            return true;
        }
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            ChangeColor("RIGHTALT");
            return true;
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            ChangeColor("RIGHTCRTL");
            return true;
        }
        return false;
    }
}
