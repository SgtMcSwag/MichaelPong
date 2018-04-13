using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe gérant les contrôles de la balle
 */ 

public class BallControl : MonoBehaviour {
    
    private Rigidbody2D rb2d;
    private Vector2 vel;
    private TrailRenderer myTrail;
    private ParticleSystem particles;
    private AudioSource explosion;

    // Fonction de départ de la balle
    // Choisis une direction aléatoire
    void GoBall()
    {
        float rand = Random.Range(0, 2);
        float rand2 = Random.Range(0, -15);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, rand2));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, rand2));
        }
    }

    // Fonction de reset de la balle après une condition de victoire
    void ResetBall()
    {
        myTrail.Clear();
        vel = Vector2.zero;
        rb2d.velocity = vel;
        transform.position = Vector2.zero;
    }

    // Fonction de redémarrage de la partie appelée après pression du bouton correspondant
    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    // Fonction de gestion de collision de la balle
    // Calcule la vitesse résultante de la balle en fonction de la vitesse du paddle et de la balle
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            explosion.Play();
            particles.Emit(20);

            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
            rb2d.velocity = vel;
        }
    }

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        myTrail = GetComponent<TrailRenderer>();
        particles = GetComponent<ParticleSystem>();
        explosion = GetComponent<AudioSource>();
        explosion.playOnAwake = false;
        Invoke("GoBall", 2);
    }
	
	// Update is called once per frame
	void Update () {
        explosion.volume = PlayerPrefs.GetFloat("EffectVolume");
	}
}
