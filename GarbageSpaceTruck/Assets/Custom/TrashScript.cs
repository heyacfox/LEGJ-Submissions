using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    public Canvas topCanvas;
    public GameObject iconPrefab;
    public GameObject linkedInstantiatedIcon;
    public Camera mainCamera;

    public void Start()
    {
        topCanvas = FindObjectOfType<Canvas>();
        mainCamera = Camera.main;
        linkedInstantiatedIcon = Instantiate(iconPrefab, topCanvas.transform);
        
    }

    private void Update()
    {
        //okay, we need to CLAMP the icon to the screen somhow. 
        linkedInstantiatedIcon.transform.position = mainCamera.WorldToScreenPoint(transform.position);

    }

    private void OnDestroy()
    {
        Destroy(linkedInstantiatedIcon);
    }
}
