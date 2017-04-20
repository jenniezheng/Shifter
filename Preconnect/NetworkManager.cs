using UnityEngine.UI;
using UnityEngine;

namespace Shifter.Preconnect
{

    public class NetworkManager : Photon.PunBehaviour {
        [Tooltip("The Ui Text to inform the user about the connection progress")]
        public Text feedbackText;
        [Tooltip("The maximum number of players per room")]
        public byte maxPlayersPerRoom = 10;
        public GameObject connectPanel;
        string roomName;
        string gameVersion = "001";
        bool isConnecting;

        #region Unity messages
        void Start()
        {
            isConnecting = false;
            PhotonNetwork.automaticallySyncScene = true;
            PhotonNetwork.autoJoinLobby = false;
            PhotonNetwork.logLevel = PhotonLogLevel.ErrorsOnly;
        }
	    
        #endregion

        #region UI messages
        public void changeRoomName(string room_name)
        {
            roomName = room_name;
        }

        public void connect()
        {
            Debug.Log("Connect called");
            if (PhotonNetwork.inRoom) Debug.Log("Error! Still in Room,slow down.");
            connectPanel.SetActive(false);
            isConnecting = true;
            if (PhotonNetwork.connected)
            {
                feedbackText.text = "Joining or creating room "+roomName;
                Debug.Log("Joining or creating room.");
                if (roomName == "") PhotonNetwork.JoinRandomRoom();
                else PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions() { MaxPlayers = this.maxPlayersPerRoom }, null);
            }
            else
            {
                Debug.Log("Connecting...");
                feedbackText.text = "Connecting to master";
                PhotonNetwork.ConnectUsingSettings(gameVersion);
            }
        }
        #endregion

        #region  Photon.PunBehaviour CallBacks

        public override void OnDisconnectedFromPhoton()
        {
            feedbackText.text = "Disconnected...";
            Debug.Log("Disconnected");
            isConnecting = false;
            connectPanel.SetActive(true);
        }
     
        public override void OnConnectedToMaster()
        {
            Debug.Log("Region:" + PhotonNetwork.networkingPeer.CloudRegion);
            if (isConnecting)
            {
                
                Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and may join room " +roomName);
                if (roomName == "")
                {
                    feedbackText.text = "Connected to master: Next -> try to Join Random Room";
                    PhotonNetwork.JoinRandomRoom();
                }
                else
                {
                    feedbackText.text = "Connected to master: Next -> try to Join or Create Room " + roomName;
                    PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions() { MaxPlayers = this.maxPlayersPerRoom }, null);
                }
            }

        }

        public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
        {
            feedbackText.text = "Join random room failed: Next -> try to Create Room";
            PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = this.maxPlayersPerRoom }, null);
        }


        public override void OnJoinedRoom()
        {
            feedbackText.text = "Joined room...";
            if (PhotonNetwork.room.PlayerCount == 1)
            {
                Debug.Log("First player loads room");
                PhotonNetwork.LoadLevel(2);

            }
        }
        #endregion
    };

}
