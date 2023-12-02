using UnityEngine;

public class StickToObject : MonoBehaviour
{
    // public float stickForce = 10f; // Сила, с которой объект будет прилипать
    // private bool isStuck = false;
    // private Rigidbody rb;

    // private void Start()
    // {
    //     rb = GetComponent<Rigidbody>();
    //     rb.useGravity = false; // Отключаем гравитацию на старту
    // }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (rb.velocity.magnitude < 0.1f) // Проверяем скорость объекта
    // {
    //     // Прикладываем силу, чтобы объект прилип к поверхности
    //     rb.AddForce(collision.contacts[0].normal * stickForce, ForceMode.Force);
    //     rb.useGravity = false; // Отключаем гравитацию при прилипании
    //     isStuck = true;
    // }
    // }
}