using UnityEngine;
public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] Transform[] obstaclePoints;
    [SerializeField] int[] obstacleNumbers;
    [SerializeField] int obstacleSpawnStep = 2;
    public void GenerateLevel(int levelNumber)
    {
        int obstaclePointer = 0;
        int numberOfObstacles = 0;
        if(levelNumber >= obstacleNumbers.Length)
        {
            levelNumber = Random.Range(0, obstacleNumbers.Length);

        }
        for(int i = 0; i < obstaclePoints.Length; i+= obstacleSpawnStep)
        {
            if (numberOfObstacles >= obstacleNumbers[levelNumber] )
            {
                return;
            }
            obstaclePointer = Random.Range(i, i + obstacleSpawnStep);
            Instantiate(obstacles[Random.Range(0, obstacles.Length)], obstaclePoints[obstaclePointer].position, Quaternion.identity);
            numberOfObstacles++;
        }
    }
}