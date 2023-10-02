using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoufID : MonoBehaviour
{
    public enum Outfit
    {
        Orange,
        Rouge,
        Vert,
        Bleue,
        Jaune
    }

    public Outfit colour;
    
    public enum Disability
    {
        Default,
        Sourd,
        Daltonien,
        Alcoolique
    }

    public Disability disability;

    public Material orange;
    public Material rouge;
    public Material vert;
    public Material bleue;
    public Material jaune;

    Renderer renderer;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    public void UpdateColor()
    {
        renderer = transform.GetChild(0).GetComponent<Renderer>();
        switch (colour)
        {
            case Outfit.Orange:
                SwapMaterial(orange);
                break;
            case Outfit.Rouge:
                SwapMaterial(rouge);
                break;
            case Outfit.Vert:
                SwapMaterial(vert);
                break;
            case Outfit.Bleue:
                SwapMaterial(bleue);
                break;
            case Outfit.Jaune:
                SwapMaterial(jaune);
                break;
            default:
                SwapMaterial(null);
                break;
        }
    }

    void SwapMaterial(Material newMat)
    {
        Material[] mats = renderer.materials;
        mats[1] = newMat;
        renderer.materials = mats;
        transform.GetChild(1).GetComponent<Renderer>().material=newMat;
    }
}
