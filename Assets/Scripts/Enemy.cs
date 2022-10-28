using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 public GameObject BulletPrefab;
 private Animator Animator;
 public GameObject Character;
 private float LastShoot;
 private int Health = 3;
 
 private void Start(){
    Animator = GetComponent<Animator>();
   

 }
 private void Update()
 {
    if(Character == null) return;
    
   //Comportamiento del enemigo

    Vector3 direction = Character.transform.position - transform.position;
    if(direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    else transform.localScale = new Vector3(-1.0f,1.0f,1.0f);

    float distance = Mathf.Abs(Character.transform.position.x - transform.position.x);

    if(distance < 3.0f && Time.time > LastShoot + 0.25f)
    {
        Shoot();
        LastShoot  =Time.time;
    }
    else{
        Animator.SetBool("Shooting", Time.time < LastShoot + 0.2f);
    }


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

 //Funcion que detecta la colision de las balas con el enemigo
  public void Hit() 
    {
        Health = Health - 1;
        if (Health == 0)
        {
            GameObject.FindGameObjectWithTag("Meta").GetComponent<Meta>().EnemigosEliminado();
            Destroy(gameObject);

        } 
    }


}
