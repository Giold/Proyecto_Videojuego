using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class GameOverMenu : MonoBehaviour
{
     [SerializeField] private GameObject menuGameOver;
     private CharacterMovement characterMovement;
    // Start is called before the first frame update

    private void Start(){
      characterMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
      characterMovement.PersonajeMuerte += ActivarMenu;
    }

    private void ActivarMenu(object sender, EventArgs e){
     menuGameOver.SetActive(true);
    }
   public void Reiniciar()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   public void MenuInicial(string nombre)
   {
        SceneManager.LoadScene(nombre);
   }

   public void salir()
   {

     Application.Quit();
   }

}
