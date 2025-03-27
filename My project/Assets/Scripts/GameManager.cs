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
    public static GameManager Instance;

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private UIManager ui;


    [SerializeField] private ModosdeJogo modo;

    [SerializeField] private MoveCamera cameramove;

    [SerializeField] private PinchZoom2D zoom;

    [SerializeField] private CirculodeInfluenciadoPlayer circulo;

    public UnityEvent Desassociarbixinhos;


    void Start()
    {
        circulo = GetComponent<CirculodeInfluenciadoPlayer>();
        ui = FindAnyObjectByType<UIManager>();
        cameramove = FindAnyObjectByType<MoveCamera>();
        zoom = FindAnyObjectByType<PinchZoom2D>();

        ModoCamera();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ModoCamera()
    {
        MudarMododeJogo(ModosdeJogo.ControlandoCamera);
    }


    public void MudarMododeJogo(ModosdeJogo novomodo)
    {

        switch (novomodo){
            case ModosdeJogo.ControlandoCamera:
                Desassociarbixinhos.Invoke();
                cameramove.enabled= true;
                zoom.enabled = true;
                circulo.enabled = true;
                break;

            case ModosdeJogo.ControlandoItens:
                cameramove.enabled = false;
                zoom.enabled = false;
                circulo.enabled = false;
                break;
        }
        modo = novomodo;
            
    }

}
