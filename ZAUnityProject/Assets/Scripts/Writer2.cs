using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Writer2 : MonoBehaviour {

    public Text write;
    public LevelManager lm;

    public string[] strings;
    private int i = 0;
    private int j = 0;

    // Use this for initialization
    void Start () {
        strings[0] = "I transform into my reptilian form to escape\n";
        strings[1] = "However, a man who appears to have lost everything appears\n";
        strings[2] = "He readies a sword. Danger readings are off the charts\n";
        strings[3] = "Must eliminate foe.\n";
        strings[4] = "";
    }
	
	// Update is called once per frame
	void Update () {
        i++;

        if (i % 80 == 0) {
            write.text += strings[j];
            j++;
        }

        if (j >= 5)
            lm.LoadLevel("Boss");
	}
}
