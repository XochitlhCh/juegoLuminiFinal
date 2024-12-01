using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed!");
    }

    public void SartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void Nivel1()
    {

        SceneManager.LoadScene("SampleScene");

       
  
        

    }

    public void Nivel2()
    {

        SceneManager.LoadScene("Nivel2Final");
    }

    public void Nivel3()
    {
        SceneManager.LoadScene("Nivel3");


     

    }

    public void Nivel4()
    {

        SceneManager.LoadScene("Nivel4");

    }
}
