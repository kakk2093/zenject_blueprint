using UnityEngine;
using UnityEngine.UI;

public class FlyingText : MonoBehaviour
{
    [SerializeField] private Text _flyText;

    private float _value;

    public float Value { get => _value; set => _value = value; }



    private void Start()
    {
        ViewValue(_value);
    }

    private void ViewValue(float value)
    {
        var number = value;

        if(number > 0)
        {
            _flyText.text = "+ " + number.ToString();
            _flyText.color = Color.green;
        }
        if(number < 0)
        {
            _flyText.text =  number.ToString();
            _flyText.color = Color.red;
        }

       
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
