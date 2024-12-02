using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    public Transform Player;  // Referência ao jogador ou câmera VR

    private void Start()
    {
        Debug.Log("SceneInitializer Start");
        if (SceneTransitionManager.Instance != null)
        {
            string spawnSuffix = SceneTransitionManager.Instance.GetSpawnPointSuffix();

            if (!string.IsNullOrEmpty(spawnSuffix))
            {
                // Procura o GameObject com o nome configurado no spawnSuffix
                GameObject spawnPoint = GameObject.Find(spawnSuffix);
                if (spawnPoint != null && Player != null)
                {
                    // Posiciona o jogador no ponto de spawn
                    Player.position = spawnPoint.transform.position;
                    Player.rotation = spawnPoint.transform.rotation; // Ajusta também a rotação
                    Debug.Log($"Jogador posicionado no ponto de spawn '{spawnSuffix}'");
                }
                else
                {
                    Debug.LogWarning($"Ponto de spawn '{spawnSuffix}' não encontrado na cena.");
                }
            }
        }
    }
}