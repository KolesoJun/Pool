using UnityEngine;


public class BrickColorManager : MonoBehaviour
{
    public Color32 ChangeColor()
    {
        float colorMax = 255;
        return new Color32((byte)Random.Range(0, colorMax), (byte)Random.Range(0, colorMax), (byte)Random.Range(0, colorMax), (byte)colorMax);
    }
}
