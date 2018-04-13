using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe permettant de quitter l'application
 */ 

public class QuitOnClick : MonoBehaviour {

    // Fonction quittant l'application
	public void Quit ()
    {
        // Si on se trouve dans Unity
#if UNITY_EDITOR
        // Quitte le mode "Play"
        UnityEditor.EditorApplication.isPlaying = false;
        // Sinon quitte l'application
#else
        Application.Quit();
#endif
    }
}
