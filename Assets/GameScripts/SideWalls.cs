using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe gérant les collisions entre la balle et les buts
 */ 

public class SideWalls : MonoBehaviour {

    // Fonction permettant de détecter la collision de la balle contre un des murs latéraux
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball")
        {
            string wallName = transform.name;
            // Ajoute un point au score du joueur
            GameManager.Score(wallName);
            // Recommence la partie
            hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
    
}
