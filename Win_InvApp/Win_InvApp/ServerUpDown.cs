using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections;

namespace Win_InvApp
{
    static public class ServerUpDown
    {
        public static CloudUser cUser;
        static public async void Save(Dictionary<String, Item> items)
        {
            CloudApp.Init("qpnyskfsswrd", "bce300d3-caed-4d6a-be3b-b1ba3d26ce03");
            foreach (KeyValuePair<String, Item> pair in items)
            {
                if (pair.Value.OnServer == false)
                {
                    CloudObject obj = new CloudObject("Inventory");
                    obj.ID = pair.Key;
                    obj.Set("Name", pair.Value.Name);
                    obj.Set("Type", pair.Value.Type);
                    obj.Set("Quantity", pair.Value.Quantity);
                    obj.Set("User", pair.Value.User);
                    CloudObject savedObj = await obj.SaveAsync();
                    pair.Value.OnServer = true;
                }
            }
        }

        static public void Load(out ArrayList list)
        {
            Debug.WriteLine("Fetching from server...");
            CloudApp.Init("qpnyskfsswrd", "bce300d3-caed-4d6a-be3b-b1ba3d26ce03");
            CloudQuery query = new CloudQuery("Inventory");
            var list1 = query.FindAsync();
            list = list1.Result;
        }

        static public async void Remove(List<string> items)
        {
            CloudQuery query = new CloudQuery("Inventory");
            foreach(string s in items)
            {
                var obj = await query.GetAsync<CloudObject>(s);
                await obj.DeleteAsync();
            }
        }

        static public async void LogIn(String uName, String uPas)
        {
            CloudApp.Init("qpnyskfsswrd", "bce300d3-caed-4d6a-be3b-b1ba3d26ce03");
            var u2 = new CloudUser();
            u2.Set("username", uName);
            u2.Set("password", uPas);
            Debug.WriteLine("Starting login");
            var signed_in = await CloudUser.Current.LoginAsync();
            Debug.WriteLine("Login complete");
        }

        static public void SignUp(String uName, String uPas, String uEmail, out CloudUser retUser)
        {
            CloudApp.Init("qpnyskfsswrd", "bce300d3-caed-4d6a-be3b-b1ba3d26ce03");
            var u2 = new CloudUser();
            u2.Username = uName;
            u2.Password = uPas;
            u2.Email = uEmail;

            try
            {
                var resUser = u2.SignupAsync();
                retUser = resUser.Result;
            }
            catch (Exception)
            {
                CloudUser eu = new CloudUser();
                eu.Username = "Exception";
                retUser = eu;
            }
        }
    }


}
