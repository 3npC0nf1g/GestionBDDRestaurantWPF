using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BibliWPF
{
    internal class Statics
    {
        public static void TryCatch(Action action, string titreMessageBox)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, titreMessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
