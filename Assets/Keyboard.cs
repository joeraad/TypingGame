using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Keyboard : MonoBehaviour
{

    public GameObject[] keys;
    public GameObject keyboard;
    private Transform row;
    public GameObject activeKey;
    private int characterIndex;
    private string currentCharacter;

    public TMP_Text m_TextComponent;



    private int keysIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<keyboard.transform.childCount;i++)
        {
            row = keyboard.transform.GetChild(i);
            Debug.Log(row.childCount);
            for (int j = 0; j < row.childCount; j++)
            {
                if(row.GetChild(j).name=="Spacing")
                {continue; } 
                keys[keysIndex] = row.GetChild(j).gameObject;
                keysIndex++;
            }

        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void ChangeKeyColor(GameObject key, bool correctLetter)
    {
        if (activeKey != null)
        {
            activeKey.GetComponent<Image>().color = Color.white;
        }

        activeKey = key;
        Debug.Log(activeKey);
        if (correctLetter)
        {
        activeKey.GetComponent<Image>().color = Color.green;
        }else
        {
        activeKey.GetComponent<Image>().color = Color.red;
        }

    }


}