using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    [SerializeField] private Animator GunMove;
    [SerializeField] private Animator CamMove;
    [SerializeField] private GameObject Player;
    PlayerController controller;
    void Start()
    {
        controller = Player.GetComponent<PlayerController>();
    }
    void Update()
    {
        if(controller.ActiveMove == true && !Input.GetKey(KeyCode.LeftShift))
        {
            GunMove.SetBool("MovePlayer", true);
           
        }
        else
        {
            GunMove.SetBool("RunPlayer", false);
            GunMove.SetBool("MovePlayer", false);
        }
        if (Input.GetKey(KeyCode.LeftShift)&& controller.ActiveMove==true)
        {
            CamMove.SetBool("RunPlayer", true);
        }
        else
        {
            CamMove.SetBool("RunPlayer", false);
        }
    }
}
