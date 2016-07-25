using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBarcode.Barcode.BarcodeScanner;
using System.Windows.Forms;
using System.IO;


namespace Win_InvApp
{
    class Barcode
    {
        public Barcode()
        {

        }
   
        public String[] Scan()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|PNG Files|*.png";
            dlg.FilterIndex = 2;
            string[] barcodes = {"DEFAULT"};
            if (DialogResult.OK == dlg.ShowDialog())
            {
                barcodes = BarcodeScanner.Scan(dlg.FileName, BarcodeType.Code128);
                return barcodes;
            }
            else
            {
                return barcodes;
            }
        }

    }
}
