using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public Texture backgroundTexture;

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0,0,Screen.height, Screen.width), backgroundTexture);
    }
}
