using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarJuego : MonoBehaviour {
    private bool cerrar;

    private void Update()
    {
        if (cerrar)
        {
            Application.Quit();
        }
    }
    public void cerrarJuego(bool x)
    {
        cerrar = x;
    }
}
