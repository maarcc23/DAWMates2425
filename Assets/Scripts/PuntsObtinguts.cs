using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuntsObtinguts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Punts Obtinguts: " + DadesGlobals.punts;
        Invoke("anarpantallainici", 5f);
    }

    
    private void anarpantallainici()
    {
        SceneManager.LoadScene("pantallainici");
    }
}
