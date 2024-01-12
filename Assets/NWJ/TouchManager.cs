using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public static TouchManager instance;

    private bool m_dragDown;//�Ʒ��� �巡��
    private bool m_dragUp;//���� �巡��
    private bool m_dragLeft;//����
    private bool m_dragRight;//������

    private bool m_isDragging;//�հ����� ������ �ִ� ����

    private Vector2 m_position;//
    private Vector2 m_velocity;//�巡�� �ӵ�
    private Touch m_touch;

    private float m_speed = 200.0f;//���� ���� ���� �ӵ�

    
    private void Awake()
    {
        //��ġ �Ŵ��� �̱���ȭ
        instance = this;
    }

    private void Update()
    {
        UpdateInput();
    }


    //Input���� ��ġ���� �޾ƿ� �̵� ��ǥ�� ���� �ʱ�ȭ�ϴ� �Լ�
    private void UpdateInput()
    {

        if (Input.touchCount > 0)
        {
            m_touch = Input.GetTouch(0);

            if (m_touch.phase == TouchPhase.Began)//��ġ���� �� �ӵ� �ʱ�ȭ
            {
                m_velocity = Vector2.zero;
                
            }

            if (m_touch.phase == TouchPhase.Moved)//�巡�� �� �ǽð����� ��ǥ ����
            {
                m_isDragging = true;
                m_position = m_touch.position;
                m_velocity += m_touch.deltaPosition;
            }

            if (m_touch.phase == TouchPhase.Ended)//��ġ���� �� �ӵ� üũ
            {
                CheckDirection();
                m_isDragging = false;
            }
        }
    }

    //m_velocity ������ ���⿡ ���� ��� �������� �巡���Ͽ����� �ʱ�ȭ�ϴ� �Լ�
    private void CheckDirection()
    {
        if (m_velocity.x < -m_speed)
        {
            m_dragLeft = true;
        }
        else
        {
            m_dragLeft = false;
        }

        if (m_velocity.x > m_speed)
        {
            m_dragRight = true;
        }
        else
        {
            m_dragRight = false;
        }

        if (m_velocity.y < -m_speed)
        {
            m_dragDown = true;
        }
        else
        {
            m_dragDown = false;
        }

        if (m_velocity.y > m_speed)
        {
            m_dragUp = true;
        }
        else
        {
            m_dragUp = false;
        }

        Debug.LogFormat("Is Left = {0} Is Right {1} Is Up = {2} Is Down {3}", m_dragLeft, m_dragRight, m_dragUp, m_dragDown);
    }

    public Vector2 GetPosition()
    {
        return m_position;
    }

    public bool IsDragging()
    {
        return m_isDragging;
    }

    public bool IsDragLeft()
    {
        if (m_dragLeft)
        {
            m_dragLeft = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsDragRight()
    {
        if (m_dragRight)
        {
            m_dragRight = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsDragDown()
    {
        if (m_dragDown)
        {
            m_dragDown = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsDragUp()
    { 
        if(m_dragUp)
        { 
            m_dragUp = false; 
            return true;
        }
        else
        {
            return false;
        }
    }
}
