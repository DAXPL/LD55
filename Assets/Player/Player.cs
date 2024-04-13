using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    private Vector2 playerInput;
    private Vector2 shootingVector;
    [SerializeField] private float speed=1;
    [SerializeField] private Rigidbody[] projectiles;
    [SerializeField] private SpriteRenderer playerSprite;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 movementVector = transform.forward * playerInput.x + transform.right * -playerInput.y;
        characterController.Move(movementVector * speed * Time.deltaTime);
        playerSprite.gameObject.transform.localPosition = new Vector3(0,1+Mathf.Cos(Time.time)*0.1f,0);
    }

    public void Move(InputAction.CallbackContext context)
    {
        playerInput = context.ReadValue<Vector2>();

        if(playerInput.magnitude > 0 )
        {
            shootingVector = playerInput;
            playerSprite.flipX = playerInput.x < 0;
        }
        
    }

    // play
    public void UseSkill1(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            ShootProjectile(0, NeedName.play);
        }
    }

    // food
    public void UseSkill2(InputAction.CallbackContext context)
    {
        if (context.started) {
            ShootProjectile(0, NeedName.food);
        }
    }

    // attention
    public void UseSkill3(InputAction.CallbackContext context)
    {
        if (context.started) {
            ShootProjectile(0, NeedName.attention);
        }
    }

    // litter
    public void UseSkill4(InputAction.CallbackContext context)
    {
        if (context.started) {
            ShootProjectile(0, NeedName.litter);
        }
    }

    private void ShootProjectile(int id, NeedName needName)
    {
        Rigidbody newProjectile = Instantiate(projectiles[id], transform.position+Vector3.up, Quaternion.identity, null);
        Vector3 force = (new Vector3(-shootingVector.y, 0, shootingVector.x)) * 1000;
        newProjectile.AddForce(force);
        newProjectile.GetComponent<Projectile>().needName = needName;
    }
}
