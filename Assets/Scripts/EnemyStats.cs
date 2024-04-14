using UnityEngine;

public class EnemyStats : MonoBehaviour, IDamageable {
    public AbilityName abilityName;
    public NeedName needName;
    public float movementSpeed;
    public float needLevel;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] catSprites;

    //Upoœledzony konstruktor
    public void SetCatStats(AbilityName _abilityName, NeedName _needName, float _movementSpeed, float _needLevel)
    {
        abilityName = _abilityName;
        needName = _needName;
        movementSpeed = _movementSpeed;
        needLevel = _needLevel;

        spriteRenderer.sprite = catSprites[(int)needName];
    }

    public void Damage(int satisfaction, string givenNeedName) {
        Debug.Log($"{givenNeedName} - {needName.ToString()}");
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
