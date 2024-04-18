using UnityEngine;
using System.Collections;

public class ElevatorSystem : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private WaitForSeconds PlayerControllerBoolTimer = new WaitForSeconds(0.1f);
    [SerializeField] private Transform Elevator;
    [SerializeField] private Transform TargetPositionUp;
    [SerializeField] private Transform TargetPositionDown;
    [SerializeField] private Transform TargetPositionPlayer;
    [SerializeField] private bool MoveElevator = true;
     public bool ActiveTargetPlayer=false;
    void Update()
    {
        if (ActiveTargetPlayer == true)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, TargetPositionPlayer.position.y, Player.transform.position.z);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (MoveElevator == true)
                {
                    MoveElevator = false;
                }
                else
                {
                    MoveElevator = true;
                }
            }
        }
        if (MoveElevator == true)
        {
            
            Elevator.position = TargetPositionUp.position;
            
        }
        if (MoveElevator == false)
        { 
            Elevator.position = TargetPositionDown.position;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ActiveTargetPlayer = true;
        }
    }
}
