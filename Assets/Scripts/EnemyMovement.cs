using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [HideInInspector] public IEnumerator moveTowardsPlayerCoruntine;

    public void StartEnemyMovementCoroutine(GameObject player, float moveSpeed) {
        moveTowardsPlayerCoruntine = MoveTowardsPlayer(player, moveSpeed);
        StartCoroutine(moveTowardsPlayerCoruntine);
    }

    public void StopEnemyMovementCoroutine() {
        if (moveTowardsPlayerCoruntine == null) return;

        StopCoroutine(moveTowardsPlayerCoruntine);
    }



    public IEnumerator MoveTowardsPlayer(GameObject player, float moveSpeed) {
        while (true) {
            transform.position = Vector3.MoveTowards(
                transform.position, player.transform.position, moveSpeed * Time.deltaTime
                );
            yield return null;
        }
    }
}
