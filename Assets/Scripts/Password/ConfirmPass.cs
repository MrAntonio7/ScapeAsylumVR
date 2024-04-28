using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPass : MonoBehaviour
{
    public Text num1;
    public Text num2;
    public Text num3;
    public Text num4;
    public Text num5;

    public GameObject puertaCerrada;
    public GameObject puertaAbierta;
    public GameObject AreaExit;

    public AudioSource audioCorrecto;
    public AudioSource audioError;
    [SerializeField] private string pass;

    // Start is called before the first frame update
    void Start()
    {
        pass = "97348";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConfirmPassword()
    {
        if (num1.text+num2.text+num3.text+num4.text+num5.text == pass)
        {
            Debug.Log("Contraseña correcta");
            audioCorrecto.Play();
            puertaAbierta.SetActive(true);
            AreaExit.SetActive(true);
            puertaCerrada.SetActive(false);
        }
        else
        {
            audioError.Play();
            Debug.Log("Contraseña incorrecta");
            puertaAbierta.SetActive(false);
            AreaExit.SetActive(false);
            puertaCerrada.SetActive(true);
        }
    }
}
