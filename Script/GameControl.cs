using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class GameControl : MonoBehaviour {

    private ThirdPersonCharacter player;

    // Events handler 
    public delegate void EventController();
    public static event EventController events;

    public delegate void DoorsEvents();
    public static event DoorsEvents door;

    public delegate void PlayerHandler(ThirdPersonCharacter player);
    public static PlayerHandler playerEvents;

    // Singleton patter, avoid multiple controllers
    public static GameControl instance;

    public static bool doors = false;

    // Use this for initialization
    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {// If it's not this, destroy it
            Destroy(gameObject);
        }
    }

    void Start() {
        // Find the player
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<ThirdPersonCharacter>();
    }

    // Update is called once per frame
    void Update() {
        // Check always it's not null befor invoking it
        if (events != null)
            events();

        if (playerEvents != null) {
            playerEvents(player);
            // We just want that the event excecute one time
            playerEvents = null;
        }

        if (doors) {
            door();
            doors = false;
        }
    }
}
