using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    bool isGauntlet;

    // Start is called before the first frame update
    void Start()
    {
        isGauntlet = ButtonScript.isGauntlet;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}