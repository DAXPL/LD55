using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerShoot;

public class PlayerShoot : MonoBehaviour {
    [SerializeField] private GameObject bulletPrefab;


    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    public void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab);
    }

    //public void DecreaseLevel(int damage, string damageType) {
       
    //}
}

public interface ISatisfactionable {
    void DecreaseLevel(int damage);
}