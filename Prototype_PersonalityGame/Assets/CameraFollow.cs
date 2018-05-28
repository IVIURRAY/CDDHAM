using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;                // our player
    public float smoothSpeed = 1.5f;      // speed to smooth transitions instead of snapping to player
    public Vector3 offset;                  // how far back on x, y, z we want to be from our player (otherwise we'll be inside our player)


    // Fixed update moves after update() so the player would've
    // moved first before we follow them.
    private void FixedUpdate()
    {
        CheckForScrollWheel();
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        // Apply offset and use linier interpolation to get the distance between player moved
        // and where we want to go. This give the camera that kind of delayed follow look.
        Vector3 desiredPos = player.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPos;
    }

    private void CheckForScrollWheel()
    {
        // Scroll in and out with scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            SetOffset(offset + Vector3.one);
        }
        else if (scroll < 0f)
        {
            SetOffset(offset - Vector3.one);
        }
    }

    private void SetOffset(Vector3 newOffset)
    {
        // We validate the new offset here so that we don't go to close or to far.
        if (newOffset.x > 1 && newOffset.x < 10)
        {
            offset = newOffset;
        }
    }
}
