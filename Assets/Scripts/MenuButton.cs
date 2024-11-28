using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public RawImage rimg;
    public CanvasScaler cs;
    public Button bt;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.x >= bt.transform.position.x - 100 &&
            Input.mousePosition.x <= bt.transform.position.x + 100 &&
            Input.mousePosition.y >= bt.transform.position.y - 20 &&
            Input.mousePosition.y <= bt.transform.position.y + 20
            )
        {
            if (Input.GetMouseButton(0))
            {
                rimg.color = new Color32(255, 255, 255, 255);
            }
            else
            {
                rimg.color = new Color32(240, 240, 240, 255);
            }
            if (flag == false)
            {
                flag = true;
            }
        }
        else
        {
            flag = false;
            rimg.color = new Color32(200, 200, 200, 255);
        }
    }
}
