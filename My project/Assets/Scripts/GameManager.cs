using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public enum ModosdeJogo
{
    ControlandoCamera,
    ControlandoItens
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private ModosdeJogo modo;

    [SerializeField] private MoveCamera Camera;

    [SerializeField] private PinchZoom2D zoom;

    public UnityEvent Desassociarbixinhos;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MudarMododeJogo(ModosdeJogo novomodo)
    {

        switch (novomodo){
            case ModosdeJogo.ControlandoCamera:
                Desassociarbixinhos.Invoke();
                Camera.enabled= true;
                zoom.enabled = true;
                break;

            case ModosdeJogo.ControlandoItens:
                Camera.enabled = false;
                zoom.enabled = false;
                break;
        }
        
            
    }

}
