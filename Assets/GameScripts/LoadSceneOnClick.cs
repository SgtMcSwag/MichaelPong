using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Classe permettant de changer de scène
 */ 

public class LoadSceneOnClick : MonoBehaviour {

    // Fonction chargeant une nouvelle scène dont l'index est passé en paramètre
	public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
