// /* using UnityEngine;

// public class GetObjectPosition : MonoBehaviour
// {
//     //public Transform targetObject; // Переменная для хранения Transform объекта, позицию которого вы хотите получить.
//     public GameObject[] handPoints;
//     void Update()
//     {
//         // Получаем позицию объекта и выводим ее в консоль.
//         Vector3 objectPosition = targetObject.position;
//         SphereCollider sphereCollider = targetObject.GetComponent<SphereCollider>();
//         Debug.Log("Позиция объекта: " + objectPosition);
//         float radius = sphereCollider.radius;
//         Debug.Log("Радиус сферы: " + radius);
//     }

// }
//  */


// using UnityEngine;

// public class GetSphereInfo : MonoBehaviour
// {
//     public GameObject sphere1; // Первая сфера
//     public GameObject sphere2; // Вторая сфера
//     public GameObject[] cubes; // Куб

//     private bool isCubeAttached = false;
//     void Update()
//     {
//         // Получаем позицию и радиус для первой сферы
//         Vector3 position1 = sphere1.transform.position;
//         float radius1 = sphere1.GetComponent<SphereCollider>().radius;

//         // Выводим информацию в консоль
//         //Debug.Log("Первая сфера: Позиция = " + position1 + ", Радиус = " + radius1);

//         // Получаем позицию и радиус для второй сферы
//         Vector3 position2 = sphere2.transform.position;
//         float radius2 = sphere2.GetComponent<SphereCollider>().radius;

//         // Выводим информацию в консоль
//         //Debug.Log("Вторая сфера: Позиция = " + position2 + ", Радиус = " + radius2);

//         float distance = Vector3.Distance(position1, position2);


//         GameObject closestCube = FindClosestCube(position1);

//         // Проверяем условие
//         float thresholdDistance = 2.5f; // Расстояние, на котором должен находиться куб
// float distanceBetweenSpheres = Vector3.Distance(position1, position2); // Расстояние между сферами

// if (distanceBetweenSpheres < 0.5f)
// {
//     foreach (var cube in cubes)
//     {
//         float distanceToSphere1 = Vector3.Distance(position1, cube.transform.position);
//         float distanceToSphere2 = Vector3.Distance(position2, cube.transform.position);

//         // Условие: куб находится на нужном расстоянии от обеих сфер
//          // Добавьте эту переменную в начало вашего скрипта

// // В вашем методе Update
// if (distanceToSphere1 < thresholdDistance && distanceToSphere2 < thresholdDistance)
// {
//     if (!isCubeAttached)
//     {
//         // Ваш код при условии, что оба расстояния меньше thresholdDistance

//         // Предполагая, что куб имеет компонент Rigidbody
//         Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();

//         if (cubeRigidbody != null)
//         {
//             cubeRigidbody.useGravity = false;
//         }

//         isCubeAttached = true; // Устанавливаем флаг, что куб уже приклеен
//     }
// }
// else
// {
//     // Если условие не выполняется, возвращаем гравитацию для куба
//     if (isCubeAttached)
//     {
//         // Предполагая, что куб имеет компонент Rigidbody
//         Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();

//         if (cubeRigidbody != null)
//         {
//             cubeRigidbody.useGravity = true;
//         }

//         isCubeAttached = false; // Сбрасываем флаг, так как куб больше не приклеен
//     }
// }
//     }
// }
//     }

    
//     GameObject FindClosestCube(Vector3 position)
//     {
//         GameObject closestCube = null;
//         float closestDistance = float.MaxValue;

//         // Итерируем по всем кубам
//         foreach (var cube in cubes)
//         {
//             float cubeDistance = Vector3.Distance(position, cube.transform.position);

//             // Если текущий куб ближе, обновляем ближайший куб и расстояние
//             if (cubeDistance < closestDistance)
//             {
//                 closestCube = cube;
//                 closestDistance = cubeDistance;
//             }
//         }

//         return closestCube;
//     }
// }