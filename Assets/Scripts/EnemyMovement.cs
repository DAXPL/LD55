using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [HideInInspector] public IEnumerator moveTowardsPlayerCoruntine;

    public void StartEnemyMovementCoroutine(GameObject player) {
        moveTowardsPlayerCoruntine = MoveTowardsPlayer(player);
        StartCoroutine(moveTowardsPlayerCoruntine);
    }

    public void StopEnemyMovementCoroutine() {
        if (moveTowardsPlayerCoruntine == null) return;

        StopCoroutine(moveTowardsPlayerCoruntine);
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
