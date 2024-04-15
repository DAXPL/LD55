using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgBreather : MonoBehaviour
{
    [SerializeField] private int a = 1;

    void Update()
    {
        transform.position = new Vector3(Mathf.Cos(Time.time)*a, 0,0);
    }
}
