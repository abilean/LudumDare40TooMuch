using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wiggle : MonoBehaviour {

    [Tooltip("Set a 1 in ? chance to wiggle")]
    public int ChanceToWiggle = 2000;
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Random.Range(0,ChanceToWiggle) < 1)
        {
            StartCoroutine(Move());
        }
	}

    private IEnumerator Move()
    {
        this.transform.position = new Vector3(transform.localPosition.x + 0.2f, transform.localPosition.y, this.transform.position.z);

        yield return new WaitForSeconds(0.01f);

        this.transform.position = new Vector3(transform.localPosition.x - 0.3f, transform.localPosition.y, this.transform.position.z);

        yield return new WaitForSeconds(0.01f);

        this.transform.position = new Vector3(transform.localPosition.x + 0.1f, transform.localPosition.y, this.transform.position.z);
    }
}
