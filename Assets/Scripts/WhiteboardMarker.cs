using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteboardMarker :DraggableObject
{
    [SerializeField]
    private Color color;

    [SerializeField]
    private MeshRenderer[] colouredParts;

    [SerializeField]
    private Whiteboard_Painter painter;

    [SerializeField]
    private Whiteboard_PaintReciever paintReceiver;

    protected override void Awake()
    {
        base.Awake();

        foreach (MeshRenderer renderer in colouredParts)
        {
            renderer.material.color = color;
        }

        painter.Initialize(paintReceiver);
        painter.ChangeColour(color);
    }
}
