using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJugador : MonoBehaviour
{
    private float _vel;

    private Vector2 minpantalla, maxpantalla;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8f;
        minpantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxpantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: " + direccioIndicadaX + " - Y: " + direccioIndicadaY);
        Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;

        Vector2 novaPos = transform.position; //tranform.position: pos actual nau
        novaPos = novaPos + direccioIndicada * _vel * Time.deltaTime;
        //Debug.Log(Time.deltaTime);

        novaPos.x = Mathf.Clamp(novaPos.x, minpantalla.x, maxpantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minpantalla.y, maxpantalla.y);

        transform.position = novaPos;
    }
}
