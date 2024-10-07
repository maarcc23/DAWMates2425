using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numero : MonoBehaviour
{
    private float _vel;

    private Vector2 minPantalla;

    [SerializeField] private Sprite[] arraySpritesNumeros = new Sprite[10];

    private int valorNumero; 

    [SerializeField] private GameObject prefabExplosio;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 3f;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        System.Random numAleatori = new System.Random();
        valorNumero = numAleatori.Next(0, 10);
        GetComponent<SpriteRenderer>().sprite = arraySpritesNumeros[valorNumero];    
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posActual = transform.position;
        posActual = posActual + new Vector2(0, -1) * _vel * Time.deltaTime;
        transform.position = posActual;

        if(transform.position.y < minPantalla.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if(objecteTocat.tag == "Jugador" || objecteTocat.tag == "ProjectilJugador")
        {
            GameObject Explosio = Instantiate(prefabExplosio);
            Explosio.transform.position = transform.position;

            Destroy(gameObject);
        }
    }
}
