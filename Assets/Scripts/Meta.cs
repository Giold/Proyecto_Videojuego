using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour
{
 [SerializeField] private int cantidadEnemigos;
 [SerializeField] private int enemigosEliminados;
 private Animator animator;

//Detecta el animator de la meta y cuenta la cantidad de enemigos
 private void Start(){
    animator = GetComponent<Animator>();
    cantidadEnemigos = GameObject.FindGameObjectsWithTag("Enemigos").Length;
 }

//Activa el animator de la meta
 private void ActivarMeta(){
    animator.SetTrigger("Activar");
 }

//cuenta los enemigos eliminados
 public void EnemigosEliminado () {
    enemigosEliminados += 1;

    if(enemigosEliminados == cantidadEnemigos){
        ActivarMeta();
    }
 }

//Detecta la colision de la meta con el jugador
 private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Player") && enemigosEliminados == cantidadEnemigos){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }   
 }


}
