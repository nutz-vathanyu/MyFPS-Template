using UnityEngine;

public class TestAbstraction : MonoBehaviour
{
    Shape s;

    void Update()
    {
        DrawRectangle();
        DrawCircle();
    }

    void DrawRectangle()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            s = gameObject.AddComponent<Rectangle>();
            s.draw();
        }
    }

    void DrawCircle()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            s = gameObject.AddComponent<Circle>();
            s.draw();
        }
    }

}
