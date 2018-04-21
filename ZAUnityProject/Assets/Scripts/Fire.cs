using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public TheZucc attached;
    public AudioClip end;
	
	// Update is called once per frame
	void Update () {
        this.transform.position = attached.transform.position - new Vector3(0f, 1f, 0);
	}
}
