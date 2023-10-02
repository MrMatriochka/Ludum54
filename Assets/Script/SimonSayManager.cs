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
    private int inputInSequence;

    private int score;
    public int scoreNeeded;

    public AudioSource correct;
    public AudioSource wrong;
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

        if (score == scoreNeeded)
        {
            
        }
    }

    public void StartGame()
    {
        activeSequence.Clear();
        
        positionInSequence = 0;
        inputInSequence = 0;
        
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
            if(activeSequence[inputInSequence] == whichButton)
            {
                Debug.Log("correct");
                inputInSequence++;
                correct.Play();

                if (inputInSequence >= activeSequence.Count)
                {
                    positionInSequence = 0;
                    inputInSequence = 0;
                    
                    colorSelect = Random.Range(0, colors.Length);
        
                    activeSequence.Add(colorSelect);

                    colors[activeSequence[positionInSequence]].color = new Color(colors[activeSequence[positionInSequence]].color.r,
                        colors[activeSequence[positionInSequence]].color.g, colors[activeSequence[positionInSequence]].color.b, 1f);

                    stayLitTimer = stayLit;
                    beLit = true;

                    gameActive = false;
                    score++;
                }
            }
            else
            {
                Debug.Log("Wrong");
                gameActive = false;
                wrong.Play();
                score = 0;
            }
        }
    }
}
