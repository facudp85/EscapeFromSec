using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovsEnemigos : MonoBehaviour
{

    public enum EstiloAtaque
    {
        Perseguir,
        Mirar
    };

    public EstiloAtaque tipoDeAtaque;
    public GameObject pj; //Game Obj jugador.
    float distMax = 2; //variable de distancia 2 pasos segun desafio.
    float speed = 1f; //variable velocidad utilizada para metodo de frenar a cierta distancia
    public AudioSource sonidoOle; //Audio de Ole
    public AudioSource sonidoCatch; //Audio cuando el seguridad te agarra
    void Start()
    {

    }

    void Update()
    {

        switch (tipoDeAtaque)
        {
            case EstiloAtaque.Perseguir:
                lookJugador(); //Llama metodo mirar jugador
                followJugadorOne(); //Llama metodo para perseguir jugador
                stopAtDistancia(); //llama metodo para que frene a cierta distancia.
                break;

            case EstiloAtaque.Mirar:
                lookJugador2(); //llama al metodo lookJugador
                break;
        }



    }

    void lookJugador2() //Metodo que mira al jugador 2
    {
        float distJug2 = Vector3.Distance(transform.position, pj.transform.position);
        transform.LookAt(pj.transform.position);
        if (distJug2 < distMax)
        {
            PlaySonidoOle();

        }


    }
    void lookJugador() //Metodo que mira al jugador
    {
        transform.LookAt(pj.transform.position);
    }

    void followJugadorOne() //Metodo que persigue al jugador LERP
    {
        transform.position = Vector3.Lerp(transform.position, pj.transform.position, speed * Time.deltaTime);

    }

    void stopAtDistancia() //Metodo que frena a cierta distancia.
    {
        float distJug = Vector3.Distance(transform.position, pj.transform.position);

        if (distJug > distMax)
        {
            speed = 1f;

        }
        else
        {
            speed = 0f;
            PlaySonidoCatch();
        }



    }

    void PlaySonidoOle() //Metodo que hace play de sonido Catch
    {
        sonidoOle.Play();
    }

    void PlaySonidoCatch() //Metodo que hace play de sonido Catch
    {
        sonidoCatch.Play();
    }
}
