using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public List<Transform> mSpawnPositions;
    // Start is called before the first frame update
    void Start()
    {
        StaticPlayer.PickedKey(false);

        int rng = Random.Range(0, mSpawnPositions.Capacity);
        transform.position = mSpawnPositions[rng].position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        StaticPlayer.PickedKey(true);
        Destroy(gameObject);
    }
}
