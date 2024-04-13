using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerShoot;

public class EnemyStats : MonoBehaviour, ISatisfactionable {
    public AbilityName abilityName;
    public NeedName needName;
    public float movementSpeed;
    public float needLevel;

    public void DecreaseLevel(int satisfaction) {
        needLevel -= satisfaction;

        if (needLevel <= 0) {
            Destroy(gameObject);
        }
    }
}
