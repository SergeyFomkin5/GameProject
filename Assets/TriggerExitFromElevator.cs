using UnityEngine;

public class TriggerExitFromElevator : MonoBehaviour
{
    [SerializeField] private GameObject Elevator;
    ElevatorSystem ElevatorSystem;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ElevatorSystem = Elevator.GetComponent<ElevatorSystem>();
            ElevatorSystem.ActiveTargetPlayer = false;
        }
    }
}
