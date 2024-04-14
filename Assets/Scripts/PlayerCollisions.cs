using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class PlayerCollisions : MonoBehaviour, IDamageable {
    private int health;//Hp powinno byæ prywatne
    private bool isAlive = true;
    [SerializeField] private GameObject deathCanvas;
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

    }

    public void Scratch(int value) {
        health -= value;

        if (health <= 0) {
            NeutralizePlayer();
        }
    }

    public void Kick(int value) {
        health -= value;

        if (health <= 0) {
            NeutralizePlayer();
        }
    }

    public void Bite(int value) {
        health -= value;

        if (health <= 0) {
            NeutralizePlayer();
        }
    }

    public void Pee(int value) {
        health -= value;

        if (health <= 0) {
            NeutralizePlayer();
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
