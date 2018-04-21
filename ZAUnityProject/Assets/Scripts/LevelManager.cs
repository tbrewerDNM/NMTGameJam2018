using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public AudioClip select;
    public AudioSource selectsfx;
    public Text control1;
    private string back;

    private void Start() {
        back = "Start";
    }

    private void Update() {
        //print(Input.GetAxis("LeftJoystickY"));
    }

    public void GoBack() {
        LoadLevel(back);
    }

    public void LoadLevel(string name) {
        back = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }
    
    public void QuitRequest() {
        Application.Quit();
    }

    public void LoadNextLevel() {
        back = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }   


}
