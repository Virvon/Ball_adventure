using UnityEngine;

class GridObject : MonoBehaviour
{
    [SerializeField] private GridLayer layer;
    [SerializeField] private int _chance;

    public GridLayer Layer => layer;
    public int Chance => _chance;

    private void OnValidate()
    {
        _chance = Mathf.Clamp(_chance, 0, 100);
    }
}
