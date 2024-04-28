using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilmController : MonoBehaviour
{
    public Material newMaterial;
    public Material oldMaterial;
    private Renderer objRenderer;
    private CapsuleCollider capsuleCollider;
    public GameObject cinta;
    public GameObject cintaColocada;
    private bool colocada;
    public GameObject numeroPass;
    private MeshRenderer rendererMesh;
    public AudioSource audioFilm;
    public AudioSource audioTape;
    // Start is called before the first frame update
    void Start()
    {
        rendererMesh = GetComponent<MeshRenderer>();
        colocada = false;
        objRenderer = GetComponent<Renderer>();
        capsuleCollider = objRenderer.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CintaVideo"))
        {
            colocada = true;
            objRenderer.material = newMaterial; // Asigna el nuevo material
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CintaVideo"))
        {
            colocada = false;
            objRenderer.material = oldMaterial; // Asigna el viejo material
        }
    }
    public void SetCinta()
    {
        if (colocada) {
            Destroy(cinta);
            cintaColocada.SetActive(true);
            numeroPass.SetActive(true);
            rendererMesh.enabled = false;
            audioFilm.Play();
            audioTape.Play();
        }
        
    }
}
