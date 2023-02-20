using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject whatFollow;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = whatFollow.transform.position + new Vector3(0, 0, -1);
    }
}
