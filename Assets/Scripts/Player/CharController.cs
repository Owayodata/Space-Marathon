using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField] private GameObject[] charModels;
    // Start is called before the first frame update
    private void Awake()
    {
        chooseCharModel(SaveManager.instance.currentChar);
    }

    private void chooseCharModel(int _index)
    {
        Instantiate(charModels[_index], transform.position, Quaternion.identity, transform);
    }
}
