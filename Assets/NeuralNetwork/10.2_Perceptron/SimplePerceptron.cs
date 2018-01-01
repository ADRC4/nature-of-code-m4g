using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePerceptron : MonoBehaviour
{
    private GUISkin _skin;
    private Rect _rectangle;
    private int _width;
    private int _height;
    private int _size;
    private Texture2D _image;
    private Color[] _colors;

    Point[] points = new Point[100];
    Perceptron p;

	void Start ()
    {
        //GUI Layout
        int scale = 4;
        _width = Screen.width / scale;
        _height = Screen.height / scale;
        _size = _width * _height;
        _image = new Texture2D(_width, _height);
        _rectangle = new Rect(0, 0, Screen.width, Screen.height);
        _colors = new Color[_size];

        //Perceptron Logic
        p = new Perceptron();

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = new Point();
        }


        float[] inputs = { 1, 0.5f };
        int guess = p.guess(inputs);
        print(guess);

	}

    void Draw()
    {
        foreach (Point p in points)
        {
            p.Show();

            _image.SetPixels(_colors);
            _image.Apply();
        }
    }


    private void OnGUI()
    {
        GUI.skin = _skin;
        GUI.DrawTexture(_rectangle, _image);       
    }
}
