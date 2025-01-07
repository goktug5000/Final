using UnityEngine;

public class DestroyMeAfter : MonoBehaviour
{
    [SerializeField] private float myLifetime;

    void Update()
    {
        myLifetime -= 1*Time.deltaTime;
        if (myLifetime < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
