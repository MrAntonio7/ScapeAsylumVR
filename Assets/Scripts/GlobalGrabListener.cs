using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class GlobalGrabListener : MonoBehaviour
{
    public SnapTurnProviderBase snapTurnProvider; // Componente que controla el giro
    public List<XRGrabInteractable> grabInteractables; // Lista de objetos agarrables

    private int grabCount = 0; // Número de objetos agarrados actualmente

    //private void OnEnable()
    //{
    //    // Suscribirse a los eventos de todos los objetos agarrables
    //    foreach (var grabInteractable in grabInteractables)
    //    {
    //        if (grabInteractable != null)
    //        {
    //            grabInteractable.onSelectEntered.AddListener(OnGrab);
    //            grabInteractable.onSelectExited.AddListener(OnRelease);
    //        }
    //    }
    //}

    //private void OnDisable()
    //{
    //    // Desuscribirse para evitar errores
    //    foreach (var grabInteractable in grabInteractables)
    //    {
    //        if (grabInteractable != null)
    //        {
    //            grabInteractable.onSelectEntered.RemoveListener(OnGrab);
    //            grabInteractable.onSelectExited.RemoveListener(OnRelease);
    //        }
    //    }
    //}

    //private void OnGrab(XRBaseInteractor interactor)
    //{
    //    grabCount++; // Incrementa el contador de objetos agarrados
    //    if (snapTurnProvider != null && grabCount == 1)
    //    {
    //        //Debug.Log("objetos agarrados: " + grabCount + "desactivando");
    //        snapTurnProvider.enabled = false; // Desactiva el giro al agarrar el primer objeto
    //    }
    //}

    //private void OnRelease(XRBaseInteractor interactor)
    //{
    //    grabCount--; // Decrementa el contador de objetos agarrados
    //    if (snapTurnProvider != null && grabCount == 0)
    //    {
    //        //Debug.Log("objetos agarrados: " + grabCount + "activando");
    //        snapTurnProvider.enabled = true; // Reactiva el giro al soltar el último objeto
    //    }
    //}
    public void Desactivar()
    {
        grabCount++; // Incrementa el contador de objetos agarrados
        if (snapTurnProvider != null && grabCount == 1)
        {
            //Debug.Log("objetos agarrados: " + grabCount + "desactivando");
            snapTurnProvider.enabled = false; // Desactiva el giro al agarrar el primer objeto
        }
    }

    public void Activar()
    {
        grabCount--; // Decrementa el contador de objetos agarrados
        if (snapTurnProvider != null && grabCount == 0)
        {
            //Debug.Log("objetos agarrados: " + grabCount + "activando");
            snapTurnProvider.enabled = true; // Reactiva el giro al soltar el último objeto
        }
    }
}