using UnityEngine;

/*
 * fork position range:
 * x = [-4.5, 4.5], y = [1.415, 10.5], z = [-3, 3]
 * definitely hit in about 20s
 * 
 */
public class fork : MonoBehaviour {

    public blood bloods;
    public Eat eat;
    public GameObject player;

    private float interval;
    private float length;
    private float TimeCount;
    static float hitTime = 20;
    private Vector3 nowPos;
    private Vector3 targetPos;

    // Use this for initialization
    void Start () {
        interval = 5.0f;
        length = 0.2f;

        TimeCount = interval;
        Invoke("hitRandomly", interval);
	}
	
	// Update is called once per frame
	void Update () {
        

	}

    void hitRandomly()
    {
        //Vector3 
        interval = (2.5f >= interval - (eat.GetPlayerSize() - 1) * 0.2f) ? 2.5f : interval - (eat.GetPlayerSize() - 1) * 0.2f;
        length = (0 >= length - (eat.GetPlayerSize() - 1) * 0.2f) ? 0 : length - (eat.GetPlayerSize() - 1) * 0.2f;
        //Debug.Log("interval = " + interval);

        // hit
        Vector3 pos = hitPosition();
        Vector3 up = new Vector3(pos.x, 10.5f, pos.z);
        transform.position = up;
        transform.Translate(Vector3.Normalize(pos - up) * (Vector3.Distance(up, pos) / (interval / 4 * Time.deltaTime)));
        transform.Translate(Vector3.Normalize(up - pos) * (Vector3.Distance(pos, up) / (interval / 4 * Time.deltaTime)));

        if (TimeCount >= hitTime)
        {
            TimeCount -= hitTime - interval;
            Invoke("definitelyHit", interval);
        }
        else
        {
            TimeCount += interval;
            Invoke("hitRandomly", interval);
        }
    }

    Vector3 hitPosition()
    {
        Vector3 playerPos = player.GetComponent<Transform>().position;
        float tempSmall = -4.5f >= playerPos.x - length ? -4.5f : playerPos.x - length;
        float tempLarge = 4.5f <= playerPos.x + length ? 4.5f : playerPos.x + length;
        float x = Random.Range(tempSmall, tempLarge);

        tempSmall = -3f >= playerPos.z - length ? -4.5f : playerPos.z - length;
        tempLarge = 3f <= playerPos.z + length ? 4.5f : playerPos.z + length;
        float z = Random.Range(tempSmall, tempLarge);

        return new Vector3(x, 1.415f, z);
    }

    void definitelyHit()
    {
        interval = (2.5f >= interval - (eat.GetPlayerSize() - 1) * 0.2f) ? 2.5f : interval - (eat.GetPlayerSize() - 1) * 0.2f;
        length = (0 >= length - (eat.GetPlayerSize() - 1) * 0.2f) ? 0 : length - (eat.GetPlayerSize() - 1) * 0.2f;

        targetPos = player.GetComponent<Transform>().position;
        nowPos = new Vector3(targetPos.x, 10.5f, targetPos.z);
        transform.position = nowPos;

        Timer timer;
        timer = new Timer(interval / 4);
        timer.OnUpdate += move;
        timer.OnEnd += moveUpStart;
        timer.Start();

        Debug.Log("done!!!");
        //transform.Translate(Vector3.Normalize(pos - up) * (Vector3.Distance(up, pos) / (interval / 4 * Time.deltaTime)));
        //transform.Translate(Vector3.Normalize(up - pos) * (Vector3.Distance(pos, up) / (interval / 4 * Time.deltaTime)));

        if (TimeCount >= hitTime)
        {
            TimeCount -= hitTime - interval;
            Invoke("definitelyHit", interval);
        }
        else
        {
            TimeCount += interval;
            Invoke("hitRandomly", interval);
        }
    }

    void move()
    {
        transform.Translate((nowPos - targetPos) * Time.deltaTime * (9.085f / (interval / 4)));
    } 

    void moveUpStart()
    {
        Timer timer;
        timer = new Timer(interval / 4);
        timer.OnUpdate += moveUp;
        timer.Start();
    }

    void moveUp()
    {
        transform.Translate((targetPos - nowPos) * Time.deltaTime * (9.085f / (interval / 4)));
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("HIT--------");
            bloods.minusBlood(0.2f);
        }
    }
}
