using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GridObject[] _templates;
    [SerializeField] private PlayerMovement _player;

    [SerializeField] private float _viewRadius;
    [SerializeField] private float _cellSize;

    private HashSet<Vector2Int> _collisionMatrix = new HashSet<Vector2Int>();

    private void Update()
    {
        FillRadius(_player.transform.position, _viewRadius);
    }

    private void FillRadius(Vector3 center, float viewRadius)
    {
        var cellCountOnAxis = (int)(viewRadius / _cellSize);
        var fillAreaCenter = WorldToGridPosition(center);

        for(var i = -cellCountOnAxis; i < cellCountOnAxis; i++)
        {
            TryCreateOnLayer(GridLayer.Ground, fillAreaCenter + new Vector2Int(i, 0));
            TryCreateOnLayer(GridLayer.OnGround, fillAreaCenter + new Vector2Int(i, 0));
        }
    }

    private void TryCreateOnLayer(GridLayer layer, Vector2Int gridPosition)
    {
        gridPosition.y = (int)layer;

        if (_collisionMatrix.Contains(gridPosition))
            return;
        else
            _collisionMatrix.Add(gridPosition);

        var template = GetRandomTemplate(layer);

        if (template == null)
            return;

        var position = GridToWorldPosition(gridPosition);

        Instantiate(template, position, Quaternion.identity, transform);
    }

    private GridObject GetRandomTemplate(GridLayer layer)
    {
        var variants = _templates.Where(template => template.Layer == layer);

        foreach(var template in variants)
        {
            if(template.Chance > Random.Range(0, 100))
                return template;
        }

        return null;
    }

    private Vector2 GridToWorldPosition(Vector2Int gridPosition)
    {
        return new Vector2(gridPosition.x * _cellSize, gridPosition.y * _cellSize);
    }

    private Vector2Int WorldToGridPosition(Vector2 worldPosition)
    {
        return new Vector2Int((int)(worldPosition.x / _cellSize), (int)(worldPosition.y / _cellSize));
    }
}
