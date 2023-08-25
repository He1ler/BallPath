using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject pathChecker;
    [SerializeField] Transform spawnPoint;
    [SerializeField] LineRenderer lineRenderer;
    [Header("PlayerParams")]
    [SerializeField] float playerMinSize = .3f;
    [SerializeField] float playerStartSize = 1f;
    [SerializeField] float playerSizePerUpdate;
    [Header("BallParams")]
    [SerializeField] float ballSizePerUpdate;
    [SerializeField] float ballStartForce;
    [SerializeField] float ballForce;
    [SerializeField] float ballForcePerUpdate;
    [SerializeField] float ballStartSize = .25f;
    Vector3 ballSize = Vector3.zero;
    Vector3 playerSize = Vector3.zero;
    Transform playerTransform;
    Touch curTouch;
    bool isStarted = false;
    bool isEnd = false;
    //[SerializeField] float timeStep;
    //float tapTime = 0;
    private void Awake()
    {
        playerTransform = transform;
        lineRenderer.startWidth = playerSize.x;
        lineRenderer.endWidth = playerSize.x;
        lineRenderer.gameObject.SetActive(true);
        playerSize = new Vector3(playerStartSize, playerStartSize, playerStartSize);
        playerTransform.localScale = playerSize;
        pathChecker.SetActive(true);
        RefreshBall();
    }
    // Update is called once per frame
    void Update()
    {
        BallSpawnControlFunc();
    }
    void BallSpawnControlFunc()
    {
        if (isEnd) 
        {
            return;
        }
        if (Input.touchCount > 0)
        {
            curTouch = Input.GetTouch(0);
            if (curTouch.phase == TouchPhase.Began)
            {
                isStarted = true;
                //tapTime = 0;
            }
            //tapTime += curTouch.deltaTime;
            if(curTouch.phase == TouchPhase.Ended && isStarted)
            {
                SpawnBall();
                return;
            }
            TouchStep();
        }
    }
    void TouchStep()
    {
        playerSize -= new Vector3(playerSizePerUpdate, playerSizePerUpdate, playerSizePerUpdate);
        playerTransform.localScale = playerSize;
        ballSize += new Vector3(ballSizePerUpdate, ballSizePerUpdate, ballSizePerUpdate);
        ballForce += ballForcePerUpdate;
        //pathChecker.transform.localScale = new Vector3(playerSize.x, playerSize.y, pathChecker.transform.localScale.z);
        lineRenderer.startWidth = playerSize.x;
        lineRenderer.endWidth = playerSize.x;
        if(playerSize.x <= playerMinSize)
        {
            GameManager.instance.LoseGame();
            isEnd = true;
        }
    }
    void RefreshBall()
    {
        ballSize = new Vector3(ballStartSize, ballStartSize, ballStartSize);
        ballForce = ballStartForce;
    }
    void SpawnBall()
    {
        GameObject ball = ObjectPooling.instance.SpawnFromPool("ball", spawnPoint.position, Quaternion.identity);
        ball.transform.localScale = ballSize;
        ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * ballForce);
        RefreshBall();
    }
    public void WinGame()
    {
        pathChecker.SetActive(false);
        lineRenderer.gameObject.SetActive(false);
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.AddForce(Vector3.forward * 300);
    }
}