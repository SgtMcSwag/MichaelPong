using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe gérant les contrôles des joueurs
 */

public class PlayerControls : MonoBehaviour {

    // Touches modifiant la position du joueur (modifiables dans l'interface unity)
    public KeyCode moveUp = KeyCode.Z;
    public KeyCode moveDown = KeyCode.S;
    
    // Vitesse de chaque joueur
    public float speed = 10.0f;
    // Position maximale de chaque joueur
    public float boundY = 2.25f;
    // Référence au RigidBody des joueurs
    private Rigidbody2D rb2d;


    // Initialise notre RigidBody au démarrage de la partie
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Applique les changements de position à chaque frame et la pause si le bouton correspondant est pressé
	void Update () {

        

        var vel = rb2d.velocity;
        // Modifie le sens de déplacement du joueur selon la touche pressée
        if (Input.GetKey(moveUp))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed;
        }
        else if (!Input.anyKey)
        {
            vel.y = 0;
        }

        rb2d.velocity = vel;
        
        var pos = transform.position;

        //Vérifie la position du joueur par rapport à la limite fixée
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        // Applique le déplacement du joueur
        transform.position = pos;
    }
}
