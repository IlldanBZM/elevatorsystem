using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Node<T>//单链表结点类,采用泛型
{
    private T data; //数据域,当前结点的数据  
    private Node<T> next; //引用域,即下一结点  
    public Node(T item, Node<T> p)
    {
        data = item;
        next = p;
    }
    public Node(Node<T> p)
    {
        next = p;
    }
    public Node()
    {
        data = default(T);
        next = null;
    }
    public T Data;
    public Node<T> Next;
}

public class MyLinkList<T>//链表类，包含链表定义及基本操作方法  
{
    public bool hasdelete = false;
    private Node<T> head; //单链表的头结点  
    //头结点属性  
    public Node<T> Head { get { return head; } set { head = value; } }
    //构造器  
    public MyLinkList() { head = null; }
    //求单链表的长度  
    public int Size()
    {
        Node<T> p = head;
        int len = 0;
        while (p != null)
        {
            ++len;
            p = p.Next;
        }
        return len;
    }
    //清空单链表  
    public void Clear() { head = null; }

    //判断单链表是否为空  
    public bool IsEmpty()
    {
        if (head == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //在单链表的末尾添加新元素  
    public void Append(T item)
    {
        Node<T> q = new Node<T>();
        Node<T> p = new Node<T>();//跟踪指针
                                  // Debug.Log(2);
        if (head == null)
        {
            q.Data = item;
            q.Next = null;
            // Debug.Log(1);
            head = q;
            Debug.Log(head.Data);
            return;
        }
        p = head;
        while (p.Next != null)
        {
            p = p.Next;
        }
        q.Data = item;
        q.Next = null;
        p.Next = q;
    }

    //在单链表的第i个结点的位置前插入一个值为item的结点  
    public void Insert(T item, int i)
    {

        if (IsEmpty() || i < 0 || i > Size())
        {
            Debug.Log("LinkList is empty or Position is error!");
            return;
        }
        if (i == 0)
        {
            Node<T> q = new Node<T>();
            q.Data = item;
            q.Next = head;
            head = q;
            return;
        }
        Node<T> p = head;
        Node<T> r = new Node<T>();
        int j = 0;
        while (p.Next != null && j < i)
        {
            r = p;
            p = p.Next;
            ++j;
        }
        if (j == i)
        {
            Node<T> q = new Node<T>();
            q.Data = item;
            q.Next = p;
            r.Next = q;
        }
    }
    //删除单链表的第i个结点  
    public T Delete(int i)
    {
        hasdelete = true;

        if (IsEmpty() || i < 0 || i > Size())
        {
            Debug.Log("LinkList is empty or Position is error!");
            return default(T);
        }
        Node<T> q = new Node<T>();
        if (i == 0)
        {
            q = head;
            head = head.Next;
            hasdelete = true;
            return q.Data;
        }
        Node<T> p = head;
        int j = 0;
        while (p.Next != null && j < i)
        {
            ++j;
            q = p;
            p = p.Next;
        }
        if (j == i)
        {
            q.Next = p.Next;
            hasdelete = true;
            return p.Data;
        }
        else
        {
            Debug.Log("The " + i + "th node is not exist!");
            return default(T);
        }
    }

    //获得单链表的第i个数据元素  
    public T GetData(int i)
    {
        if (IsEmpty() || i < 0)
        {
            Debug.Log("LinkList is empty or position is error! ");
            return default(T);
        }
        Node<T> p = new Node<T>();
        p = head;
        int j = 0;
        while (p.Next != null && j < i)
        {

            ++j;
            p = p.Next;
        }
        if (j == i)
        {
            return p.Data;
        }
        else
        {
            Debug.Log("The" + i + "th node is not exist!");
            return default(T);
        }
    }

    public void SetData(int pos, T per)
    {
        if (pos < 0 || pos > Size() - 1)
        {

            //cout << "参数pos越界出错！" << endl;

            // exit(0);
            Debug.Log("参数pos越界出错！");
            return;
        }
        Node<T> p = Index(pos);
        p.Data = per;
    }

    public Node<T> Index(int pos)
    {//定位函数，返回第pos个结点的地址
        if (pos < 0 || pos > Size() - 1)
        {

            //cout << "参数pos越界出错！" << endl;
            Debug.Log("参数pos越界出错！");
            // exit(0);
        }


        if (pos == 0) return head;

        Node<T> p = head.Next;
        int i = 1;
        while (p != null && i < pos)
        {
            p = p.Next;
            i++;
        }
        return p;
    }

    //在单链表中查找值为value的结点  
    public int Locate(T value)
    {
        if (IsEmpty())
        {
            Debug.Log("LinkList is Empty!");
            return -1;
        }
        Node<T> p = new Node<T>();
        p = head;
        int i = 1;
        while (!p.Data.Equals(value) && p.Next != null)
        {
            p = p.Next;
            ++i;
        }
        return i;
    }

    //显示链表  
    public void Display()
    {
        Node<T> p = new Node<T>();
        p = head;
        while (p != null)
        {
            Debug.Log(p.Data + " ");
            p = p.Next;
        }
    }
}

public class Passenger
{
    static public int number = 0;
    public int tolerant;
    public int ID;
    public int Startfloor { get; set; }
    public int Endfloor { get; set; }
    public int Starttime;
    public Passenger(int sf, int ef, int st)
    {
        number++;
        ID = number;
        Startfloor = sf;
        Endfloor = ef;
        Starttime = st;
    }
    public Passenger()
    {
        ID = 0;
        Startfloor = 0;
        Starttime = 0;
        Endfloor = 0;
        tolerant = 0;
    }
};

public class LiftControl
{
    public bool go_one = false;
    public int deletefloor;
    static public int MAXSIZE = 13;
    static public int runclock = 0, upclock = 0, downclock = 0, openclock = 0, outclock = 0, inclock = 0, closeclock = 0, stayclock = 0, inoutclock = 0, deceleclock = 0;
    public int farest;
    public string State = "WAITING";
    public string StateBeforeStop;
    public int Floor = 1;
    public MyLinkList<Passenger> OutList = new MyLinkList<Passenger>();
    public MyLinkList<Passenger> InList = new MyLinkList<Passenger>();
    public void AddPassenger(Passenger p)
    {
        OutList.Append(p);
        Debug.Log(OutList.Head);
        Debug.Log("第" + p.ID + "号乘客在" + p.Startfloor + "层发出请求");
    }
    public bool isnorequest()
    {//判断电梯外是否无请求
        if (State == "WAITING")
        {
            if (OutList.IsEmpty() && InList.IsEmpty())
            {
                Debug.Log("待命");
                return true;
            }
            else getfinal();
        }
        else getfinal();
        return false;
    }
    public void calculate1(ref int far1, ref int far2)
    {
        int t = 0;
        if (InList.IsEmpty() == false)
        {//电梯里有人
            for (int i = 0; i < InList.Size(); i++)
            {
                int distance = InList.GetData(i).Endfloor - Floor;
                if (distance >= t && distance > 0)
                {//取到在向上方向上的电梯内的最远请求楼层
                    t = distance;
                    far1 = InList.GetData(i).Endfloor;
                }
            }
        }

        if (OutList.IsEmpty() == false)
        {//等待队列有人
            t = 0;
            for (int i = 0; i < OutList.Size(); i++)
            {
                int distance = OutList.GetData(i).Startfloor - Floor;
                if (distance >= t && distance > 0)
                {//取到在向上方向上的电梯外的最远请求楼层
                    t = distance;
                    far2 = OutList.GetData(i).Startfloor;
                }
            }
        }
    }
    public void calculate2(ref int far1, ref int far2)
    {
        int t = 0;
        if (InList.IsEmpty() == false)//电梯里有人
        {
            for (int i = 0; i < InList.Size(); i++)
            {
                int distance = Floor - InList.GetData(i).Endfloor;
                if (distance >= t && distance > 0)
                {//在向下方向上的电梯内的最远请求楼层
                    t = distance;
                    far1 = InList.GetData(i).Endfloor;
                }
            }
        }
        if (OutList.IsEmpty() == false)
        {//等待队列有人
            t = 0;
            for (int i = 0; i < OutList.Size(); i++)
            {
                int distance = Floor - OutList.GetData(i).Startfloor;
                if (distance >= t && distance > 0)
                {//在向下方向上的电梯外的最远请求楼层
                    t = distance;
                    far2 = OutList.GetData(i).Startfloor;
                }
            }
        }
    }
    public void getfinal()
    {
        farest = Floor;
        if (State == "CLOSED")
        {
            if (OutList.Size() == 0 && InList.Size() == 0)
            {//两队列都为空就进入判定状态，300t后返回1层
                State = "IS_STOP";
                Go(farest);
                return;
            }
            if (Floor == 1) State = "UP";
            if (Floor == 9) State = "DOWN";
            if ((StateBeforeStop == "UP") && (Floor != 9))
            {
                int up_farin = 0, up_farout = 0;
                calculate1(ref up_farin, ref up_farout);
                if (up_farin == 0 && up_farout == 0) State = "DOWN";//说明再往上没有任务,下楼
                if (up_farin <= up_farout) farest = up_farout;
                else farest = up_farin;
            }
            if (((StateBeforeStop == "DOWN") && (Floor != 1)))
            {
                int down_farin = 0, down_farout = 0;
                calculate2(ref down_farin, ref down_farout);
                if (down_farin == 0 && down_farout == 0) State = "UP";//说明再往下没有任务,上楼
                if (down_farin <= down_farout) farest = down_farin;
                else farest = down_farout;
            }
        }
        if (State == "WAITING")//此时电梯在一楼，只判断向上的请求
        {
            bool had = false;
            int m = 0;
            for (int i = 0; i < OutList.Size(); i++)
            {
                Debug.Log(OutList.GetData(i));
                if (OutList.GetData(i).Startfloor == 1)
                {
                    had = true;
                    break;
                }
                int distance = System.Math.Abs(OutList.GetData(i).Startfloor - Floor);
                if (distance >= m)
                {
                    m = distance;
                    farest = OutList.GetData(i).Startfloor;
                }
            }
            if (had)
            {
                State = "OPENING";
                OpenDoor();
            }
        }
        if (State == "UP")
        {
            int up_farin = 0, up_farout = 0;
            calculate1(ref up_farin, ref up_farout);
            if (up_farin <= up_farout) farest = up_farout;
            else farest = up_farin;
        }
        if (State == "DOWN")
        {
            int down_farin = 0, down_farout = 0;
            calculate2(ref down_farin, ref down_farout);
            if (down_farin <= down_farout) farest = down_farout;
            else farest = down_farin;
        }
        Go(farest);
    }
    public void OpenDoor()
    {
        if (State != "OPENING")
        {
            StateBeforeStop = State;
            State = "DECELERATE";
            return;
        }

        if (openclock < 20)
        {
            openclock++;
            //cout << "开门中";
            Debug.Log("开门中");
            return;
        }
        else
        {
            openclock = 0;
            //  cout << "开门完成";
            Debug.Log("开门完成");
            State = "OPENED";
            return;
        }
    }
    public bool Judgepersonout()
    {
        if (InList.IsEmpty() == false)//电梯有人
        {
            for (int i = 0; i < InList.Size(); i++)
            {
                if (InList.GetData(i).Endfloor == Floor)
                    return true;
            }
        }
        return false;
    }
    public void Out()
    {
        if (outclock < 25)
        {
            if (State == "OPENED")
            {
                outclock++;
                //cout << "正在出人";
                Debug.Log("正在出人");
                for (int i = 0; i < InList.Size(); i++)
                {
                    if (InList.GetData(i).Endfloor == Floor)
                    {
                        //cout << "第" << InList.GetData(i).ID << "个人";
                        Debug.Log("第" + InList.GetData(i).ID + "个人");
                        InList.Delete(i);

                    }
                }
                State = "OUT";
                return;
            }
            if (State == "OUT")
            {
                outclock++;
                //cout << "正在出人";
                Debug.Log("正在出人");
                return;
            }
        }
        else
        {
            //cout << "人出去了";
            Debug.Log("人出去了");
            outclock = 0;
            State = "OPENED";
        }
    }
    public bool Judgepersonin()
    {
        if (!OutList.IsEmpty())
        {
            for (int i = 0; i < OutList.Size(); i++)
            {
                if (OutList.GetData(i).Startfloor == Floor)
                {
                    if (((OutList.GetData(i).Endfloor - OutList.GetData(i).Startfloor >= 0) && State == "UP") || ((OutList.GetData(i).Endfloor - OutList.GetData(i).Startfloor >= 0) && StateBeforeStop == "UP") || farest == Floor)
                        return true;
                    if (((OutList.GetData(i).Endfloor - OutList.GetData(i).Startfloor <= 0) && State == "DOWN") || ((OutList.GetData(i).Endfloor - OutList.GetData(i).Startfloor <= 0) && StateBeforeStop == "DOWN") || farest == Floor)
                        return true;
                }
            }
        }
        return false;
    }
    public void In()
    {
        if (InList.Size() < MAXSIZE)
        {
            if (inclock < 25)
            {
                if (State == "OPENED")
                {
                    inclock++;
                    Debug.Log("正在进人");
                    for (int i = 0; i < OutList.Size(); i++)
                    {
                        if (OutList.GetData(i).Startfloor == Floor)
                        {
                            Debug.Log("第" + OutList.GetData(i).ID + "个人");
                            InList.Append(OutList.GetData(i));//上人
                            Passenger one = OutList.Delete(i);//清出等待队列
                            deletefloor = one.Startfloor;
                            State = "IN";
                            return;
                        }
                    }
                }
                if (State == "IN")
                {
                    inclock++;
                    Debug.Log("正在进人");
                    return;
                }
            }
            else
            {
                Debug.Log("人进来了");
                inclock = 0;
                State = "OPENED";
            }
        }
        else
        {
            Debug.Log("电梯已满不能上人");
            State = "CLOSED";
        }
    }
    public void CloseDoor()
    {
        if (closeclock < 20)
        {
            if (Judgepersonin())
            {
                State = "OPENED";
                In();
                return;
            }
            closeclock++;
            State = "CLOSEING";
            Debug.Log("关门中");
        }
        else
        {
            closeclock = 0;
            Debug.Log("关门完成");
            State = "CLOSED";
            getfinal();
        }
    }
    public void returnone()
    {
        if (State != "IS_STOP")
        {
            stayclock = 0;
            return;
        }
        if (stayclock < 300)
        {
            if (OutList.Size() == 0 && InList.Size() == 0)
            {
                stayclock++;
                Debug.Log("正在检测是否无人等待，第" + stayclock + "t");
            }
            else
            {
                for (int i = 0; i < OutList.Size(); i++)
                {
                    if (OutList.GetData(i).Startfloor == Floor)
                    {
                        State = "OPENING";
                        return;
                    }
                    //此时在电梯外先按键的优先
                    if (OutList.GetData(i).Startfloor > Floor)
                    {
                        State = "UP";
                        return;
                    }
                    if (OutList.GetData(i).Startfloor < Floor)
                    {
                        State = "DOWN";
                        return;
                    }
                }
            }
        }
        else
        {
            if (Floor > 1)
            {
                go_one = true;
                GoDown();
            }
            if (Floor == 1)
            {
                State = "WAITING";
                stayclock = 0;
                return;
            }
        }
    }
    public void isClosedoor()
    {
        if (inoutclock < 40)
        {
            inoutclock++;
            Debug.Log("正在等待是否有其他人进入");
            return;
        }
        else
        {
            Debug.Log("关门测试");
            if (State == "OPENED")
            {
                CloseDoor();
                inoutclock = 0;
                return;
            }
            else
            {
                inoutclock = 0;
                return;
            }
        }
    }
    public void Go(int farest)
    {
        if (farest < Floor)
        {
            State = "DOWN";
            GoDown();
            return;
        }
        if (farest > Floor)
        {
            State = "UP";
            GoUp();
            return;
        }
        if (farest == Floor)
        {
            if (State == "DECELERATE")
            {
                if (StateBeforeStop == "UP")
                {
                    deceleclock++;
                    Debug.Log("减速");
                    if (deceleclock > 13)
                    {
                        deceleclock = 0;
                        Debug.Log("结束，准备开门");
                        State = "OPENING";
                        return;
                    }
                    else return;
                }
                if (StateBeforeStop == "DOWN")
                {
                    deceleclock++;
                    Debug.Log("减速");
                    if (deceleclock > 22)
                    {
                        deceleclock = 0;
                        Debug.Log("结束，准备开门");
                        State = "OPENING";
                        return;
                    }
                    else return;
                }
            }
            if (State == "OPENING")
            {
                OpenDoor();
                return;
            }
            if (State == "IN")
            {
                In();
                return;
            }
            if (State == "OUT")
            {
                Out();
                return;
            }
            if (State == "OPENED")
            {
                if (Judgepersonout() == false && Judgepersonin() == false) isClosedoor();
                if (Judgepersonout()) Out();
                if (Judgepersonin()) In();
                return;
            }
            if (State == "CLOSEING")
            {
                CloseDoor();
                return;
            }
            if (State == "IS_STOP") returnone();
        }
    }
    public void Judge_tolerant()
    {
        for (int i = 0; i < OutList.Size(); i++)
        {

            Passenger p = OutList.GetData(i);
            p.tolerant++;
            OutList.SetData(i, p);
            if (OutList.GetData(i).tolerant > 1000 && State != "OPENING" && State != "OPENED")
            {
                Debug.Log("第" + OutList.GetData(i).ID + "个乘客受不了了，放弃了！");
                Passenger one = OutList.Delete(i);
                deletefloor = one.Startfloor;
                if (OutList.Size() == 0 && InList.Size() == 0)
                {
                    State = "IS_STOP";
                    Go(Floor);
                    return;
                }
            }
        }
    }
    public void GoUp()
    {
        if (upclock < 50)
        {
            upclock++;
            Debug.Log("上楼");
            return;
        }
        else
        {
            Floor++;
            upclock = 0;
            if (!Judgepersonout() && !Judgepersonin()) GoUp();
            else
            {
                Debug.Log("电梯准备减速");
                OpenDoor();
            }

        }
    }
    public void GoDown()
    {
        if (State == "IS_STOP")
        {
            if (Floor == 1)
            {
                go_one = false;
                State = "WAITING";
                return;
            }
            for (int i = 0; i < OutList.Size(); i++)
            {
                if (OutList.GetData(i).Startfloor > Floor)
                {
                    go_one = false;
                    State = "UP";
                    return;
                }
                if (OutList.GetData(i).Startfloor < Floor)
                {
                    go_one = false;
                    State = "DOWN";
                    return;
                }
            }
        }
        if (downclock < 50)
        {
            downclock++;
            Debug.Log("下楼");
            return;
        }
        else
        {
            Floor--;
            downclock = 0;
            if (!Judgepersonout() && !Judgepersonin()) GoDown();
            else
            {
                Debug.Log("电梯准备减速");
                OpenDoor();
            }
        }
    }
    public LiftControl() { }
    ~LiftControl() { }
};

public class lift_control : MonoBehaviour
{
    public Text finaltext;
    private int _n;
    public bool nofresh = false;
    public Text numbertext;
    public Text text;
    private int[] queue = new int[9];//存储allpeople数组的索引并方便确定allpeople数组中每个实例的位置
    public GameObject up_people;
    public GameObject down_people;
    public GameObject[,] allpeople = new GameObject[9, 13];//存储可视化出来的实例
    private int id = 1;
    LiftControl mylift;
    private float timer = 0;
    private int clock = 0;
    void Start()
    {
        mylift = new LiftControl();
    }

    void FixedUpdate()
    {
        if (mylift.OutList.hasdelete == true)//hasdelete是在电梯控制类中设置的一个变量，为了方便可视化
        {
            queue[mylift.deletefloor - 1]--;
            Destroy(allpeople[mylift.deletefloor - 1, queue[mylift.deletefloor - 1]]);

            mylift.OutList.hasdelete = false;
            if (allpeople[mylift.deletefloor - 1, queue[mylift.deletefloor - 1]] != null)
            {
                Destroy(allpeople[mylift.deletefloor - 1, queue[mylift.deletefloor - 1]]);
            }
        }
        if (Input.GetKeyDown("a"))
        {
            Passenger one = new Passenger();
            one.ID = id;
            id++;
            one.Startfloor = Random.Range(1, 10);
            one.Endfloor = Random.Range(1, 10);
            if ((one.Endfloor - one.Startfloor) > 0)
            {
                allpeople[one.Startfloor - 1, queue[one.Startfloor - 1]] = Instantiate(up_people);
            }
            else
            {
                allpeople[one.Startfloor - 1, queue[one.Startfloor - 1]] = Instantiate(down_people);
            }
            allpeople[one.Startfloor - 1, queue[one.Startfloor - 1]].transform.position = (new Vector2(-3.5f + queue[one.Startfloor - 1], one.Startfloor - 6));
            queue[one.Startfloor - 1]++;

            mylift.AddPassenger(one);
        }
        timer += Time.deltaTime;
        if (timer > 0.05)//控制动画播放速度
        {
            Debug.Log("第" + clock + "t");
            mylift.Judge_tolerant();
            Debug.Log("在" + mylift.Floor + "层");
            mylift.isnorequest();
            if (mylift.State == "UP")
            {
                gameObject.transform.position += new Vector3(0, 0.02f, 0);
            }
            if (mylift.State == "DOWN")
            {
                gameObject.transform.position += new Vector3(0, -0.02f, 0);
            }
            if (mylift.State == "IS_STOP" && mylift.go_one == true)
            {
                gameObject.transform.position += new Vector3(0, -0.02f, 0);
                text.text = "DOWN";
                nofresh = true;
            }
            clock++;
            timer = 0;
        }
        if (mylift.go_one == false)
        {
            string _str = mylift.State;
            text.text = _str;
        }
        _n = mylift.InList.Size();
        numbertext.text = "number:" + _n.ToString();
        string _s = "";
        for (int i = 0; i < mylift.InList.Size(); i++)
        {
            _s += "电梯内第" + mylift.InList.GetData(i).ID + "号乘客的目的地为：" + mylift.InList.GetData(i).Endfloor.ToString() + "层        ";
        }
        finaltext.text = _s;
    }

}