using UnityEngine;
using System.Collections;

public class TrggerShuttleUp : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPosition;
    [SerializeField] private Transform TargetPlayerPosition;

    [SerializeField] private WaitForSeconds PlayerControllerBoolTimer = new WaitForSeconds(0.1f);
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("0");
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("1");
                StartCoroutine(PlayerControllerBool());
                PlayerPosition.transform.position = TargetPlayerPosition.position;
            }
        }
    }
    IEnumerator PlayerControllerBool()
    {
        PlayerPosition.GetComponent<PlayerController>().enabled = false;
        yield return PlayerControllerBoolTimer;
        PlayerPosition.GetComponent<PlayerController>().enabled = true;
    }
}
