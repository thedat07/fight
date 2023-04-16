using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using Lean.Pool;

public class SnakeAI : MonoBehaviour, IPoolable
{
    // Start is called before the first frame update
    public Animator animator;
    public float BodySpeed = 5;
    public int Gap = 10;



    // Lists
    public List<GameObject> BodyParts = new List<GameObject>();
    public List<Vector3> PositionsHistory = new List<Vector3>();

    private NavMeshAgent m_Enemy;
    public Transform player;
    public SpamEnemies SpamEnemies;
    Vector3 m_Target;
    void Start()
    {
        transform.parent = null;
        m_Enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = new Collider[1];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, 15, hitColliders,LayerMask.GetMask("Item"));
        if (numColliders > 0)
        {
            m_Target = hitColliders[0].transform.position;
            m_Enemy.SetDestination(m_Target);
        }
        else
        {
            if(Vector3.Distance(m_Target,transform.position)<5)
            {
                m_Target = transform.position + Static.RandomPointInAnnulus(5, 10);
            }
        }
        m_Enemy.SetDestination(m_Target);
        // Store position history
        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);

            index++;
        }
    }
    private void GrowSnake(Vector3 _point, GameObject _object)
    {
        // Instantiate body instance and
        // add it to the list
        transform.DORewind();
        transform.DOPunchScale(Vector3.one * 0.5f, 0.5f);
        GameObject body = _object;
        BodyParts.Add(body);
        int index = 0;
        foreach (var b in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position = point;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);
            index++;
            b.transform.DORewind();
            b.transform.DOPunchScale(Vector3.one * 0.2f, 0.5f);
        }
    }



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.GetComponent<ItemGame>().Pick(false);
            GrowSnake(other.transform.position, other.gameObject);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            Lean.Pool.LeanPool.Despawn(gameObject);
        }
    }

   public  void OnSpawn()
    {

    }

    /// <summary>Called when this poolable object is despawned.</summary>
    public void OnDespawn()
    {
        SpamEnemies.SpamRevivalPoint();
        foreach (var i in BodyParts)
        {
            i.GetComponent<ItemGame>().Clear();
        }
        BodyParts.Clear();
    }
}
