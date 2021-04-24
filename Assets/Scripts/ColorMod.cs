using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorMod : MonoBehaviour
{
    public enum Type
    {
        Object,
        Text,
        Image
    }

    public Type componentType;
    public Color[] colors;
    public float transitionSpd = 5; 

    private Text text;
    private Image image;
    private GameObject obj;
    [SerializeField] private int index;

    void Start()
    {
        if(componentType == Type.Text)
        {
            text = GetComponent<Text>();
            //text.color = colors[0];
        }
        if(componentType == Type.Image)
        {
            image = GetComponent<Image>();
            //image.color = colors[0];
        }
        if(componentType == Type.Object)
        {

        }
        index = 0;
    }

    
    void ModulateText()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            if (text.color != colors[index])
            {
                text.color = Color.Lerp(text.color, colors[index], transitionSpd * Time.deltaTime);
            }
            else
            {
                if (index == colors.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
        }
    }

    void ModulateImage()
    {
        for(int i = 0; i < colors.Length; i++)
        {
            if(image.color != colors[index])
            {
                image.color = Color.Lerp(image.color, colors[index], transitionSpd * Time.deltaTime);
            }
            else
            {
                if(index == colors.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
        }
    }

    void Update()
    {
        if(componentType == Type.Text)
        {
            ModulateText();
        }
        if(componentType == Type.Image)
        {
            ModulateImage();
        }
    }
}
