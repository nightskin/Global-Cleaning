using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slides : MonoBehaviour
{
    public int slideIndex;
    public GameObject[] slides;
    void Start()
    {
        slideIndex = 0;
    }

    public void PrevSlide()
    {
        if (slideIndex > 0)
        {
            slides[slideIndex].SetActive(false);
            slideIndex--;
            slides[slideIndex].SetActive(true);
        }
    }

    public void NextSlide()
    {
        if (slideIndex < slides.Length - 1)
        {
            slides[slideIndex].SetActive(false);
            slideIndex++;
            slides[slideIndex].SetActive(true);
        }
    }
}
