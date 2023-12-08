using UnityEngine;

public class ObjectInteractionManager : MonoBehaviour
{
    public HandTracking handTracking;
    public GameObject[] cubes;
    private enum InteractionMode { None, Move, Rotate, Scale }
    private InteractionMode currentMode = InteractionMode.None;
    private float cubeInteractionDistanceThreshold = 1.0f;

    void Update()
    {
        if (handTracking.udpReceive.client != null && handTracking.udpReceive.client.Client.Connected)
        {
            if (CheckCubeInteractionConditions())
            {
                currentMode = InteractionMode.Move;

                if (currentMode == InteractionMode.Move)
                {
                    MoveCubes();
                }
            }
            else
            {
                currentMode = InteractionMode.None;
            }
        }
        else
        {
            currentMode = InteractionMode.None;
        }
    }

    bool CheckCubeInteractionConditions()
    {
        //Debug.Log("Checking cube interaction conditions");
        Vector3 handSphere4Pos = handTracking.handPoints[4].transform.position;
        Vector3 handSphere8Pos = handTracking.handPoints[8].transform.position;

        foreach (GameObject cube in cubes)
        {
            float distanceToCube1 = Vector3.Distance(cube.transform.position, handSphere4Pos);
            float distanceToCube2 = Vector3.Distance(cube.transform.position, handSphere8Pos);
            //Debug.Log($"Дистанция между кубом  и сферрой 1: {distanceToCube1} и сферой 2: {distanceToCube2}");
            //Debug.Log($"Cube position: {cube.transform.position}");
            //Debug.Log($"Hand position (sphere 4): {handSphere4Pos}");
            Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();
            if (distanceToCube1 < cubeInteractionDistanceThreshold && distanceToCube2 < cubeInteractionDistanceThreshold)
            {
                //Debug.Log($"куб находится на нужном расстоянии от обеих рук {cube.name}");
        
                // Проверяем, что компонент не равен null
                if (cubeRigidbody != null)
                {
                    // Отключаем вращение по всем осям
                    cubeRigidbody.freezeRotation = true;
                }
                return true;
            }else if(cubeRigidbody!= null){
                cubeRigidbody.freezeRotation = false;
            }
        }
        //Debug.Log("куб не находится на нужном расстоянии от обеих рук");
        return false;
    }

    void MoveCubes()
    {
        Debug.Log("Move cubes");
        // Логика подъема кубов на основе данных отслеживания рук
        // Например, изменение позиции кубов в зависимости от движения рук
        Vector3 handSphere4Pos = handTracking.handPoints[4].transform.position;
    Vector3 handSphere8Pos = handTracking.handPoints[8].transform.position;

    // Определить ближайший куб
    GameObject closestCube = FindClosestCube(handSphere4Pos, handSphere8Pos);

    if (closestCube != null)
    {
        // Вычислить вектор смещения между текущим положением рук и предыдущим положением
        Vector3 offset = handSphere8Pos - handSphere4Pos;

        // Переместить ближайший куб на вектор смещения
        closestCube.transform.position = (handSphere4Pos + handSphere8Pos) / 2;
    }
}

GameObject FindClosestCube(Vector3 position1, Vector3 position2)
{
    GameObject closestCube = null;
    float closestDistance = float.MaxValue;

    foreach (GameObject cube in cubes)
    {
        float distanceToCube1 = Vector3.Distance(cube.transform.position, position1);
        float distanceToCube2 = Vector3.Distance(cube.transform.position, position2);
        float averageDistance = (distanceToCube1 + distanceToCube2) / 2;

        if (averageDistance < closestDistance)
        {
            closestDistance = averageDistance;
            closestCube = cube;
        }
    }

    return closestCube;
}
}
