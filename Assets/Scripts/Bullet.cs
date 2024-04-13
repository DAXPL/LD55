using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        ISatisfactionable satisfactionable = collision.gameObject.GetComponent<ISatisfactionable>();

        if (satisfactionable != null) {
            satisfactionable.DecreaseLevel(10);
        }
    }
}
