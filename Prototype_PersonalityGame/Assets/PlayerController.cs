using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent agent;

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            // Shoot a ray from the camera to where our mouse is pointing.
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If we actually hit something then lets move our player
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
	}
}
