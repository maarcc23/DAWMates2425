using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJugador : MonoBehaviour
{
    private float _vel;

    private Vector2 minpantalla, maxpantalla;

    [SerializeField]private GameObject prefabProjectil;
    [SerializeField]private GameObject prefabExplosio;
    // Start is called before the first frame update
    void Start()
    {
        _vel = 8f;
        minpantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxpantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float meitatMidaImatgeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float meitatMidaImatgeY = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y / 2;

        minpantalla.x = minpantalla.x + meitatMidaImatgeX;
        maxpantalla.x = maxpantalla.x - meitatMidaImatgeX;
        minpantalla.y += meitatMidaImatgeY;
        maxpantalla.y -= meitatMidaImatgeY;

    }

    // Update is called once per frame
    void Update()
    {
        MoureNau();
        DispararProjectil();
    }

    private void DispararProjectil()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject projectil = Instantiate(prefabProjectil);
            projectil.transform.position = transform.position;
        }
    }

    private void MoureNau()
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

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if(objecteTocat.tag == "Numero")
        {
            GameObject Explosio = Instantiate(prefabExplosio);
            Explosio.transform.position = transform.position;
            
            Destroy(gameObject);
        }
    }
}
