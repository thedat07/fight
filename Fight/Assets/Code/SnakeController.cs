using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SnakeController : MonoBehaviour
{
    public bool IsDead;
    public Animator animator;
    public Vector3 DesiredDirection;
    public Vector3 LastNonZeroDirection;
    public VariableJoystick m_VariableJoystick;
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float BodySpeed = 5;
    public int Gap = 10;


    // Lists
    public List<GameObject> BodyParts = new List<GameObject>();
    public List<Vector3> PositionsHistory = new List<Vector3>();

    //UI
    public UIEnd UIDead;
    public UIGamePlay UIGamePlay;
    // Start is called before the first frame update
    void Start()
    {
        // GrowSnake();
    }

    // Update is called once per frame
    void Update()
    {

        if (IsDead ) return;
        // Move forward
        DesiredDirection = new Vector3(m_VariableJoystick.Horizontal, 0, m_VariableJoystick.Vertical);
        if (DesiredDirection.sqrMagnitude > 0)
        {
            LastNonZeroDirection = DesiredDirection;
        }

        transform.position += LastNonZeroDirection * MoveSpeed * Time.deltaTime;

        // Steer
        float steerDirection = m_VariableJoystick.Horizontal; // Returns value -1, 0, or 1
        transform.LookAt(LastNonZeroDirection + transform.position, Vector3.up);

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
        GameObject body =_object;
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



    private void OnCollisionEnter(Collision other) {
                if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.GetComponent<ItemGame>().Pick();
            GrowSnake(other.transform.position,other.gameObject);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            UIDead.gameObject.SetActive(true);
            UIDead.snakeController = this;
            UIDead.Star(0);
            foreach (var i in BodyParts)
            {
                i.GetComponent<ItemGame>().Clear();
            }
            BodyParts.Clear();
            gameObject.SetActive(false);
        }
    }

}
