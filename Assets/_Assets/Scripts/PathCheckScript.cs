using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PathCheckScript : MonoBehaviour
{
    public static PathCheckScript instance;
    [HideInInspector]public UnityEvent<GameObject> trigerEvent;
    bool isWinCondition = false;
    List <GameObject> colliders = new List<GameObject>();
    private void Awake()
    {
        instance = this;
        trigerEvent.AddListener(RemoveCollider);
    }
    private void Start()
    {
        Debug.Log("Start");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 && !colliders.Contains(other.gameObject))
        {
            colliders.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            RemoveCollider(other.gameObject);
        }
    }
    void RemoveCollider(GameObject gameObject)
    {
        if (colliders.Contains(gameObject))
        {
            colliders.Remove(gameObject);
            if (colliders.Count <= 0)
            {
                Debug.Log("Win");
                isWinCondition = true;
                GameManager.instance.WinGame();
                gameObject.SetActive(false);
            }
        }
    }
}