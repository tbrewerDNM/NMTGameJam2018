using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    private static TheZucc zucc;
    private static Cam cam;
    public static bool inDoor = false;
    public static bool inDoor2 = false;
    public static bool inDoor3 = false;
    public static bool inDoorRed = false;
    public static bool inDoorBlue = false;
    public static bool gateOpen;
    public static bool hasGun;
    public static bool hasKey;
    public static bool hasCoin;
    public static bool hasBear;
    public static bool hasRed = false;
    public static bool hasBlue;
    public static bool hasBinoc;
    public static int zuccHealth = 3;
    public static int shiroHealth = 7;

    void Start() {
        zucc = FindObjectOfType<TheZucc>();
        cam = FindObjectOfType<Cam>();
    }

    public static void ChangeScene(float zx, float cx) {
        zucc.transform.position = new Vector3(zx, zucc.transform.position.y, -5f);
        cam.transform.position = new Vector3(cx, 0, -10f);
    }

    public static void ChangeScene(float zx, float cx, float zy) {
        zucc.transform.position = new Vector3(zx, zy, -5f);
        cam.transform.position = new Vector3(cx, 0, -10f);
    }
}
