using UnityEngine;

public class ShuttleRotaion : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0,50*Time.deltaTime,0);
    }
}
