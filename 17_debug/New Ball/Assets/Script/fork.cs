using UnityEngine.UI;
using UnityEngine;

/*
 * fork position range:
 * x = [-4.5, 4.5], y = [1.415, 10.5], z = [-3, 3]
 * definitely hit in about 20s
 * 
 */
public class fork : MonoBehaviour
{

    public blood bloods;
    public Eat eat;
    public GameObject player;
    public Image bloodscreen;
    public score scoreScript;
    public Buffs buff;
    public attack_mark am;

    private float interval;
    private float length;
    private float TimeCount;
    static float hitTime = 20;
    private Vector3 nowPos;
    private Vector3 targetPos;
    private bool moving = false;
    private string parameter;

    // Use this for initialization
    void Start()
    {
        interval = 8.0f;
        length = 3.0f;
        moving = false;

        bloodscreen.gameObject.SetActive(false);
        bloodscreen.transform.SetAsFirstSibling();

        TimeCount = interval;
        if (am.GetNoticeBuff())
        {
            //Debug.Log("true!!!");
            parameter = "hitRandomly";
            Invoke("markFlash", interval - 1.5f);
        } else
        {
            Invoke("hitRandomly", interval);
        }
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    void hitRandomly()
    {
        if (moving) return;
        moving = true;
        //Vector3 
        interval = (2.5f >= interval - (eat.GetPlayerSize() - 1) * 0.2f) ? 2.5f : interval - (eat.GetPlayerSize() - 1) * 0.2f;
        length = (0 >= length - (eat.GetPlayerSize() - 1) * 0.2f) ? 0 : length - (eat.GetPlayerSize() - 1) * 0.2f;
        //Debug.Log("interval = " + interval);

        // hit
        /*Vector3 pos = hitPosition();
        Vector3 up = new Vector3(pos.x, 10.5f, pos.z);
        transform.position = up;
        transform.Translate(Vector3.Normalize(pos - up) * (Vector3.Distance(up, pos) / (interval / 4 * Time.deltaTime)));
        transform.Translate(Vector3.Normalize(up - pos) * (Vector3.Distance(pos, up) / (interval / 4 * Time.deltaTime)));*/

        targetPos = hitPosition();
        nowPos = new Vector3(targetPos.x, 10.5f, targetPos.z);
        transform.position = nowPos;

        Timer timer;
        timer = new Timer(1.0f);
        timer.OnUpdate += move;
        timer.OnEnd += moveUpStart;
        timer.OnEnd += disableMark;
        timer.Start();

        //Debug.Log("done!!!");
        moving = false;

        if (TimeCount >= hitTime)
        {
            TimeCount -= hitTime - interval;
            if (am.GetNoticeBuff())
            {
                //Debug.Log("true!!!");
                parameter = "definitelyHit";
                Invoke("markFlash", interval - 1.5f);
            }
            else
            {
                Invoke("definitelyHit", interval);
            }
        }
        else
        {
            TimeCount += interval;
            if (am.GetNoticeBuff())
            {
                //Debug.Log("true!!!");
                parameter = "hitRandomly";
                Invoke("markFlash", interval - 1.5f);
            }
            else
            {
                Invoke("hitRandomly", interval);
            }
        }
    }

    Vector3 hitPosition()
    {
        Vector3 playerPos = player.GetComponent<Transform>().position;
        float tempSmall = -4.5f >= playerPos.x - length ? -4.5f : playerPos.x - length;
        float tempLarge = 4.5f <= playerPos.x + length ? 4.5f : playerPos.x + length;
        float x = Random.Range(tempSmall, tempLarge);
        //Debug.Log("small: " + tempSmall);
        //Debug.Log(tempLarge);

        tempSmall = -3f >= playerPos.z - length ? -4.5f : playerPos.z - length;
        tempLarge = 3f <= playerPos.z + length ? 4.5f : playerPos.z + length;
        float z = Random.Range(tempSmall, tempLarge);

        return new Vector3(x, 1.415f, z);
    }

    public void definitelyHit()
    {
        if (moving) return;
        moving = true;
        interval = (2.5f >= interval - (eat.GetPlayerSize() - 1) * 0.2f) ? 2.5f : interval - (eat.GetPlayerSize() - 1) * 0.2f;
        length = (0 >= length - (eat.GetPlayerSize() - 1) * 0.2f) ? 0 : length - (eat.GetPlayerSize() - 1) * 0.2f;

        targetPos = new Vector3(player.GetComponent<Transform>().position.x, 1.415f, player.GetComponent<Transform>().position.z);
        nowPos = new Vector3(targetPos.x, 10.5f, targetPos.z);
        transform.position = nowPos;

        Timer timer;
        timer = new Timer(1.0f);
        timer.OnUpdate += move;
        timer.OnEnd += moveUpStart;
        timer.OnEnd += disableMark;
        timer.Start();

        //Debug.Log("done!!!");
        //transform.Translate(Vector3.Normalize(pos - up) * (Vector3.Distance(up, pos) / (interval / 4 * Time.deltaTime)));
        //transform.Translate(Vector3.Normalize(up - pos) * (Vector3.Distance(pos, up) / (interval / 4 * Time.deltaTime)));
        moving = false;
        if (TimeCount >= hitTime)
        {
            TimeCount -= hitTime - interval;
            if (am.GetNoticeBuff())
            {
                //Debug.Log("true!!!");
                parameter = "definitelyHit";
                Invoke("markFlash", interval - 1.5f);
            }
            else
            {
                Invoke("definitelyHit", interval);
            }
        }
        else
        {
            TimeCount += interval;
            if (am.GetNoticeBuff())
            {
                //Debug.Log("true!!!");
                parameter = "hitRandomly";
                Invoke("markFlash", interval - 1.5f);
            }
            else
            {
                Invoke("hitRandomly", interval);
            }
        }
    }

    void move()
    {
        transform.Translate((nowPos - targetPos) * Time.deltaTime / (1.0f));
        
    }

    void moveUpStart()
    {
        //Debug.Log(transform.position);
        Timer timer;
        timer = new Timer(1.0f);
        timer.OnUpdate += moveUp;
        timer.Start();
    }

    void moveUp()
    {
        transform.Translate((targetPos - nowPos) * Time.deltaTime / (1.0f));
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && !buff.GetInvincible())
        {
            Debug.Log("HIT--------");
            bloods.minusBlood(0.1f);
            bloodscreen.gameObject.SetActive(true);
            scoreScript.minusScore(30);
        }
    }

    void markFlash()
    {
        //Debug.Log("mark--------");
        am.MarkFlash();
        Invoke(parameter, 1.5f);
    }

    void disableMark()
    {
        am.DisableMarkFlash();
    }
}
