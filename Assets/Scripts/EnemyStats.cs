using UnityEngine;

public class EnemyStats : MonoBehaviour, IDamageable {
    public AbilityName abilityName;
    public NeedName needName;
    public float movementSpeed;
    public float needLevel;

    public void Damage(int satisfaction, NeedName givenNeedName) {
        if (givenNeedName != needName) return;

        needLevel -= satisfaction;

        if (needLevel <= 0) {
            Destroy(gameObject);
        }
    }

}
