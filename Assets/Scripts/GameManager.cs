using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private int points;
    [SerializeField] private EnemyBehaviour enemyBehaviour;
    [SerializeField] private TextMeshProUGUI pointsUI;

    public static GameManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Debug.LogError("There is more than 1 GameManager on the scene");
        }
    }

    public void AddPoint() {
        points++;
        UpdateUI();

        if (points >= 5) {
            enemyBehaviour.timeBetweenEnemySpawn -= 0.5f;

            int milestone = points / 10;

            if (milestone > enemyBehaviour.numberOfExtraCatsSummoned) {
                enemyBehaviour.numberOfExtraCatsSummoned = milestone;
            }
        }

        
    }

    private void UpdateUI() {
        pointsUI.SetText($"Cats satisfied: {points}");
    }
}
