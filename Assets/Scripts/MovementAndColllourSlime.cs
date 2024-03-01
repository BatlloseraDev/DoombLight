using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAndColllourSlime : MonoBehaviour
{

    public float velocidad = 1f;
    public float tiempoTranscurrido=0f; 
    public float duracionCiclo= 5f; 
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        Movimiento();
        Eliminacion();

        float t= Mathf.PingPong(tiempoTranscurrido/ duracionCiclo, 1f);
        Color color = Color.HSVToRGB(t,1f,1f);
        rend.material.color = color;
    }

    private void Eliminacion()
    {
        if (transform.position.x > 200f || tiempoTranscurrido > 20f)
        {
            Destroy(gameObject);
        }
    }

    private void Movimiento()
    {
        transform.Translate(new Vector2(1, -1) * velocidad * Time.deltaTime);
    }
}
