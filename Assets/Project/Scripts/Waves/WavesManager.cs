using UnityEngine;
using UnityEngine.UI;

public class WavesManager : MonoBehaviour
{
    [Header("Waves attrb")]
    public float m_TimeBetweenWaves = 2.0F;
    public uint m_NumberOfWavesPerLevel = 3;

    private float m_CurrentTime = 0.0F;
    private uint m_CurrentWave = 0;
    private bool m_LoopRunning = true;

    [Header("Enemies stats")]
    public GameObject enemyPrefab;
    public uint m_enemiesMaxHP = 10;
    public float m_enemiesSpeed = 5.0F;
    public uint m_enemiesNumber = 3;


    [Header("UI")]
    public Canvas powerUpsCanvas = null;
    public Button[] powerUpButtons = null;

    private void Start()
    {
        if (powerUpsCanvas)
        {
            powerUpsCanvas.enabled = false;
        }
        if (powerUpButtons != null && powerUpButtons.Length > 0)
        {
            foreach (var powerupButton in powerUpButtons)
            {
                powerupButton.onClick.AddListener(PowerUpButtonListener);
            }
        }
        else
        {
            Debug.LogError("Waves manager powerUp buttons list is empty");
        }
        if (!enemyPrefab || !enemyPrefab.GetComponent<Enemy>())
        {
            Debug.LogError("Enemy prefab null or enemyComponent not found in prefab");
        }
        InstantiateWave();
    }
    private void Update()
    {
        if (m_LoopRunning)
        {
            m_CurrentTime += Time.deltaTime;

            if (m_CurrentTime >= m_TimeBetweenWaves)
            {
                Debug.LogFormat("I've passed wave number {0}", m_CurrentWave);
                m_CurrentWave++;
                if (m_CurrentWave % m_NumberOfWavesPerLevel == 0)
                {
                    Debug.LogFormat("I've reached level {0}", m_CurrentWave / m_NumberOfWavesPerLevel);
                    LevelUp();
                }
                else
                {
                    //TODO: Increase wave enemies stats either speed or hp (with some algorithm too)
                    m_enemiesMaxHP += 15;
                    m_enemiesSpeed += 1.0F;

                    InstantiateWave();
                }
                m_CurrentTime = 0;

            }
        }
    }

    private void LevelUp()
    {
        m_LoopRunning = false;
        if (powerUpsCanvas && !powerUpsCanvas.enabled)
        {
            powerUpsCanvas.enabled = true;
        }
        else
        {
            Debug.LogError("Trying to enable canvas but reference is null!!");
        }

        // TODO: Increase enemies number with some algo
        m_enemiesNumber += 2;
    }

    private void PowerUpButtonListener()
    {
        //TODO: Add powerup to player
        if (powerUpsCanvas && powerUpsCanvas.enabled)
        {
            powerUpsCanvas.enabled = false;
        }
        m_CurrentTime = 0;
        m_LoopRunning = true;
        InstantiateWave();
    }

    private void InstantiateWave()
    {
        Debug.LogFormat("Instantiating enemies for wave {0}", m_CurrentWave);
        for (var i = 0U; i < m_enemiesNumber; i++)
        {
            var enemyGO = GameObject.Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            if (enemyGO.TryGetComponent<Enemy>(out Enemy enemyComponent))
            {
                enemyComponent.m_MaxHP = m_enemiesMaxHP;
                enemyComponent.m_Speed = m_enemiesSpeed;
            }
            else{
                Debug.LogError("Enemy component not found while instantiating waves");
            }
        }
    }


}
