using UnityEngine;
using UnityEngine.UI;

public class Buffs : MonoBehaviour
{

    private bool onBuff = false;
    public Image bloodscreen;
    public blood bloods;
    public Text state;
    public ring circleScript;
    private bool isFrozen = false;
    private bool isInvincible = false;//无敌
    private bool knowFork = false;
    public attack_mark attack_mark_script;
    public fork forkScript;
    public score scoreScript;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doBuff()
    {
        Timer timer;
        int random = Random.Range(1, 9);
        if (knowFork)
        {
            random = Random.Range(1, 8);
        }
        switch (random) {
            case 1://五秒加速buff
                state.text = "移动速度增加 持续10秒";
                timer = new Timer(10f);
                timer.OnStart += SpeedUp;
                timer.OnStart += addScore;
                timer.OnEnd += SpeedDown;
                timer.OnEnd += clearText;
                timer.Start();
                break;
            case 2://五秒减速buff
                if (isInvincible == true)
                {
                    state.text = "无敌状态，食物减速效果失效";
                    timer = new Timer(2f);
                    timer.OnEnd += clearText;
                    timer.Start();
                } else
                {
                    state.text = "移动速度减缓 持续10秒";
                    timer = new Timer(10f);
                    timer.OnStart += SpeedDown;
                    timer.OnStart += minusScore;
                    timer.OnEnd += SpeedUp;
                    timer.OnEnd += clearText;
                    timer.Start();
                }
                break;
            case 3://原地冻结五秒
                if (isInvincible == true)
                {
                    state.text = "无敌状态，原地冻结效果失效";
                    timer = new Timer(2f);
                    timer.OnEnd += clearText;
                    timer.Start();
                } else
                {
                    state.text = "原地冻结 持续5秒";
                    timer = new Timer(5f);
                    timer.OnStart += freeze;
                    timer.OnStart += minusScore;
                    timer.OnEnd += unfreeze;
                    timer.OnEnd += clearText;
                    timer.Start();
                }
                
                break;
            case 4://血量掉20
                timer = new Timer(2f);
                timer.OnStart += hurt;
                timer.OnEnd += clearText;
                timer.Start();
                break;
            case 5://血量加10
                state.text = "血量上升10%";
                timer = new Timer(2f);
                timer.OnStart += heal;
                timer.OnStart += addScore;
                timer.OnEnd += clearText;
                timer.Start();
                break;
            case 6://叉子直接叉一下；
                state.text = "幸运值降低，被叉子攻击了一下";
                timer = new Timer(1.5f);
                timer.OnStart += attackedByFork;
                timer.OnStart += minusScore;
                timer.OnEnd += clearText;
                timer.Start();
                break;
            case 7://10秒无敌状态
                state.text = "进入10秒无敌状态";
                timer = new Timer(10f);
                timer.OnStart += invincible;
                timer.OnStart += addScore;
                timer.OnEnd += unInvincible;
                timer.OnEnd += clearText;
                timer.Start();
                break;
            case 8://吃速度加速；
                state.text = "进食速度加快";
                timer = new Timer(2f);
                timer.OnStart += speedUpEat;
                timer.OnStart += addScore;
                timer.OnEnd += clearText;
                timer.Start();
                break;
            case 9://获得叉子警报器一枚；
                state.text = "幸运值上升，将预知叉子的攻击";
                timer = new Timer(2f);
                if (knowFork == false)
                {
                    timer.OnStart += knowForkBefore;
                    timer.OnStart += addScore;
                }
                timer.OnEnd += clearText;
                timer.Start();
                break;

        }
    }

    void SpeedUp()
    {
        float speed = gameObject.GetComponent<SimpleCharacterControl>().GetMoveSpeed();
        gameObject.GetComponent<SimpleCharacterControl>().SetMoveSpeed(speed * 3);
        Debug.Log("speed"+speed*3);
    }

    void SpeedDown()
    {
        float speed = gameObject.GetComponent<SimpleCharacterControl>().GetMoveSpeed();
        gameObject.GetComponent<SimpleCharacterControl>().SetMoveSpeed(speed / 3);
        Debug.Log("speed"+speed/3);
    }

    void freeze()
    {
        isFrozen = true;
    }

    void unfreeze()
    {
        isFrozen = false;
    }

    void hurt()
    {
        if(isInvincible == true)
        {
            state.text = "无敌状态中，食物中毒失效";
        } else
        {
            state.text = "食物中毒，血量骤减20%";
            //bloodscreen.gameObject.SetActive(true);
            bloodscreen.GetComponent<bloodscreenselfdestory>().behit();
            bloods.minusBlood(0.2f);
            minusScore();
        }
    }

    void heal()
    {
        bloods.addBlood(0.1f);
    }

    void clearText()
    {
        state.text = "";
    }

    void speedUpEat()
    {
        circleScript.SpeedUp();
    }

    void invincible()// 无敌
    {
        isInvincible = true;
    }

    void unInvincible()//解除无敌状态
    {
        isInvincible = false;
    }

    public bool GetIsFrozen()
    {
        return isFrozen;
    }

    void knowForkBefore()// 预知叉子攻击
    {
        knowFork = true;
        attack_mark_script.SetNoticeBuff(true);
    }

    public bool GetInvincible() //获取是否无敌状态
    {
        return isInvincible;
    }

    public bool GetIfKnowForkBefore()
    {
        return knowFork;
    }

    public void addScore()
    {
        scoreScript.addScore(10);
    }

    public void minusScore()
    {
        scoreScript.minusScore(10);
    }

    void attackedByFork()
    {
        bloods.minusBlood(0.1f);
        //bloodscreen.gameObject.SetActive(true);
        bloodscreen.GetComponent<bloodscreenselfdestory>().behit();
    }
}
