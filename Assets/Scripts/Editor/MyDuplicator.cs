using UnityEngine;

[ExecuteInEditMode]
public class MyDuplicator : MonoBehaviour
{
    public GameObject obj;
    public Vector3 offset;

    void Update()
    {
        Transform pos = obj.transform;
        pos.Translate(offset);
        Instantiate(obj, pos);
    }
}