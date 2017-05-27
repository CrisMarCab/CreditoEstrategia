using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ElminarRenderer : NetworkBehaviour
{

    private Component[] renderer;
    public List<GameObject> Children;
    [SerializeField]
    Canvas interfazmovil;
    void Awake()
    {

#if UNITY_ANDROID
          foreach (Transform child in transform)
           {
              Children.Add(child.gameObject);
           }
       
          EliminarRenderer(Children);
          Instantiate(interfazmovil);
#endif

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void EliminarRenderer(List<GameObject> Children)
    {

        foreach (GameObject hijo in Children)
        {
            if (hijo.GetComponent<MeshRenderer>() == null)
            {
                renderer = hijo.GetComponentsInChildren<MeshRenderer>();


                foreach (MeshRenderer comp in renderer)
                {
                    comp.enabled = !comp.enabled;
                }

            }

            else
            {
                hijo.GetComponent<MeshRenderer>().enabled = !hijo.GetComponent<MeshRenderer>().enabled;
            }
        }

    }
}
