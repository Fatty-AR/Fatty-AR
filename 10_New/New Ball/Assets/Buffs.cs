using UnityEngine;
using UnityEngine.UI;

public class Buffs : MonoBehaviour
{

    private bool onBuff = false;
    private int i = 0;
    public ScrollCircle controller;//虚拟摇杆
    public blood bloods;
    public Text state;
    public ring circleScript;

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
        switch (random) {
            case 1://五秒加速buff
                state.text = "移动速度增加 持续10秒";
                timer = new Timer(10f);
                timer.OnStart += SpeedUp;
                timer.OnEnd += SpeedDown;
                timer.OnEnd += clearText;
                timer.Start();
                break;
            case 2://五秒减速buff
                state.text = "移动速度减缓 持续10秒";
                timer = new Timer(10f);
                timer.OnStart += SpeedDown;
                timer.OnEnd += SpeedUp;
                timer.OnEnd += clearText;
                timer.Start();
                break;
            case 3://原地冻结五秒
                state.text = "原地冻结 持续5秒";
                timer = new Timer(5f);
                timer.OnStart += freeze;
                timer.OnEnd += unfreeze;
                timer.OnEnd += clearText;
                timer.Start();
                break;
            case 4://血量掉30
                state.text = "食物中毒，血量骤减30%";
                timer = new Timer(3f);
                timer.OnStart += hurt;
                timer.OnEnd += clearText;
                timer.Start();
                break;
            case 5://血量加10
                state.text = "血量上升10%";
                timer = new Timer(3f);
                timer.OnStart += heal;
                timer.OnEnd += clearText;
                timer.Start();
                break;
            case 6://叉子直接叉一下；
                state.text = "幸运值降低，被叉子攻击了一下";
                timer = new Timer(3f);
                timer.OnEnd += clearText;
                break;
            case 7://10秒无敌状态
                state.text = "进入10秒无敌状态";
                timer = new Timer(10f);
                timer.OnEnd += clearText;
                break;
            case 8://吃速度加速；
                state.text = "进食速度加快";
                timer = new Timer(3f);
                timer.OnStart += speedUpEat;
                timer.OnEnd += clearText;
                break;
            case 9://获得叉子警报器一枚；
                state.text = "幸运值上升，将预知叉子的攻击";
                timer = new Timer(3f);
                timer.OnEnd += clearText;
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

        controller.enabled = false;
    }

    void unfreeze()
    {
        controller.enabled = true;
    }

    void hurt()
    {
        bloods.minusBlood(0.3f);
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
}
