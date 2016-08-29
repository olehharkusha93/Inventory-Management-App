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
        public static string Table { get; set; } = "Inventory";
        public static List<string> Columns { get; set; }

        /// <summary>
        /// Sets the Columns property with available columns in current table
        /// </summary>
        public static void GetColumns()
        {
            CloudApp.Init("qpnyskfsswrd", "bce300d3-caed-4d6a-be3b-b1ba3d26ce03");
            CloudTable t = new CloudTable(Table);
            foreach (var c in t.Columns)
            {
                Columns.Add(c.Name);
            }
        }
        static public async void Save(Dictionary<String, Item> items)
        {
            CloudApp.Init("qpnyskfsswrd", "bce300d3-caed-4d6a-be3b-b1ba3d26ce03");
            foreach (KeyValuePair<String, Item> pair in items)
            {
                if (pair.Value.OnServer == false)
                {
                    CloudObject obj = new CloudObject(Table);
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

        static public Task<ArrayList> Load()
        {
            Debug.WriteLine("Fetching from server...");
            CloudApp.Init("qpnyskfsswrd", "bce300d3-caed-4d6a-be3b-b1ba3d26ce03");
            CloudQuery query = new CloudQuery(Table);
            return query.FindAsync();
        }

        static public async void Remove(List<string> items)
        {
            CloudQuery query = new CloudQuery(Table);
            foreach(string s in items)
            {
                var obj = await query.GetAsync<CloudObject>(s);
                await obj.DeleteAsync();
            }
        }

        static public Task<CloudUser> LogIn(String uName, String uPas)
        {
            CloudApp.Init("qpnyskfsswrd", "bce300d3-caed-4d6a-be3b-b1ba3d26ce03");
            var u2 = new CloudUser();
            u2.Set("username", uName);
            u2.Set("password", uPas);
            Debug.WriteLine("Starting login");
            return  u2.LoginAsync();
        }

        static public Task<CloudUser> SignUp(String uName, String uPas, String uEmail)
        {
            CloudApp.Init("qpnyskfsswrd", "bce300d3-caed-4d6a-be3b-b1ba3d26ce03");
            var u2 = new CloudUser();
            u2.Username = uName;
            u2.Password = uPas;
            u2.Email = uEmail;
            return u2.SignupAsync();
        }
    }


}
