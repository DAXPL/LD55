using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject deathEffect;
    float lifetime = 5;
    public NeedName needName;

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime < 0 )Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null) {
            damageable.Damage(10, needName.ToString());
        }

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (deathEffect != null) 
        {
            GameObject g = Instantiate(deathEffect, transform.position, Quaternion.identity, null);
            Destroy(g,5);
        } 
    }
}
