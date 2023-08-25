using System.Collections;
using UnityEngine;
public class ObstacleScript : MonoBehaviour
{
    [SerializeField] GameObject particle;
    Material material;
    private void Awake()
    {
        material = GetComponent<MeshRenderer>().materials[^1];
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, .5f);
    }
    public void StartPolution(Color ballColor)
    {
        StartCoroutine(PolutionIE(ballColor));
    }
    IEnumerator PolutionIE(Color ballColor)
    {
        GetComponent<Collider>().enabled = false;
        PathCheckScript.instance.trigerEvent.Invoke(gameObject);
        for (int i = 0; i < 100; i ++)
        {
            yield return new WaitForSeconds(.01f);
            material.color = Color.Lerp(material.color, ballColor, .025f);
            transform.localScale += new Vector3(.004f, .004f, .004f);
        }
        particle.SetActive(true);
        particle.transform.parent = null;
        gameObject.SetActive(false);
    }
    // This method is called when Gizmos are drawn for selected objects in the Scene view.
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(transform.position, new Vector3(1.0f, 2.0f, 2.0f));
    //}
}