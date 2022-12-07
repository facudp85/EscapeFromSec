using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    private CharacterController controller;
    private GameObject Camara;
    public float velocidad;
    public float velocidadRotacion;
    float xRotation;
    public GameObject bonus; //bonus
    public Transform posbonus; //Referencia de donde sale el bonus
    bool pasoTiempo = false; //Bool que determina si paso el tiempo de 2 segundos
    float tiempoRestanteBonus; //variable del tiempo restante en el temporizador de la pared.
    float tiempoEnTotal = 1f; //Variable que setea el tiempo total del temporizador del portal

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        Camara = GameObject.FindGameObjectWithTag("MainCamera");
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Q)) //Input Rota Izquierda
        {
            transform.Rotate(0, -1f, 0);
        }

        if (Input.GetKey(KeyCode.E)) //Input Rota Derecha
        {
            transform.Rotate(0, 1f, 0);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        controller.Move(transform.forward * z * velocidad * Time.deltaTime);
        controller.Move(transform.right * x * velocidad * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * velocidadRotacion * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * velocidadRotacion * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -55f, 55f);

        Camara.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * mouseX);

        temporizadorBonus();

        if (pasoTiempo == true) //Si pasa el tiempo de 2 segundos se mueve bonus
        {
            ShowBonus();
            pasoTiempo = false;
            /*bonus.transform.position = new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15));*/

        }

    }

    void temporizadorBonus() //Temporizador Bonus
    {

        tiempoRestanteBonus += Time.deltaTime;

        if (tiempoRestanteBonus >= 15)
        {
            ResetearTempoBonus();

            pasoTiempo = true;
            velocidad = 44f;


        }
    }

    private void OnTriggerStay(Collider col) //Cuando colisiona con el Bonus
    {

        if (col.transform.gameObject.tag == "Chori")
        {
            velocidad = 100f;
        }

    }


    void ResetearTempoBonus() //Resetea Temp
    {
        tiempoRestanteBonus = tiempoEnTotal;
        
    }

    void ShowBonus() //Metodo que instancia bonus
    {
        Instantiate(bonus, posbonus.position, posbonus.rotation);

    }
}
