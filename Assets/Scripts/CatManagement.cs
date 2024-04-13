using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Cat;
    public GameObject CatParent;
    // Needed to destroy object
    private GameObject CatClone;
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            // Creating an instance of the prefab after mouse click and setting the parent to CatParent
            CatClone = (Instantiate(Cat, Input.mousePosition, Quaternion.identity));
            CatClone.transform.parent = CatParent.transform;
            // Destroy cat instance after 1 sec
            Destroy(CatClone, 1);
        }
    }
}
