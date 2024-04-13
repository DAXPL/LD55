using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private Vector2 playerInput;
    [SerializeField] private Vector2 shootingVector;
    [SerializeField] private float speed=1;
    [SerializeField] private Rigidbody[] projectiles;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Vector3 movementVector = transform.forward * playerInput.x + transform.right * -playerInput.y;
        characterController.Move(movementVector * speed * Time.deltaTime);
    }
    public void Move(InputAction.CallbackContext context)
    {
        playerInput = context.ReadValue<Vector2>();

        if(playerInput.magnitude > 0 )
        {
            shootingVector = playerInput;
        }
        
    }
    public void UseSkill1(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            ShootProjectile(0);
        }
    }
    public void UseSkill2(InputAction.CallbackContext context)
    {
        if (context.started) Debug.Log("2");
    }
    public void UseSkill3(InputAction.CallbackContext context)
    {
        if (context.started) Debug.Log("3");
    }
    public void UseSkill4(InputAction.CallbackContext context)
    {
        if (context.started) Debug.Log("4");
    }
    private void ShootProjectile(int id)
    {
        Rigidbody newProjectile = Instantiate(projectiles[id], transform.position, Quaternion.identity, null);
        Vector3 force = (new Vector3(-shootingVector.y, 0, shootingVector.x)) * 1000;
        newProjectile.AddForce(force);
    }
}
