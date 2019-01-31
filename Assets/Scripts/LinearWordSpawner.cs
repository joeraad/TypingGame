using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearWordSpawner : MonoBehaviour {

    public GameObject wordPrefab;
    public Transform wordCanvas;
    public WordDisplay SpawnWord()
    {

        Vector3 randomPosition = new Vector3(5f,1f);

        GameObject wordObj= Instantiate(wordPrefab,randomPosition,Quaternion.identity,wordCanvas);
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
        return wordDisplay;
    }
}
