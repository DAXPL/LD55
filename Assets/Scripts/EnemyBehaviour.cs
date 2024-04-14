using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    [SerializeField] private GameObject enemyTemplate;
    [SerializeField] private List<Enemy> enemyList;
    [SerializeField] private List<Sprite> enemySprites;
    [SerializeField] private GameObject player;
    [HideInInspector] public float timeBetweenEnemySpawn;
    public int numberOfExtraCatsSummoned;

    IEnumerator Start () {
        while (true) {
            SpawnACat();
            if (numberOfExtraCatsSummoned > 0) {
                for (int i = 0; i < numberOfExtraCatsSummoned; i++) {
                    SpawnACat();
                }
            }

            yield return new WaitForSeconds(timeBetweenEnemySpawn);
        }
    }

    private void SpawnACat() {
        // Create an empty gameobject
        GameObject enemy = Instantiate(enemyTemplate);

        // Set the enemy material to a random one from a list
        // Thanks to memory pointers this is not necessary
        // enemy.GetComponent<SpriteRenderer>().sprite = enemySprites[ChooseEnemySprite()];

        // Set the enemy target to player
        enemy.GetComponent<EnemyMovement>().StartEnemyMovementCoroutine(player);

        EnemyStats stats = enemy.GetComponent<EnemyStats>();

        // Set the stats of the enemy in the enemy script from a randomly chosen scriptable object
        // This is very bad. Cat is a object so we should hermitize this
        // Btw losujesz innego kota co liniê. To tak mia³o byæ?
        //stats.abilityName = enemyList[ChooseEnemyType()].abilityName;
        //stats.needName = enemyList[ChooseEnemyType()].needName;
        //stats.movementSpeed = enemyList[ChooseEnemyType()].movementSpeed;
        //stats.needLevel = enemyList[ChooseEnemyType()].needLevel;
        Enemy e = enemyList[ChooseEnemyType()];
        stats.SetCatStats(e.abilityName, e.needName, e.movementSpeed, e.needLevel);

    }

    private int ChooseEnemyType() {
        return Random.Range(0, enemyList.Count);
    }

    private int ChooseEnemySprite() {
        return Random.Range(0, enemySprites.Count);
    }
}
