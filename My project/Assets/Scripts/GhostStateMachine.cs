using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostStateMachine : MonoBehaviour
{
    public GhostsMoviment move;

    public bool Isbeingcontrolled;

    
    // Start is called before the first frame update
    void Start()
    {
        Isbeingcontrolled = false;
        move = GetComponent<GhostsMoviment>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Isbeingcontrolled)
        {
            move.enabled = true;
        }
        else
        {
            move.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Isbeingcontrolled = true;
        }
        
    }
}
