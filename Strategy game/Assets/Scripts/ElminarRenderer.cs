﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ElminarRenderer : NetworkBehaviour
{

    private Component[] renderer;
    public List<GameObject> Children;
    [SerializeField]
    Canvas interfaz_movil;
    void Awake()
    {

#if UNITY_ANDROID
          foreach (Transform child in transform)
           {
              Children.Add(child.gameObject);
           }
       
          EliminarRenderer(Children);
#endif

#if UNITY_STANDALONE_WIN 
        interfaz_movil.enabled = false;
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
