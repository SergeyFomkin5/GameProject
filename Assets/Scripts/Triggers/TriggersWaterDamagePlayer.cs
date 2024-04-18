using UnityEngine;

public class TriggersWaterDamagePlayer : MonoBehaviour
{
    [SerializeField] private GameObject Player;
     HpBar playerController;
    [SerializeField] private Rigidbody body;
    [SerializeField] private GameObject ImageWater;

    private void Start()
    {
        playerController = Player.GetComponent<HpBar>();
        ImageWater.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(Player.transform.position.y < 86)
            {
                ImageWater.SetActive(true);
            }
            else
            {
                ImageWater.SetActive(false);
            }
            body.drag = 5;
            playerController.PlayerDamageFromWater();
        }
    }
}
