using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterMovement : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Speed;
    public float JumpForce;
    // Start is called before the first frame update
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot;
    public int Health = 5;
    public event EventHandler PersonajeMuerte;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       Horizontal = Input.GetAxisRaw("Horizontal");

       if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
       else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

       Animator.SetBool("Walking", Horizontal != 0.0f);
        

       Debug.DrawRay(transform.position, Vector3.down * 0.5f, Color.red);
       if (Physics2D.Raycast(transform.position, Vector3.down, 0.5f))
       {
         Grounded = true;
         
       }
       else {
        Grounded = false;
        
       }

       if (Input.GetKeyDown(KeyCode.W) && Grounded)
       {
            Jump();
            
       } else {
        Animator.SetBool("Jumping",Grounded);
       }
       if(Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
       {
            Shoot();
            
            LastShoot = Time.time;
            
            
       }
       else{
        Animator.SetBool("Shooting", Time.time < LastShoot + 0.2f);
       }
    
       
    }

    private void Jump()
    {
       Rigidbody2D.AddForce(Vector2.up * JumpForce); 
       
        
    }
//Accion que hace que dispare
    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;

        
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.8f, Quaternion.identity);
        bullet.GetComponent<Bullet_script>().SetDirection(direction);
    }
// Marca la velodidad del jugador
    private void FixedUpdate() 
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
        
    }
// Detecta la colision de las balas con el personaje
    public void Hit() 
    {
        Health = Health - 1;
        if (Health <= 0)
        {
            PersonajeMuerte?.Invoke(this,EventArgs.Empty);
            Destroy(gameObject);
        } 
    }
// Detecta la colision de las trampas con el personaje
    public void HitObject(){
        Health = Health - 5;
        if (Health <= 0)
        {
            PersonajeMuerte?.Invoke(this,EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}
