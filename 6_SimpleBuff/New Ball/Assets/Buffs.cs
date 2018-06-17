using UnityEngine;
using UnityEngine.UI;

public class Buffs : MonoBehaviour
{

    private bool onBuff = false;
    private int i = 0;
    public ScrollCircle controller;//虚拟摇杆
    public blood bloods;
    public Text state;

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
        Timer timer5 = new Timer(5f);
        int random = Random.Range(1, 9);
        switch (random) {
            case 1://五秒加速buff
                state.text = "移动速度增加 持续5秒";
                timer5.OnStart += SpeedUp;
                timer5.OnEnd += SpeedDown;
                timer5.OnEnd += clearText;
                timer5.Start();
                break;
            case 2://五秒减速buff
                state.text = "移动速度减缓 持续5秒";
                timer5.OnStart += SpeedDown;
                timer5.OnEnd += SpeedUp;
                timer5.OnEnd += clearText;
                timer5.Start();
                break;
            case 3://原地冻结五秒
                state.text = "原地冻结 持续5秒";
                timer5.OnStart += freeze;
                timer5.OnEnd += unfreeze;
                timer5.OnEnd += clearText;
                timer5.Start();
                break;
            case 4://血量掉30
                state.text = "食物中毒，血量骤减30%";
                timer5.OnStart += hurt;
                timer5.OnEnd += clearText;
                timer5.Start();
                break;
            case 5://血量加10
                state.text = "血量上升10%";
                timer5.OnStart += heal;
                timer5.OnEnd += clearText;
                timer5.Start();
                break;
            case 6://叉子直接叉一下；
                state.text = "幸运值降低，被叉子攻击了一下";
                break;
            case 7://10秒无敌状态
                state.text = "进入10秒无敌状态";
                break;
            case 8://吃速度加速；
                state.text = "进食速度加快";
                break;
            case 9://获得叉子警报器一枚；
                state.text = "幸运值上升，将预知叉子的攻击";
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
}
