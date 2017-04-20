using UnityEngine.UI;
using UnityEngine;
public class ChatManager : Photon.PunBehaviour {

    public Text chatDisplay;
    public InputField chatInput;
    
    public void Start()
    {
        chatDisplay.text = "\n\n\n\n\n\n\n";//7 rows
    }

public void onSend()
    {
        if (chatInput.text == "") return;//don't send empty message
        Debug.Log("HI");
        Debug.Log(chatInput==null);
        Debug.Log(PhotonNetwork.player.NickName);
        photonView.RPC("changeText", PhotonTargets.AllBuffered, PhotonNetwork.player.NickName+": "+chatInput.text);//send to all
        chatInput.text = ""; //reset
    }
    
    [PunRPC]
    public void changeText (string text) {
        chatDisplay.text += text+'\n';
        int cutPlace = chatDisplay.text.IndexOf('\n');
        chatDisplay.text = chatDisplay.text.Substring(cutPlace+1);
    }



}
