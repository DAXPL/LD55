using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class GameManager : MonoBehaviour {
    public int points;
    public static GameManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Debug.LogError("There is more than 1 GameManager on the scene");
        }
    }

    public void CatSatisfied() {
        points++;
      
    }
}
