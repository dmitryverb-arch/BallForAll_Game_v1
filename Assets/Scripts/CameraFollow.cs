using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    [SerializeField] private Transform player; // Лучше Transform, чем GameObject

    [Header("Camera Settings")]
    [SerializeField] private float rotationSpeed = 3f; // Скорость вращения
    [SerializeField] private bool invertX = false; // Можно включить инверсию

    private Vector3 offset;
    private float currentYaw = 0f; // Угол поворота по горизонтали

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        HandleRotation();

        // Применяем поворот вокруг игрока
        Quaternion rotation = Quaternion.Euler(0f, currentYaw, 0f);
        Vector3 rotatedOffset = rotation * offset;

        transform.position = player.position + rotatedOffset;
        transform.LookAt(player.position);
    }

    private void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X"); // Горизонтальное движение мыши

        if (invertX)
            mouseX = -mouseX;

        currentYaw += mouseX * rotationSpeed;
    }
}
