using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsAutoJump : MonoBehaviour {
    private IEnumerator JumpCourintine;
    private Rigidbody rb;
    public Vector3 force;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Start() {
        
    }

    private void OnEnable() {
        JumpCourintine = Jump();
        StartCoroutine(JumpCourintine);
    }    
    
    private void OnDisable() {
        StopCoroutine(JumpCourintine);
    }

    

    IEnumerator Jump () {
        while (true) {
            //Vector3 force = new Vector3(0, 0.07f, 0);
            rb.AddForceAtPosition(force, transform.up, ForceMode.Force);
            //rb.AddForce(0, 20, 0);
            yield return new WaitForSeconds(3);
        }
    }
}
