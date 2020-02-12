using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;
    public LayerMask levelMask;


    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject,3);
        Invoke("Explode", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
        StartCoroutine(CreateExplosions(Vector3.forward));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.back));
        StartCoroutine(CreateExplosions(Vector3.left));

        Destroy(gameObject);
    }

    private IEnumerator CreateExplosions(Vector3 direction)
    {
        RaycastHit hit;
        Physics.Raycast(transform.position + new Vector3(0, .5f, 0), direction, out hit,1, levelMask);

        if (!hit.collider)
        {
            Instantiate(explosionPrefab, transform.position + direction, explosionPrefab.transform.rotation);
        }

        yield return new WaitForSeconds(.05f);
    }

}
