using UnityEngine;
using System.Collections;

public class TriggerShuttleBack : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPosition;
    [SerializeField] private Transform TargetPlayerPosition;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                PlayerPosition.transform.position = TargetPlayerPosition.position;
            }
        }
    }

}