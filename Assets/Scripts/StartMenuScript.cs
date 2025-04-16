using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    public void OnStart() {
        SceneManager.LoadScene("Game");
    }
}
