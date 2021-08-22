using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public float distance;
    public float atkDistance;
    public LayerMask isLayer;
    public float speed;

    bool isLeft = true;

    public int hp;
    public int currentHp;

    public GameObject healthBarBackground;
    public Image healthBarFilled;

    //AI
    public AIPath aiPath;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = hp;
        healthBarFilled.fillAmount = 1f;

        healthBarFilled.fillAmount = (float)currentHp / hp;
        healthBarBackground.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "endpoint")
        {
            if(isLeft)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isLeft = true;
            }
        }
    }

    public int Hp = 3;
        public void TakeDamage(int damage)
    {
        Hp = Hp - damage;
    }

    private void FixedUpdate()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        if(raycast.collider != null)
        {
            /*if(Vector2.Distance(transform.position, raycast.collider.transform.position) < atkDistance)
            {

            }
            transform.position = Vector3.MoveTowards(transform.position, raycast.collider.transform.position, Time.deltaTime * speed);*/
        }
    }
}
