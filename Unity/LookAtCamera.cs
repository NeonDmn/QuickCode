using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private enum Mode {
        LootAt,
        LookAtInverted,
        CameraFlat,
        CameraFlatInverted
    }
    [SerializeField] private Mode mode;

    private void LateUpdate() {
        switch(mode) {
            case Mode.LootAt:
                transform.LookAt(Camera.main.transform);
            break;
            case Mode.LookAtInverted:
                Vector3 dirFromCamera = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position + dirFromCamera);
            break;
            case Mode.CameraFlat:
                transform.forward = Camera.main.transform.forward;
            break;
            case Mode.CameraFlatInverted:
                transform.forward = -Camera.main.transform.forward;
            break;

        }
    }
}
