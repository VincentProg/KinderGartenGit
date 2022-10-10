using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{

    public void LaunchScene(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
