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
        List<Item> item;

        public FileStream(List<Item> _items)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                item[i] = _items[i];
            }
        }

        public void Save()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|CSV Files|*.csv";
            dlg.FilterIndex = 2; dlg.DefaultExt = "csv";

            if (DialogResult.OK == dlg.ShowDialog())
            {
                output = new StreamWriter(dlg.FileName);
                for (int i = 0; i < item.Count; i++)
                {
                    string txtFile = String.Empty;
                    txtFile = item[i].GetCSV();
                    output.Write(txtFile);
                }
                output.Close();
            }
        }

        public List<Item> Open()
        {
            List<Item> rtnList;
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
                    for (int i = 0; i < splitter.Length; i++)
                    {
                        rtnList[i].ID = splitter[]
                    }
                    return rtnList;
                }
                input.Close();
            }
        }
    }
}
