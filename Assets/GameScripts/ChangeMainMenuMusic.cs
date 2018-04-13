using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Fonction permettant la modification du volume de la musique du menu
 */ 

public class ChangeMainMenuMusic : MonoBehaviour {
    
    public AudioSource menuMusic;
    float volume;

	// Récupère le volume à partir des préférences du joueur, entrées dans les options
	void Start () {
        volume = PlayerPrefs.GetFloat("MusicVolume");
        // Applique le volume récupéré au volume de la musique du menu
        menuMusic.volume = volume;
	}
	
	// Récupère et applique à chaque frame le volume obtenu à partir des options
	void Update () {
        volume = PlayerPrefs.GetFloat("MusicVolume");
        menuMusic.volume = volume;
	}
}
