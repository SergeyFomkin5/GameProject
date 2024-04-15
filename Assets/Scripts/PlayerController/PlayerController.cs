using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 1.5f;

    [SerializeField] private Transform head;

    [SerializeField] private float sensitivity = 5f; // чувствительность мыши
    [SerializeField] private float headMinY = -40f; // ограничение угла для головы
    [SerializeField] private float headMaxY = 40f;

    [SerializeField] private KeyCode jumpButton = KeyCode.Space; // клавиша для прыжка
    [SerializeField] private float jumpForce = 10; // сила прыжка
    [SerializeField] private float jumpDistance = 1.2f; // расстояние от центра объекта, до поверхности

    [SerializeField] private  Vector3 direction;
    [SerializeField] private  float h, v;
    [SerializeField] private  int layerMask;
    [SerializeField] private  Rigidbody body;
    [SerializeField] private float rotationY;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
    }

    void FixedUpdate()
    {
        body.AddForce(direction * speed, ForceMode.VelocityChange);

        // Ограничение скорости, иначе объект будет постоянно ускоряться
        if (Mathf.Abs(body.velocity.x) > speed)
        {
            body.velocity = new Vector3(Mathf.Sign(body.velocity.x) * speed, body.velocity.y, body.velocity.z);
        }
        if (Mathf.Abs(body.velocity.z) > speed)
        {
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, Mathf.Sign(body.velocity.z) * speed);
        }
    }

    bool GetJump() // проверяем, есть ли коллайдер под ногами
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit, jumpDistance, layerMask))
        {
            return true;
        }

        return false;
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        direction = new Vector3(h, 0, v);
        direction = head.TransformDirection(direction);
        direction = new Vector3(direction.x, 0, direction.z);

        if (Input.GetKeyDown(jumpButton) && GetJump())
        {
            body.velocity = new Vector2(0, jumpForce);
        }
    }

    void OnDrawGizmosSelected() // подсветка, для визуальной настройки jumpDistance
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * jumpDistance);
    }
}