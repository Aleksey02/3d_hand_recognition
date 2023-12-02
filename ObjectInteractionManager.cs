using UnityEngine;

public class ObjectInteractionManager : MonoBehaviour
{
    public HandTracking handTracking;
    public GameObject[] cubes;
    private enum InteractionMode { None, Move, Rotate, Scale }
    private InteractionMode currentMode = InteractionMode.None;
    private float cubeInteractionDistanceThreshold = 0.1f;

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
        Vector3 handSphere4Pos = handTracking.handPoints[4].transform.position;
        Vector3 handSphere8Pos = handTracking.handPoints[8].transform.position;

        foreach (GameObject cube in cubes)
        {
            float distanceToCube = Vector3.Distance(cube.transform.position, handSphere4Pos);
            if (distanceToCube < cubeInteractionDistanceThreshold)
            {
                return true;
            }
        }

        return false;
    }

    void MoveCubes()
    {
        // Логика подъема кубов на основе данных отслеживания рук
        // Например, изменение позиции кубов в зависимости от движения рук
    }
}
