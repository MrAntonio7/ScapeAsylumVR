using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AutoCollectGrabInteractables : MonoBehaviour
{
    public GlobalGrabListener grabListener; // El listener global que gestiona las colisiones

    private void Start()
    {
        // Encuentra todos los XRGrabInteractable en la escena y añádelos a la lista del GlobalGrabListener
        var grabInteractables = FindObjectsOfType<XRGrabInteractable>();
        if (grabListener != null)
        {
            grabListener.grabInteractables = new List<XRGrabInteractable>(grabInteractables);
        }
    }
}
