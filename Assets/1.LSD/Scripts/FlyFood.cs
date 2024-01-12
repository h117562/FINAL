using UnityEngine;

public class FlyFood : MonoBehaviour
{
    private float xValue;
    private Rigidbody rb;
    [SerializeField] private int power;
    [SerializeField] private int jumpPower;
    private Transform trn;

    void Awake()
    {
        trn = transform.parent.transform.parent;
        xValue = transform.position.x; // ó�� ������ ��ġ x �� �޾ƿ���
        rb = GetComponent<Rigidbody>(); // AddForce, AddTorque �Լ��� ���� rb
    }
    void Start()
    {
        FlyForce(); // �ѹ��� ����
        Invoke("DestroyFood", 2.5f);
    }
    void FlyForce()
    {
        // powerRnd = power�� -2 ~ +2 ������ ����
        int powerRnd = Random.Range(power - 2, power + 2);

        // jumpPowerRnd = jumpPower�� -2 ~ +2 ������ ����
        int jumpPowerRnd = Random.Range(jumpPower - 2, jumpPower + 2);

        if (xValue > trn.position.x) // xValue ���� 0���� Ŭ ��� �����ʿ��� �������� �߻�
        {
            rb.AddForce(-powerRnd, jumpPowerRnd, 0, ForceMode.Impulse);
            rb.AddTorque(RotationPowerRnd(), RotationPowerRnd(), RotationPowerRnd());
        }
        
        else if (xValue < trn.position.x) // xValue ���� 0���� ���� ��� ���ʿ��� ���������� �߻�
        {
            rb.AddForce(powerRnd, jumpPowerRnd, 0, ForceMode.Impulse);
            rb.AddTorque(RotationPowerRnd(), RotationPowerRnd(), RotationPowerRnd());
        }
    }

    int RotationPowerRnd() // Food -1000���� 1000���� ȸ���� ����
    {
        int rotationPowerRnd = Random.Range(-1000, 1001);
        return rotationPowerRnd;
    }

    // Invoke("DestroyFood", 2.5f); �Լ��� �ʿ��� �Լ�, 2.5�� ���� ������Ʈ ����
    void DestroyFood()
    {
        Destroy(gameObject);
    }
}
