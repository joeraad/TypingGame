using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour {


    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, Wordlists.testinglist.Length);
        string randomWord = Wordlists.testinglist[randomIndex];
        return randomWord;
    }
}
