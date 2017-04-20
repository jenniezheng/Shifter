using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Shifter.AllScenes;

namespace Shifter.OpenRoom
{
    public class RoomManager : Photon.PunBehaviour
    {
        public GameObject mouseQuad;
        public GameObject roomOptions;
        public GameObject roomName;
        public Text playerNumber;
        public Text playerNamesDisplay;
        public Text chatText;
        ExitGames.Client.Photon.Hashtable customPlayerProperties = new ExitGames.Client.Photon.Hashtable();

        #region UI messages
        void Start()
        {

            customPlayerProperties.Add("S1", 'C');
            customPlayerProperties.Add("S2", 'S');
            PhotonNetwork.player.SetCustomProperties(customPlayerProperties);
            PhotonNetwork.playerName = PlayerPrefsManager.getPlayerName();
            Debug.Log("Starting as master client? " + PhotonNetwork.isMasterClient);
            roomName.GetComponent<Text>().text = PhotonNetwork.room.Name;
            giveControl();
            Invoke("UpdatePlayerList",1f);
        }

        #endregion

        #region UI messages
        public void ready()
        {
            PhotonNetwork.LoadLevel(3);
        }

        public void changeSkill(int skills)
        {
            switch (skills)
            {
                case 1:break;
                case 2: break;
                case 3: break;
                case 4: break;
                case 5: break;
                case 6: break;
                default:  Debug.Log(skills+" out of bounds!"); break;
            }
        }

        public void leave()
        {
            
            PhotonNetwork.LeaveRoom();
        }
        #endregion



        #region  Photon.PunBehaviour CallBacks
        public override void OnLeftRoom()
        {
            Cursor.visible = true;
            LevelManager.loadLevelStatic(1);
        }

        public override void OnDisconnectedFromPhoton()
        {
            Cursor.visible = true;
            LevelManager.loadLevelStatic(1);
        }

        public override void OnMasterClientSwitched(PhotonPlayer newMasterClient)
        {
            CanvasGroup optionsGroup = roomOptions.GetComponent<CanvasGroup>();
            giveControl();
        }
        #endregion


        #region helper functions
        void giveControl()
        {
            CanvasGroup optionsGroup = roomOptions.GetComponent<CanvasGroup>();
            if (optionsGroup == null) Debug.LogError("Missing canvas group!");
            MouseWithMouse mouseScript = mouseQuad.GetComponent<MouseWithMouse>();
            if (mouseScript == null) Debug.LogError("Missing mouse script!");
            if (PhotonNetwork.isMasterClient)
            {
                mouseScript.enabled = true;
                optionsGroup.interactable = true;
                Cursor.visible = false;
            }
            else
            {
                mouseScript.enabled = false;
                optionsGroup.interactable = false;
                Cursor.visible = true;
            }
        }

        void UpdatePlayerList()
        {
            Debug.Log("Updating players!");
            playerNumber.text = PhotonNetwork.room.PlayerCount + "";
            string names = "";
            PhotonPlayer[] players = PhotonNetwork.playerList;
            foreach (PhotonPlayer player in players)
            {
                Debug.Log("Player name is " + player.NickName);
                names += player.NickName; 
                if (player == PhotonNetwork.player) names += " (self)";
                if (player == PhotonNetwork.masterClient) names += " (main)";
                names += "\n";
            }
            playerNamesDisplay.text = names;
        }
        #endregion 
    };
}
