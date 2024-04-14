using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggHiddenRoom : MonoBehaviour {
    [SerializeField] private GameObject hiddenRoom;
    [SerializeField] private GameObject hiddenRoomElements;


    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            hiddenRoom.SetActive(true);
            hiddenRoomElements.SetActive(true);
        }
    }
}
