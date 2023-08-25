using UnityEngine;
public class BallScript : MonoBehaviour
{
    [SerializeField] GameObject exploisonParticle;
    Color color;
    private void Start()
    {
        color = GetComponent<MeshRenderer>().sharedMaterial.color;
        Destroy(gameObject,15f);
    }
    private void OnTriggerEnter(Collider other)
    {
        Explode();
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, transform.localScale.x * 2, 1 << 7);
        foreach (Collider collider in colliders) 
        {
            collider.GetComponent<ObstacleScript>().StartPolution(color);
        }
        exploisonParticle.transform.localScale = transform.localScale;
        exploisonParticle.transform.parent = null;
        exploisonParticle.SetActive(true);
        gameObject.SetActive(false);
    }
}