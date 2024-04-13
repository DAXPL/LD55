using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerCollisions : MonoBehaviour, IDamageable {
    public int health;

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
            Destroy(gameObject);
        }
    }

    public void Kick(int value) {
        health -= value;

        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    public void Bite(int value) {
        health -= value;

        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    public void Pee(int value) {
        health -= value;

        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
