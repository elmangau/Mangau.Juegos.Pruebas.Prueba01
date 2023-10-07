using UnityEngine;

public class AnimationAutoDestroy : MonoBehaviour
{
    public float delay = 0.1f;

    void Start()
    {
        if (TryGetComponent<Animator>(out var animator))
        {
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length + delay);
        }
    }
}
