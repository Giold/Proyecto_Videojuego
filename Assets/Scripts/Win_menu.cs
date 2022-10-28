using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Win_menu : MonoBehaviour
{
    //carga escena mediante el numero de la escena
     public void CargarEscena(int index){
    SceneManager.LoadScene(index);
   }
//carga escena mediante nombre de la escena
   public void CargarEscena(string nombre){
    SceneManager.LoadScene(nombre);
   }
//Cierra juego
   public void Exit()
   {
    Application.Quit();
   }
}
