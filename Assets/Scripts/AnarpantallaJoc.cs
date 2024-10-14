using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnarpantallaJoc : MonoBehaviour
{
   
    public void AnarpantallaJugant()
    {
        DadesGlobals.ReiniciarPunts();
        SceneManager.LoadScene("pantallajugant");
    }
}
