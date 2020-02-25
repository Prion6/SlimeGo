using DataSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScreen : MonoBehaviour
{
    public InputField inputName;
    public InputField inputPassword;

    private Data data;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.LoadData<Data>();
        if(data == null)
        {
            data = DataManager.NewData<Data>();
        }
    }

    public void Login()
    {
        if(data.acounts.Count == 0)
        {
            Debug.Log("No existen cuentas guardadas.");
            return;
        }

        foreach (var acount in data.acounts)
        {
            if(acount.name.Equals(inputName.text) && acount.password.Equals(inputPassword.text))
            {
                Globals.playerName = inputName.text;
                SceneManager.LoadScene("MainScreen");
            }
        }

        Debug.Log("Error en el nombre o la contraseña.");
    }

    public void SingIn()
    {
        if (inputName.text.Length < 6 || inputPassword.text.Length < 6)
        {
            Debug.Log("El Nombre y la contraseña deben tener mas de 6 digitos");
            return;
        }

        foreach (var acount in data.acounts)
        {
            if (acount.name.Equals(inputName.text))
            {
                Debug.Log("Esta cuenta ya existe.");
                return;
            }
        }

        var newAcount = new Acount(inputName.text, inputPassword.text);
        data.acounts.Add(newAcount);
        newAcount.player.slimes.Add(new DataSystem.Slime("Lava",20,20,1,"Lava"));
        DataManager.SaveData<Data>(data);
        Globals.playerName = inputName.text;
        SceneManager.LoadScene("MainScreen");
    }
}
