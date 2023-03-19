using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCursor : MonoBehaviour
{
    private enum DetectionPlane {
        XY,
        XZ
    }

    private enum Dimention {
        Right,
        Up,
        Forward
    }

    [SerializeField] bool onUpdate = true;
    [SerializeField] private DetectionPlane detectionPlane;
    [SerializeField] private Dimention dimention;

    void Update()
    {
        if (!onUpdate) return;

        UpdateRotation();        
    }

    public void UpdateRotation() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
                    mousePosition.x - transform.position.x,
                    mousePosition.y - transform.position.y
                );

        if (detectionPlane == DetectionPlane.XZ) {
            direction.y = mousePosition.y - transform.position.z;
        }

        switch (dimention) {
            case Dimention.Up:
                transform.up = direction;
            break;
            case Dimention.Right:
                transform.right = direction;
            break;
            case Dimention.Forward:
                transform.forward = direction;
            break;
        }
    }
}
