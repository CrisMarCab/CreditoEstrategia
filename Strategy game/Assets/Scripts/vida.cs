using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class vida : MonoBehaviour
{
    [SerializeField]
    int vida_total = 100;
    int vidadañovisual = 80;
    bool muerteAvion = false;
    TextMesh vidavisual;

    [SerializeField]
    Transform explosion;
    public AudioClip sonidoExplosion;

    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.transform.name == "Vida")
            {
                vidavisual = child.GetComponent<TextMesh>();
            }
        }
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
        if (vida_total <= 0 && this.gameObject == GameObject.Find("destino"))
        {
            AudioSource.PlayClipAtPoint(sonidoExplosion, transform.position);
            Instantiate(explosion, this.gameObject.transform.position, this.gameObject.transform.rotation);
            gameObject.SetActive(false);
            SceneManager.LoadScene("FinDelJuego");
        }
    }

    private void OnDestroy()
    {
        if (this.gameObject == GameObject.Find("destino"))
        {
            SceneManager.LoadScene("FinDelJuego");
        }
    }
}
