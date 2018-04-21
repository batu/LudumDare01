using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class QuadGame : MonoBehaviour {

    const int numQuads = 4;
    int score = 0;
    GameObject[] Quads;
    List<int> clickedList;
    List<int> randomList;


    // Use this for initialization
    void Start () {
        Quads = new GameObject[numQuads];
        clickedList = new List<int>();
        randomList = new List<int>();

        for (int i = 0; i < numQuads; i++) {
            Quads[i] = transform.GetChild(i).gameObject;
        }
        initilizeTargetList();
    }


    int clickedListIndex = 0;
    public void addToClickedList(int value, Transform transform) {
        Quad quad = transform.gameObject.GetComponent<Quad>();
        clickedList.Add(value);

        if (value == clickedListIndex) {
            quad.updateColor(Color.green);
        } else {
            quad.updateColor(Color.red);
        }
        clickedListIndex += 1;

    }

    IEnumerator ReShuffle() {
        for (int j = 0; j < 32; j++) {
            randomList = Enumerable.Range(0, numQuads).ToList();

            for (int i = 0; i < randomList.Count; i++) {
                int temp = randomList[i];
                int randomIndex = Random.Range(i, randomList.Count);
                randomList[i] = randomList[randomIndex];
                randomList[randomIndex] = temp;
            }


            for (int i = 0; i < numQuads; i++) {
                Quads[i].GetComponent<Quad>().visualInit(randomList[i]);
            }
            yield return null;
        }
        initilizeTargetList();
    }

    void initilizeTargetList() {

        clickedList.Clear();
        randomList.Clear();

        wrappedUp = false;
        clickedListIndex = 0;

        randomList = Enumerable.Range(0, numQuads).ToList();

        for (int i = 0; i < randomList.Count; i++) {
            int temp = randomList[i];
            int randomIndex = Random.Range(i, randomList.Count);
            randomList[i] = randomList[randomIndex];
            randomList[randomIndex] = temp;
        }


        for (int i = 0; i < numQuads; i++) {
            Quads[i].GetComponent<Quad>().init(randomList[i]);
        }
    }

    IEnumerator wrapUp() {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 4; i++) {
            if (i != clickedList[i]) {
                StartCoroutine(ReShuffle());
                yield return null;
            }
        }
        score += 1;
        StartCoroutine(ReShuffle());
        yield return null;
    }

    bool wrappedUp = false;
	// Update is called once per frame
	void Update () {
		if(clickedListIndex == 4 && !wrappedUp) {
            wrappedUp = true;
            StartCoroutine(wrapUp());
        }
	}

}
