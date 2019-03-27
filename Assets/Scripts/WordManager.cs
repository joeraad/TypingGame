using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordManager : MonoBehaviour {

    public List<Word> words;
    private bool hasActiveWord;
    private Word activeWord;

    public NonLinearWordSpawner NonLinearWordSpawner;
    public LinearWordSpawner LinearWordSpawner;

    
    public void AddWord()
    {
        Word word;
        if (SceneManager.GetSceneByName("non-linear").Equals(SceneManager.GetActiveScene()))
        {
            word = new Word(WordGenerator.GetRandomWord(), NonLinearWordSpawner.SpawnWord());
        }
        else
        {
            word = new Word(WordGenerator.GetRandomWord(), LinearWordSpawner.SpawnWord());
        }


        words.Add(word);
    }

    public void TypeLetter(char letter)
    {
        if(GameManager.gameHasEnded)
        {
            return;
        }
        if (hasActiveWord)
        {
            //check if letter was next
            //remove from word
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach (Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }
        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }

    }
}
