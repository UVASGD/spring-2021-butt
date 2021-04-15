using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRatingIndicator : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    public void ShowActionRating(ActionRating ar)
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[(int)ar];
    }
}
