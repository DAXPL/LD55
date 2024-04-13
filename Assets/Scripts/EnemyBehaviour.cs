using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    [SerializeField] private GameObject enemyTemplate;
    [SerializeField] private List<Enemy> enemyList;
    [SerializeField] private List<Material> enemySprites;

    IEnumerator Start () {
        while (true) {
            // Create an empty gameobject
            GameObject enemy = Instantiate(enemyTemplate);

            // Set the enemy material to a random one from a list
            enemy.GetComponent<MeshRenderer>().material = enemySprites[ChooseEnemySprite()];

            EnemyStats stats = enemy.GetComponent<EnemyStats>();

            // Set the stats of the enemy in the enemy script from a randomly chosen scriptable object
            stats.abilityName = enemyList[ChooseEnemyType()].abilityName;
            stats.needName = enemyList[ChooseEnemyType()].needName;
            stats.movementSpeed = enemyList[ChooseEnemyType()].movementSpeed;

            yield return new WaitForSeconds(1);
        }
    }

    private int ChooseEnemyType() {
        return Random.Range(0, enemyList.Count);
    }

    private int ChooseEnemySprite() {
        return Random.Range(0, enemySprites.Count);
    }
}
