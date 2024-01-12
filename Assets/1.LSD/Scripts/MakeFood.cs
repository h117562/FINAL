using System.Collections;
using UnityEngine;

public class MakeFood : MonoBehaviour
{
    [SerializeField] private GameObject Banana;
    [SerializeField] private GameObject Cheese;
    [SerializeField] private GameObject Cherry;
    [SerializeField] private int repetition; // ��� �ݺ�����
    public Transform parentTrn;

    void Awake()
    {
        parentTrn = transform.parent;
    }

    void Start()
    {
        StartCoroutine(FoodMakeCoroutine()); // �ڷ�ƾ ����
    }

    IEnumerator FoodMakeCoroutine() // �ڷ�ƾ repetition �� ��ŭ �ݺ�
    {
        while (repetition != 0)
        {
            FoodContainerPosition(); // �������� �ٲ۴�.
            repetition--; // 1�� �����Ҷ����� repetition ���� -
            yield return new WaitForSeconds(.5f); // 0.5�ʿ� �ѹ���
        }
    }

    void FoodContainerPosition() // Ǫ�� �����̳� ��ġ�� ���� ����
    {
        float rndY = Random.Range(1f, -6.5f); // Y�� ��ġ�� ����� ���� ����
        int rnd = Random.Range(0, 2); // 50%�� ����� ���� ����
        Vector3 position;
        if (rnd == 0)
        {
            position = new Vector3(-6 + parentTrn.position.x, rndY + parentTrn.position.y, parentTrn.position.z); // rnd �� 0�Ͻ� �ش� ��ǥ�� �̵�
        }
        else
        {
            position = new Vector3(6 + parentTrn.position.x, rndY + parentTrn.position.y, parentTrn.position.z);// rnd �� 1�Ͻ� �ش� ��ǥ�� �̵�
        }
        MakeFoods(position); // Ǫ�带 �����.
    }

    void MakeFoods(Vector3 position) // ���� Ǫ�� ����
    {
        int rnd = Random.Range(0, 3);
        switch (rnd)
        {
            case 0:
                Instantiate(Banana, position, Quaternion.identity, transform);
                break;
            case 1:
                Instantiate(Cheese, position, Quaternion.identity, transform);
                break;
            case 2:
                Instantiate(Cherry, position, Quaternion.identity, transform);
                break;
        }
    }
}

