using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomTeleportProvider : TeleportationProvider
{
    public TeleportationProvider teleportProvider; // El proveedor de teletransportaci�n
    public XRBaseInteractor rightController; // Referencia al controlador derecho

    private void OnEnable()
    {
        if (teleportProvider != null && rightController != null)
        {
            rightController.enabled = false; // Desactiva el controlador derecho para teletransportaci�n
        }
    }

    private void OnDisable()
    {
        if (teleportProvider != null && rightController != null)
        {
            rightController.enabled = true; // Reactiva el controlador derecho si se desactiva el script
        }
    }
}
