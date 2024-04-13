using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityName {
    scratch,
    kick,
    bite,
    pee
}

public enum NeedName {
    sleep,
    food,
    attention,
    litter
}

[CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObjects/CreateNewEnemy")]
public class Enemy : ScriptableObject {
    public AbilityName abilityName;
    public NeedName needName;
    public float movementSpeed;
    public float needLevel;
}
