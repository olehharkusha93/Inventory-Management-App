using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Win_InvApp
{
    class FileStream
    {
        StreamWriter output;
        StreamReader input;
        List<Item> items;

        public FileStream()
        {
        }

        public void Save(List<Item> _items)
        {
            //Can delete this after testing and use _items wherever items appear throughout the code
            items = new List<Item>(_items);

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|CSV Files|*.csv";
            dlg.FilterIndex = 2; dlg.DefaultExt = "csv";

            if (DialogResult.OK == dlg.ShowDialog())
            {
                output = new StreamWriter(dlg.FileName);
                for (int i = 0; i < items.Count; i++)
                {
                    string txtFile = String.Empty;
                    txtFile = items[i].GetCSV();
                    output.Write(txtFile);
                }
                output.Close();
            }
        }

        public Dictionary<string, Item> Open()
        {
            Dictionary<string, Item> rtnList = new Dictionary<string, Item>();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|CSV Files|*.csv";
            dlg.FilterIndex = 2;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                input = new StreamReader(dlg.FileName);
                while (!input.EndOfStream)
                {
                    string txtfile = input.ReadLine();
                    string[] splitter = txtfile.Split(',');

                    for (int i = 0; i < splitter.Length - 1;)
                    {
                        Item tmp = new Item();
                        tmp.ID = Convert.ToUInt16(splitter[i++]);
                        tmp.Name = splitter[i++];
                        tmp.Type = splitter[i++];
                        tmp.Added = DateTime.Parse(splitter[i++]);

                        tmp.Quantity = Convert.ToUInt32(splitter[i++]);
                        tmp.CloudID = splitter[i++];
                        tmp.User = splitter[i++];
                        rtnList.Add(tmp.CloudID, tmp);
                    }
                }
                input.Close();
                return rtnList;
            }

            else
            {
                MessageBox.Show("File did not Open",
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return rtnList;

            }
        }
    }
}
