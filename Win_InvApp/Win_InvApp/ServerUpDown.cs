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
    }


}
