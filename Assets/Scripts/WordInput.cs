using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour {

    public WordManager wordmanager;
	// Update is called once per frame
	void Update () {
        foreach (char letter in Input.inputString)
        {
            wordmanager.TypeLetter(letter);
        }
        
	}
}
