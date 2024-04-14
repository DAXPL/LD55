using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour, IDamageable {
    public AbilityName abilityName;
    public NeedName needName;
    public float movementSpeed;
    public float needLevel;
    private ParticleSystem particleSystem;
    private EnemyMovement enemyMovement;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] catSprites;

    private void Awake() {
        particleSystem = GetComponent<ParticleSystem>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    //Upoœledzony konstruktor
    public void SetCatStats(AbilityName _abilityName, NeedName _needName, float _movementSpeed, float _needLevel, GameObject player)
    {
        abilityName = _abilityName;
        needName = _needName;
        movementSpeed = _movementSpeed;
        needLevel = _needLevel;

        spriteRenderer.sprite = catSprites[(int)needName];

        enemyMovement.StartEnemyMovementCoroutine(player, movementSpeed);
    }

    public void Damage(int satisfaction, string givenNeedName) {
        Debug.Log($"{givenNeedName} - {needName.ToString()}");
        if (givenNeedName != needName.ToString()) return;

        needLevel -= satisfaction;
        particleSystem.Play();

        if (needLevel <= 0) {
            DisableCatPhysics();
            GameManager.instance.AddPoint();
            StartCoroutine(CatFade());
        }
    }

    private void OnTriggerEnter(Collider collision) {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null) {
            damageable.Damage(10, abilityName.ToString());
        }
    }

    private void DisableCatPhysics() {
        GetComponent<EnemyMovement>().StopEnemyMovementCoroutine();
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    private IEnumerator CatFade() {
        Color catColor = GetComponentInChildren<SpriteRenderer>().color;
        float alpha = catColor.a;

        while (alpha > 0) {
            alpha -= 0.1f;
            catColor.a = alpha;
            GetComponentInChildren<SpriteRenderer>().color = catColor;

            yield return new WaitForSeconds(0.1f);
        }

        Destroy(gameObject);
    }
}
