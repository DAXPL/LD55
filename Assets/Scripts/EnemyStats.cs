using UnityEngine;

public class EnemyStats : MonoBehaviour, IDamageable {
    public AbilityName abilityName;
    public NeedName needName;
    public float movementSpeed;
    public float needLevel;

    public void Damage(int satisfaction, string givenNeedName) {
        if (givenNeedName != needName.ToString()) return;

        needLevel -= satisfaction;

        if (needLevel <= 0) {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider collision) {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null) {
            damageable.Damage(10, abilityName.ToString());
        }
    }

}
