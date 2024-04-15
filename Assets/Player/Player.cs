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
    private bool canAttack = true;
    [SerializeField] private float speed=1;
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private SpriteRenderer playerSprite;
    private AudioSource ass;
    [SerializeField] private AudioClip[] meows;
    [SerializeField] private float shootDelay = 0.3f;
    float lastShot = 0;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        ass = GetComponent<AudioSource>();
    }


    private void Update()
    {
        Vector3 movementVector = transform.forward * playerInput.x + transform.right * -playerInput.y;
        characterController.Move(movementVector * speed * Time.deltaTime);
        playerSprite.gameObject.transform.localPosition = new Vector3(0, 1+Mathf.Cos(Time.time)*0.1f, 0);

        // Fix player moving higher after collision with other objects
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    public float GetPlayerSpeed() {
        return speed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        playerInput = context.ReadValue<Vector2>();

        if(playerInput.magnitude > 0 && canAttack)
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
        if (!canAttack) return;
        if (Time.time < lastShot + shootDelay) return;

        Rigidbody newProjectile = Instantiate(projectile, transform.position+Vector3.up, Quaternion.identity, null);
        Vector3 force = (new Vector3(-shootingVector.y, 0, shootingVector.x)) * 1000;
        newProjectile.AddForce(force);

        //newProjectile.GetComponent<Projectile>().needName = needName;
        if(newProjectile.TryGetComponent(out Projectile p))
        {
            p.SetProjectile((int)needName);
        }
        if(ass != null)
        {
            ass.PlayOneShot(meows[Random.Range(0,meows.Length)]);
        }
        lastShot = Time.time;
    }

    public void ChangePlayerSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public void TogglePlayerActions(bool newState)
    {
        canAttack = newState;
    }
}
