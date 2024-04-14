using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer projectileGfx;
    float lifetime = 5;
    public NeedName needName;

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime < 0 )Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out IDamageable d))
        {
            d.Damage(10, needName.ToString());
        }
        //Nieco uproœci³em
        //IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        //if (damageable != null) {
        //    damageable.Damage(10, needName.ToString());
        //}

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
    public void SetProjectile(int type)
    {
        needName = (NeedName)type;
        projectileGfx.sprite = sprites[type];
    }
}
