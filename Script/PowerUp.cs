using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PowerUp : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
            GameControl.playerEvents = increasePower;
    }

    private void increasePower(ThirdPersonCharacter player) {
        player.power++;
        player.updatePowerMessage();
    }
}
