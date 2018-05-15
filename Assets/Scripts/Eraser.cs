using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : DraggableObject
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

    protected override void UpdateRotation(Quaternion targetRotation, float followingSpeed)
    {
        if ((paintReceiver.transform.position - transform.position).z < 0.3f)
        {
            Vector3 eulerRotation = targetRotation.eulerAngles;
            eulerRotation.x = 0f;
            eulerRotation.y = 0f;

            targetRotation = Quaternion.Euler(eulerRotation);
        }

        mRigidbody.rotation = Quaternion.Lerp(mRigidbody.rotation, targetRotation, Time.deltaTime * followingSpeed);
    }
}
