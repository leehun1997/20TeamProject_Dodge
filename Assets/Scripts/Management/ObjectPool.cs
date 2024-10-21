using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    
    //테스트용 
    public static ObjectPool instance;
    
    [System.Serializable]
    public class Pool
    {
        public string name; //�̸�
        public GameObject prefab; //������Ʈ ������
        public int size; //������ ������
    }

    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    private void Awake()
    {
        // ----- 테스트용 ----- 
        if(instance == null)
             instance = this;
        else
            Destroy(this);
        // ----- 테스트용 -----
        
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

    }
    
    //기존 Player 생성 전 부터 바로 Pools 만듦
    
    //지금 Player 생성 후 만들도록 변경 함. 
    

    public void CreatePools()
    {
        foreach(var pool in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>(); 
            for(int i = 0;  i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform); //�� ��ũ��Ʈ�� ������ �ִ� ������Ʈ �ڽ����� �־��ش�.
                obj.SetActive(false);  
                queue.Enqueue(obj);//queue�� �ִ´�
            }

            PoolDictionary.Add(pool.name, queue); //1���� ���� ������Ʈ�� Ǯ�� �־��ش� : �̸����� �ٸ���
        }
    }

    public GameObject SpawnFromPool(string name)
    {
        if (!PoolDictionary.ContainsKey(name)) //name�� �����ϴ��� Ȯ���ϰ� ������ null
        {
            Debug.Log($"{name}을 가진 오브젝트가 존재하지 않습니다. ");
            return null;
        }

        Queue<GameObject> queue = PoolDictionary[name];
        int QueueCount = queue.Count;

        // ��Ȱ��ȭ�� ������Ʈ�� ã�� ������ �ݺ�
        for (int i = 0; i < QueueCount; i++)
        {
            GameObject obj = queue.Dequeue();

            // ���� ������Ʈ�� ��Ȱ��ȭ ���¶�� ����ϰ�, �׷��� �ʴٸ� ť �ڷ� ������
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                queue.Enqueue(obj);
                return obj; // Ȱ��ȭ�� ������Ʈ�� ��ȯ
            }

            // ������Ʈ�� �̹� Ȱ��ȭ�� ��� ť �ڷ� ������
            queue.Enqueue(obj);
        }

        // ����� �� �ִ� ��Ȱ��ȭ�� ������Ʈ�� ���� ��� null�� ��ȯ
        return null;
    }
}
