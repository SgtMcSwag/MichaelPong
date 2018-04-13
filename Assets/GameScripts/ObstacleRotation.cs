using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe gérant la rotation des obstacles pendant une partie en mode difficile
 */ 

public class ObstacleRotation : MonoBehaviour {
    
	// Fonction agissant sur les obstacles
	void Update () {
        // Provoque une rotation de l'obstacle
        transform.Rotate(new Vector2(50, 0) * Time.deltaTime);
        // Provoque un changement de forme de l'obstacle
        transform.Rotate(new Vector2(0, 50) * Time.deltaTime, Space.World);
    }
}
