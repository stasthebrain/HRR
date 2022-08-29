using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBA : MonoBehaviour
{
    public Color myColor;
    void OnGUI()
    {
        myColor = RGBASlider(new Rect(10, 120, 200, 20), myColor);
    }
    Color RGBASlider(Rect screenRect, Color rgba)
    {
        rgba.r = LabelSlider(screenRect, rgba.r, 1.0f, "Red");
        screenRect.y += 20;
        rgba.g = LabelSlider(screenRect, rgba.g, 1.0f, "Green");
        screenRect.y += 20;
        rgba.b = LabelSlider(screenRect, rgba.b, 1.0f, "Blue");
        screenRect.y += 20;
        rgba.a = LabelSlider(screenRect, rgba.a, 1.0f, "Alpha");
        return rgba;
    }
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText)
    {
        GUI.Label(screenRect, labelText);
        screenRect.x += screenRect.width;
        sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, 0.0f, sliderMaxValue);
        return sliderValue;
    }
}