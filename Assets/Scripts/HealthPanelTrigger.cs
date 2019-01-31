using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPanelTrigger : MonoBehaviour {

    public GameManager gamemanager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("end");
        gamemanager.EndGame();

    }

}
