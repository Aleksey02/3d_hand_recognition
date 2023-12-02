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
         Debug.Log("Checking cube interaction conditions");
        Vector3 handSphere4Pos = handTracking.handPoints[4].transform.position;
        Vector3 handSphere8Pos = handTracking.handPoints[8].transform.position;

        foreach (GameObject cube in cubes)
        {
            float distanceToCube = Vector3.Distance(cube.transform.position, handSphere4Pos);
            Debug.Log($"Distance to cube: {distanceToCube}");
            Debug.Log($"Cube position: {cube.transform.position}");
    Debug.Log($"Hand position (sphere 4): {handSphere4Pos}");
            if (distanceToCube < cubeInteractionDistanceThreshold)
            {
                Debug.Log($"Interaction condition met for cube {cube.name}");
                return true;
            }
        }
        Debug.Log("Interaction condition not met");
        return false;
    }

    void MoveCubes()
    {
        Debug.Log("Move cubes");
        // Логика подъема кубов на основе данных отслеживания рук
        // Например, изменение позиции кубов в зависимости от движения рук
    }
}
