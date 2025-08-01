using UnityEngine;

public class MainRoom : MonoBehaviour
{
    public int dungeon_index;
    public GameObject dungeon;
    public Transform entry_point;

    [SerializeField]
    Transform up, down, left, right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool HasUp()
    {
        if (up != null)
        {
            return true;
        }
        return false;
    }
    public Transform GetUp()
    {
        return up;
    }
    public bool HasDown()
    {
        if (down != null)
        {
            return true;
        }
        return false;
    }
    public Transform GetDown()
    {
        return down;
    }
    public bool HasLeft()
    {
        if (left != null)
        {
            return true;
        }
        return false;
    }
    public Transform GetLeft()
    {
        return left;
    }
    public bool HasRight()
    {
        if (right != null)
        {
            return true;
        }
        return false;
    }
    public Transform GetRight()
    {
        return right;
    }
}
