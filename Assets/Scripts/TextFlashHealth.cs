using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFlashHealth : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject barText;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if(barText.name == "HealthText" && GameStatus.health <= 0.2f)
        {
            anim.Play("FlashRed");
        }
        else if (barText.name == "EnergyText" && GameStatus.energy <= 0.2f)
        {
            anim.Play("FlashRed");
        }
        else if (barText.name == "KnowledgeText" && GameStatus.knowledge <= 0.6f)
        {
            anim.Play("FlashRed");
        }
        else if (barText.name == "FunText" && GameStatus.fun <= 0.2f)
        {
            anim.Play("FlashRed");
        }
        else
        {
            anim.Play("New State");
        }
    }

    
}
