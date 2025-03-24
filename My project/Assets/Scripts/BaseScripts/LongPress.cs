using UnityEngine;

public class LongPress : MonoBehaviour
{
    private float touchStartTime = 0f;
    private bool isLongTap = false;
    public float longTapDuration = 5f; // Tempo para considerar um long tap (5s)

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartTime = Time.time; // Marca o tempo inicial do toque
                isLongTap = true;
            }
            else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // Se o toque durar mais do que longTapDuration, aciona o evento
                if (isLongTap && (Time.time - touchStartTime >= longTapDuration))
                {
                    Debug.Log("Long Tap detectado! Posição: " + touch.position);
                    isLongTap = false; // Evita que seja chamado várias vezes
                }
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                // Resetamos o temporizador se o toque for interrompido antes dos 5s
                isLongTap = false;
            }
        }
    }
}
