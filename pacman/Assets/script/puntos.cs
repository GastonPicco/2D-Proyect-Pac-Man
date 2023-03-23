using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puntos : MonoBehaviour
{

    // Start is called before the first frame update
    public int valorpuntos;
    public bool Especial;
    public bool caneat;
    
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D col)
    {  
        if (col.tag == ("Player"))
        {
            gameObject.transform.position = new Vector3(transform.position.x,transform.position.y-35,transform.position.z);
            GameController.instance.SumarPuntos(valorpuntos);
        }
        if (col.tag == ("Player") && Especial)
        {
            caneat = true;
            GameController.instance.CanEat();
        }    
    }


}
