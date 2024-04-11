using UnityEngine;

public class TriggersWaterDamagePlayer : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    HpBar playerController;

    

        private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerController = Player.GetComponent<HpBar>();

            playerController.PlayerDamageFromWater();
        }
    }
}
