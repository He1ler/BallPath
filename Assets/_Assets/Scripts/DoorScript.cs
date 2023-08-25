using UnityEngine;
public class DoorScript : MonoBehaviour
{
    [SerializeField] GameObject conffettie;
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetTrigger("DoorAnim");
            conffettie.SetActive(true);
            GameManager.instance.ShowWinGameUI();
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Collider>().enabled = false;
        }
    }
}