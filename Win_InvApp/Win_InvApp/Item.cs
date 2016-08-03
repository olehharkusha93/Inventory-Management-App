using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Win_InvApp
{
    public class Item
    {
        public String Name { get; set; }
        public String Type { get; set; }
        public UInt32 ID { get; set; }
        public DateTime Added { get; set; }
        public String CloudID { get; set; }
        public bool OnServer { get; set; }
        public uint Quantity { get; set; }

        public Item()
        {
            Added = DateTime.Now;
        }
        public Item(String _name)
        {
            Name = _name;
            Added = DateTime.Now;
        }
        public Item(String _name, String _type)
        {
            Name = _name;
            Type = _type;
            Added = DateTime.Now;
        }
        public Item(String _name, String _type, UInt32 _id)
        {
            Name = _name;
            Type = _type;
            ID = _id;
            Added = DateTime.Now;
        }

#pragma warning disable 0162
        public String this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return ID.ToString();
                        break;
                    case 1:
                        return Quantity.ToString();
                        break;
                    case 2:
                        return Name;
                        break;
                    case 3:
                        return Type;
                        break;
                    case 4:
                        return Added.ToString("MM/dd/yyyy H:mm");
                        break;
                    case 5:
                        return CloudID;
                        break;
                    default:
                        return Name;
                        break;
                }
            }
        }
#pragma warning restore 0162

        public string GetCSV()
        {
            return ID.ToString() + ',' + Name + ',' + Type + ',' + Added.ToString("MM/dd/yyyy H:mm") + ',' + Quantity + ',' + CloudID + ',';
        }
    }
}
