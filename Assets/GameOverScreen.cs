using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    
    public void Setup()
    {
        gameObject.SetActive(true);
        print("itsworking");
    }


    public void ReStart()
    {
        ///here is your problem girl
        ///the button always change you to the first scence
        ///you know??? 
        ///
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);



    }

    public void Menu()
    {
        ///here is your problem girl
        ///the button always change you to the first scence
        ///you know??? 
        ///
        SceneManager.LoadScene("MainMenu");



    }
}
