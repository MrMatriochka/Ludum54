using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSayManager : MonoBehaviour
{
    public SpriteRenderer[] colors;

    private int colorSelect;

    public float stayLit;
    private float stayLitTimer;

    public float waitBetweenLight;
    private float waitBetweenLightTimer;

    private bool beLit;
    private bool beDark;

    public List<int> activeSequence;
    private int positionInSequence;

    private bool gameActive;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (beLit)
        {
            stayLitTimer -= Time.deltaTime;

            if (stayLitTimer < 0)
            {
                colors[activeSequence[positionInSequence]].color = new Color(colors[activeSequence[positionInSequence]].color.r,
                    colors[activeSequence[positionInSequence]].color.g, colors[activeSequence[positionInSequence]].color.b, 0.5f);
                beLit = false;
                beDark = true;
                waitBetweenLightTimer = waitBetweenLight;
                positionInSequence++;
            }
        }

        if (beDark)
        {
            waitBetweenLightTimer -= Time.deltaTime;

            if (positionInSequence >= activeSequence.Count)
            {
                beDark = false;
                gameActive = true;
            }
            else
            {
                if (waitBetweenLightTimer < 0)
                {
                    colors[activeSequence[positionInSequence]].color = new Color(colors[activeSequence[positionInSequence]].color.r,
                        colors[activeSequence[positionInSequence]].color.g, colors[activeSequence[positionInSequence]].color.b, 1f);

                    stayLitTimer = stayLit;
                    beLit = true;
                    beDark = false;
                }
            }
        }
    }

    public void StartGame()
    {
        positionInSequence = 0;
        
        colorSelect = Random.Range(0, colors.Length);
        
        activeSequence.Add(colorSelect);

        colors[activeSequence[positionInSequence]].color = new Color(colors[activeSequence[positionInSequence]].color.r,
            colors[activeSequence[positionInSequence]].color.g, colors[activeSequence[positionInSequence]].color.b, 1f);

        stayLitTimer = stayLit;
        beLit = true;
        
    }

    public void ColorPressed(int whichButton)
    {
        if(gameActive)
        {
            if(colorSelect == whichButton)
            {
                Debug.Log("correct");
            }
            else
            {
                Debug.Log("Wrong");
            }
        }
    }
}
