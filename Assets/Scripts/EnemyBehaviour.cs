using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    [SerializeField] private GameObject enemyTemplate;
    [SerializeField] private List<Enemy> enemyList;
    [SerializeField] private List<Sprite> enemySprites;
    [SerializeField] private GameObject player;

    IEnumerator Start () {
        while (true) {
            // Create an empty gameobject
            GameObject enemy = Instantiate(enemyTemplate);

            // Set the enemy material to a random one from a list
            enemy.GetComponent<SpriteRenderer>().sprite = enemySprites[ChooseEnemySprite()];

            // Set the enemy target to player
            enemy.GetComponent<EnemyMovement>().StartEnemyMovementCoroutine(player);

            EnemyStats stats = enemy.GetComponent<EnemyStats>();

            // Set the stats of the enemy in the enemy script from a randomly chosen scriptable object
            stats.abilityName = enemyList[ChooseEnemyType()].abilityName;
            stats.needName = enemyList[ChooseEnemyType()].needName;
            stats.movementSpeed = enemyList[ChooseEnemyType()].movementSpeed;
            stats.needLevel = enemyList[ChooseEnemyType()].needLevel;

            yield return new WaitForSeconds(20);
        }
    }

    private int ChooseEnemyType() {
        return Random.Range(0, enemyList.Count);
    }

    private int ChooseEnemySprite() {
        return Random.Range(0, enemySprites.Count);
    }
}