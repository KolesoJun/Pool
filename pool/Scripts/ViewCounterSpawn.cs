using UnityEngine;
using TMPro;

public class ViewCounterSpawn : MonoBehaviour
{
    [SerializeField] private Pooler _pool;
    [SerializeField] private TMP_Text _countCreate;
    [SerializeField] private TMP_Text _countActive;
    [SerializeField] private TMP_Text _countGeneral;

    private void OnEnable()
    {
        _pool.UpdatedInfo += UpdateInfo;
    }

    private void OnDisable()
    {
        _pool.UpdatedInfo -= UpdateInfo;
    }

    private void UpdateInfo()
    {
        _countActive.text = _pool.CountActive.ToString();
        _countCreate.text = _pool.CountCreate.ToString();
        _countGeneral.text = _pool.CountGeneral.ToString();
    }
}
