using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PlayerCollisions : MonoBehaviour, IDamageable {
    private int health = 100;//Hp powinno by� prywatne
    private bool isAlive = true;
    [SerializeField] private GameObject deathCanvas;
    private ParticleSystem particleSystem;
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject screenColorDamage;
    [SerializeField] private GameObject screenColorPee;
    [SerializeField] private GameObject biteScreenEffect;
    [SerializeField] private GameObject ScratchScreenEffect;
    [SerializeField] private GameObject kickScreenEffect;

    private void Awake() {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start() {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    public void Damage(int damage, string attackName) {
        switch (attackName) {
            case "scratch":
                Scratch(damage);
            break;

            case "kick":
                Kick(damage);
            break;

            case "bite":
                Bite(damage);
            break;

            case "pee":
                Pee(damage);
            break;
        }

        UpdatePlayerHealthBar();
    }

    private void UpdatePlayerHealthBar() {
        healthBar.value = health;
    }

    public void Scratch(int value) {
        health -= value;
        StartCoroutine(ScreenColorChange(ScratchScreenEffect));

        if (health <= 0) {
            NeutralizePlayer();
        }
    }

    public void Kick(int value) {
        health -= value;
        StartCoroutine(ScreenColorChange(kickScreenEffect));

        if (health <= 0) {
            NeutralizePlayer();
        }
    }

    public void Bite(int value) {
        health -= value;
        StartCoroutine(ScreenColorChange(biteScreenEffect));

        if (health <= 0) {
            NeutralizePlayer();
        }
    }

    public void Pee(int value) {
        health -= value;

        particleSystem.Stop();
        StartCoroutine(PlayPeeParticle());

        if (health <= 0) {
            NeutralizePlayer();
        }
    }

    private IEnumerator ScreenColorChange(GameObject damageText) {
        screenColorDamage.SetActive(true);
        damageText.SetActive(true);
        yield return new WaitForSeconds(1);
        screenColorDamage.SetActive(false);
        damageText.SetActive(false);
    }

    public IEnumerator PlayPeeParticle() {
        particleSystem.Play();
        screenColorPee.SetActive(true);
        if (TryGetComponent(out Player p)) {
            float defaultPlayerSpeed = p.GetPlayerSpeed();

            p.ChangePlayerSpeed(3);
            yield return new WaitForSeconds(1.5f);
            p.ChangePlayerSpeed(defaultPlayerSpeed);
            screenColorPee.SetActive(false);
        }
    }

    private void NeutralizePlayer()
    {
        if(isAlive)
        {
            isAlive = false;//Semaphore
            StartCoroutine(DeathSentence());
        }
    }

    IEnumerator DeathSentence()
    {
        Debug.Log("Player Death");
        if (TryGetComponent(out Player p))
        {
            p.ChangePlayerSpeed(0);
            p.TogglePlayerActions(false);
        }
        deathCanvas.SetActive(true);
        //Play death sound here
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
