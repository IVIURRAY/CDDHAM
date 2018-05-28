using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public Camera cam;
    public PlayerController playerOne;
    public PlayerController playerTwo;

    private PlayerController selectedPlayer;
    private CameraFollow followCam;

	// Called once at start of game.
	private void Start()
	{
        followCam = cam.GetComponent<CameraFollow>(); 
	}


	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ProcessMouseClick();
        }
    }

    private void ProcessMouseClick()
    {
        // Shoot a ray from the camera to where our mouse is pointing.
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // If we actually hit something then lets move our player
        if (Physics.Raycast(ray, out hit))
        {
            // INFO: So once we pass `hit` through Physics.raycast it populates with data
            CheeckWhatWasHit(hit);
        }
    }

    private void CheeckWhatWasHit(RaycastHit hit)
    {
        // HACK: Pls don't look, this is urgh! TODO
        if (hit.transform.name == "PlayerOne")
        {
            playerTwo.selected = false;

            selectedPlayer = playerOne;
            playerOne.selected = true;
            playerOne.destination = hit.point;

            followCam.playerSelected = true;
            followCam.player = playerOne.transform;
        }
        else if (hit.transform.name == "PlayerTwo")
        {
            playerOne.selected = false;

            selectedPlayer = playerTwo;
            playerTwo.selected = true;
            playerTwo.destination = hit.point;

            followCam.playerSelected = true;
            followCam.player = playerTwo.transform;
        }
        else if (selectedPlayer)
        {
            // We need to keep sending the new destination to the selected player
            selectedPlayer.destination = hit.point;
        }
    }
}
