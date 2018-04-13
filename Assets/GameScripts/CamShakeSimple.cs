using UnityEngine;
using System.Collections;

/**
 * Classe permettant le "camera shake" lorsque la balle touche un joueur
 */ 

public class CamShakeSimple : MonoBehaviour
{
    // Position normale de la camera
    Vector3 originalCameraPosition;

    // Puissance du "camera shake"
    float shakeAmt = 0;

    public Camera mainCamera;

    // Fonction provoquant le "camera shake" lorsque la balle touche un joueur
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            shakeAmt = 0.01f;
            // Appelle en boucle la fonction "CameraShake"
            InvokeRepeating("CameraShake", 0, .01f);

            Invoke("StopShaking", 0.3f);
        }
    }

    void CameraShake()
    {
        // Si la force du "camera shake" n'est pas nulle
        if (shakeAmt > 0)
        {
            // Génère une force de déplacement de la camera aleatoire
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.y += quakeAmt;
            pp.x += quakeAmt;
            // Applique le déplacement de la camera
            mainCamera.transform.position = pp;
        }
    }

    // Fonction restaurant la position originale de la camera et annulant l'appel répétitif à la fonction "CameraShake"
    void StopShaking()
    {
        originalCameraPosition.y = 0;
        originalCameraPosition.x = 0;
        originalCameraPosition.z = -10;

        CancelInvoke("CameraShake");
        mainCamera.transform.localPosition = originalCameraPosition;
    }

}