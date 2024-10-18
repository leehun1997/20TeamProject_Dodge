using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmantMaker : MonoBehaviour
{
    [Header("������ �´� ����Prefab����")]
    [SerializeField] List<GameObject> FragmantPrefab;

    private float RandNum;
    private Vector2 makePosition;
    //private Rigidbody2D objRigid2D;

    private void Start()
    {
        makePosition = new Vector2 (transform.position.x, transform.position.y);
    }

    //Enemy_0_Death�ִϸ�����>Death�ִϸ��̼�>Add Animation Event���� ȣ���
    public void InstantiateFragmant()
    {
        foreach (var obj in FragmantPrefab)
        {
            RandNum = Random.Range(0f, 360f);
            Instantiate(obj, makePosition, Quaternion.Euler(0, 0, RandNum));

            //������ ��ũ��Ʈ�� ó�� ���⼭�� �۵���������
            //objRigid2D = obj.GetComponent<Rigidbody2D>();
            //objRigid2D.AddForce(transform.TransformDirection(Vector2.right) / 2, ForceMode2D.Impulse);
        }
        Destroy(gameObject);
    }
}
