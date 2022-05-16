using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraBehaviour : MonoBehaviour
{
    public Transform transformTarget;
    private Vector3 playerOffset;

    // Start is called before the first frame update
    void Awake()
    {
        playerOffset = transform.position - transformTarget.position;
    }

    private void LateUpdate()
    {
        transform.position = transformTarget.position + playerOffset;
    }
}
