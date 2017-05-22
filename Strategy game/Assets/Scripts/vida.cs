using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour
{
    [SerializeField]
    int vida_total = 100;
    int vidadañovisual = 80;
    TextMesh vidavisual;

    [SerializeField]
    ParticleSystem explosion;

    void awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        //for (int i = 0; i <= gameObject.transform.childCount; i++)
        foreach (Transform child in transform)
        {
            if (child.transform.name == "Vida")
            {
                vidavisual = child.GetComponent<TextMesh>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField]
    public int getVida_total()
    {
        return vida_total;
    }
    public void setVida_total(int daño)
    {
        vida_total -= daño;

        if (vida_total == vidadañovisual)
        {
            vidavisual.text = vidavisual.text.Remove(0, 1);
            vidadañovisual -= 20;
        }


        /*Futura explosión avión.*/
        /*
        if(vida_total <= 0 && this.gameObject == GameObject.Find("war_plane_interceptor"))
        {
            var em = explosion.emission;
            //Instantiate(explosion, this.gameObject.transform, Quaternion.identity) as GameObject;
            em.enabled = true;
            Destroy(this.gameObject);
        }
        */
    }




}
