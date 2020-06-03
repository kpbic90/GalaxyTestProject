using System.Collections.Generic;
using Gameplay.Spawners;
using UnityEngine;

namespace Gameplay.Helpers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Transform holder;

        [SerializeField] private Transform holderUI;

        [SerializeField] private List<GameObject> prefabEnemyShipList;

        [SerializeField] private GameObject prefabPlayerShip;

        [SerializeField] private GameObject prefabSpawner;

        [SerializeField] private GameObject prefabWindowEndGame;

        [SerializeField] private GameObject windowHelp;

        public static GameController Instance { get; protected set; }

        public bool IsGamePaused => windowHelp.activeSelf;

        public void Start()
        {
            Instance = this;
        }

        public void ShowEndGameWindow()
        {
            Instantiate(prefabWindowEndGame, holderUI);
        }

        public void PlayAgain()
        {
            GameScoreKeeper.Score = 0;

            while (holder.transform.childCount > 0) DestroyImmediate(holder.transform.GetChild(0).gameObject);
            Instantiate(prefabPlayerShip, holder);

            for (var i = -1; i < 2; i++)
            {
                var spawner = Instantiate(prefabSpawner, new Vector3(i * 6, 20), new Quaternion(0, 0, 180, 0), holder);
                var spawnerScript = spawner.GetComponent<Spawner>();
                spawnerScript._Object = prefabEnemyShipList[Random.Range(0, prefabEnemyShipList.Count)];
                spawnerScript._Parent = holder;
            }

            while (holderUI.transform.childCount > 0) DestroyImmediate(holderUI.transform.GetChild(0).gameObject);
        }

        public void PopWindowHelp()
        {
            windowHelp.SetActive(!windowHelp.activeSelf);
        }
    }
}