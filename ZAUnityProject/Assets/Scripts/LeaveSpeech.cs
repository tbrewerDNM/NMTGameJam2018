using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveSpeech : MonoBehaviour {

    public Soldier soldier;

    void OnTriggerEnter2D(Collider2D collision) {
        if (soldier.messageOut) {
            Destroy(soldier.dbox.gameObject);
            soldier.messageOut = false;
        }
    }
}
