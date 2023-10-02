using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject[] boufs;
    public GameObject[] button;
    public List<BoufID.Outfit> outfits;
    public int hp;
    void Start()
    {
        outfits = Enum.GetValues(typeof(BoufID.Outfit)).Cast<BoufID.Outfit>().ToList();
        outfits = outfits.OrderBy(x => UnityEngine.Random.value).ToList();

        int i = 0;
        foreach (GameObject bouf in boufs)
        {
            bouf.GetComponent<BoufID>().colour = outfits[i];
            bouf.GetComponent<BoufID>().UpdateColor();
            button[i].GetComponent<Renderer>().material = bouf.transform.GetChild(0).GetComponent<Renderer>().materials[1];
            button[i].GetComponent<MoveButton>().bouf = bouf.GetComponent<BaseIA>();
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(hp >= 0)
        {
            print("game over");
        }
    }

    public void TaskFailed()
    {
        hp--;
    }
}
