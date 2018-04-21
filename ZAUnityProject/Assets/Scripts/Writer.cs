using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Writer : MonoBehaviour {

    public Text write;
    public LevelManager lm;

    public string[] strings;
    private int i = 0;
    private int j = 0;

    // Use this for initialization
    void Start () {
        strings[0] = "os.start()\n";
        strings[1] = "loading...\n";
        strings[2] = "load complete\n";
        strings[3] = "Instructions: \n";
        strings[4] = "\tLeft and Right Arrow Keys to move\n";
        strings[5] = "\tSpace Bar to begin hover protocol\n";
        strings[6] = "\tReturn Key to open doors\n";
        strings[7] = "Note:\n";
        strings[8] = "\tSystem requires power to function.\n";
        strings[9] = "\tLocate batteries to extend life\n";
        strings[10] = "\tInsects replenish health\n";
        strings[11] = "launching...\n";
    }
	
	// Update is called once per frame
	void Update () {
        i++;

        if (i % 60 == 0) {
            write.text += strings[j];
            j++;
        }

        if (j >= 12)
            lm.LoadLevel("LockedRoom");
    }
}
