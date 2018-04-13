using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Fonction de gestion globale de la partie
 */ 

public class GameManager : MonoBehaviour {
    
    // Score des deux joueurs
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    // Touche permettant de mettre le jeu en pause
    public KeyCode pause = KeyCode.Escape;

    // Variable indiquant si le jeu est en pause
    private bool pausedGame = false;

    public GameObject player;
    
    public GUISkin layout;
    
    GameObject theBall;

    // Son joué à l'issue de la partie
    private static AudioSource gameOver;

    // Fonction gérant l'ajout de point après un but et jouant le son de fin de partie en cas de condition de victoire
    public static void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            if (PlayerScore1 == 9)
                gameOver.Play();

            PlayerScore1++;
        }
        else
        {
            if (PlayerScore2 == 9)
                gameOver.Play();

            PlayerScore2++;
        }
    }
    
    // Fonction gérant les affichages de boutons / scores sur l'écran de jeu
    void OnGUI()
    {
        GUI.skin = layout;

        // Affichage des scores des joueurs
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

        // Affichage et gestion du bouton "RESTART" permettant de recommencer la partie
        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        // Affichage et gestion du bouton de retour vers le menu
        if (GUI.Button(new Rect(Screen.width / 5 - 60, 35, 120, 53), "MENU"))
        {
            SceneManager.LoadScene(0);
        }

        // Affiche le bouton "RESUME" permettant de reprendre la partie si le jeu est en pause
        if (pausedGame)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 60, 200, 120, 53), "RESUME"))
            {
                Time.timeScale = 1;
                pausedGame = false;
            }
        }
        
        // Affiche "PLAYER ONE WINS" en cas de victoire du premier joueur et reset la balle
        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        // Affiche "PLAYER TWO WINS" en cas de victoire du second joueur et reset la balle
        else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
    
    // Initialise les gameObjects et empêche le son de fin de partie d'être joué au début
    void Start () {
        theBall = GameObject.FindGameObjectWithTag("Ball");
        gameOver = GetComponent<AudioSource>();
        gameOver.playOnAwake = false;
    }
	
    // Modifie le volume du son de fin de partie à partir des options et place le jeu en pause si la bonne touche est pressée
	void Update () {
        gameOver.volume = PlayerPrefs.GetFloat("EffectVolume");

        // Met le jeu en pause si la bonne touche est pressée
        if (Input.GetKey(pause))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pausedGame = true;
            }
        }
    }
}
