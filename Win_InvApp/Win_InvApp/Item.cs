﻿using System;
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
                        return Name;
                        break;
                    case 2:
                        return Type;
                        break;
                    case 3:
                        return Added.ToString("MMMM-dd-yyyy H:mm:ss0");
                        break;
                    default:
                        return Name;
                        break;
                }
            }
        }
        public string GetCSV()
        {
            return ID + ',' + Name + ',' + Type + ',' + Added.ToString("MMMM-dd-yyyy H:mm:ss0");
        }

    }
}
