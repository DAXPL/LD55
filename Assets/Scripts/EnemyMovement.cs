using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public void StartEnemyMovementCoroutine(GameObject player) {
        StartCoroutine(MoveTowardsPlayer(player));
    }

    public IEnumerator MoveTowardsPlayer(GameObject player) {
        while (true) {
            transform.position = Vector3.MoveTowards(
                transform.position, player.transform.position, 1 * Time.deltaTime
                );
            yield return null;
        }
    }
}
