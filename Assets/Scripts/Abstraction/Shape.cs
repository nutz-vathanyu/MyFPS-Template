
using UnityEngine;
using System;

public abstract class Shape: MonoBehaviour
{
    public abstract void draw();
}

public class Rectangle : Shape
{
    public override void draw()
    {
        Debug.Log("Drawing Rectangle");
    }
}

public class Circle : Shape
{
    public override void draw()
    {
        Debug.Log("Drawing Circle");
    }
}