using UnityEngine;

public class TrggerShuttleUp : MonoBehaviour
{
    [SerializeField] private Transform PlayerPosition;
    [SerializeField] private Transform TargetPlayerPosition;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("0");
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("1");
                PlayerPosition.position = TargetPlayerPosition.position;
            }
        }
    }
}
