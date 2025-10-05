using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private void Start()
    {
        Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }
}
