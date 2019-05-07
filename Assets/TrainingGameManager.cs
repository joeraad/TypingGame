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
    public TrainingWordDisplay wordDisplay;
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
            
        }
    }


    void CheckLetter(string letter)
    {
        if(textIndex>=text.Length)
        {
            return;
        }

        Debug.Log(text[textIndex]);
        Debug.Log(letter);
        Debug.Log(text[textIndex].ToString().Equals(letter.ToString()));
        if (text[textIndex].ToString().Equals(letter.ToString()))
        {
            keyboard.ChangeKeyColor(Key[letter.ToString()], true);
            wordDisplay.ChangeCharacterColor(textIndex,true);
            textIndex++;
        }else
        {
            keyboard.ChangeKeyColor(Key[letter.ToString()], false);
            wordDisplay.ChangeCharacterColor(textIndex,false);
            textIndex++;
        }

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
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            if (text[textIndex].ToString().Equals("\n"))
            {
                keyboard.ChangeKeyColor(Key["ENTER"], true);
                textIndex++;
                return true;
            }
            else
            {
                keyboard.ChangeKeyColor(Key["ENTER"], false);
                textIndex++;
                return true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (text[textIndex].ToString().Equals(" "))
            {
                keyboard.ChangeKeyColor(Key["SPACE"], true);
                textIndex++;
                return true;
            }
            else
            {
                keyboard.ChangeKeyColor(Key["SPACE"], false);
                textIndex++;
                return true;
            }
            
        } 
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            keyboard.ChangeKeyColor(Key["BackSpace"], true);
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            keyboard.ChangeKeyColor(Key["Tab"], true);
            return true;
        }

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            keyboard.ChangeKeyColor(Key["CAPS"], true);
            return true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            keyboard.ChangeKeyColor(Key["LEFTSHIFT"], true);
            return true;
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            keyboard.ChangeKeyColor(Key["RIGHTSHIFT"], true);
            return true;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            keyboard.ChangeKeyColor(Key["LEFTCRTL"], true);
            return true;
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            keyboard.ChangeKeyColor(Key["LEFTALT"], true);
            return true;
        }
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            keyboard.ChangeKeyColor(Key["RIGHTALT"], true);
            return true;
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            keyboard.ChangeKeyColor(Key["RIGHTCRTL"], true);
            return true;
        }
        return false;
    }
}
