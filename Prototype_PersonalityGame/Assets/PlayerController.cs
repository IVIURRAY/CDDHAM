using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool selected;
    public Vector3 destination;

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            agent.SetDestination(destination);
        }
    }
}
