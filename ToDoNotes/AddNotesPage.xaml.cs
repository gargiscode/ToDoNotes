using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoNotes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNotesPage : ContentPage
    {
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"notes.txt");
        public AddNotesPage()
        {
            InitializeComponent();
            if (File.Exists(fileName))
            {
                editor.Text = File.ReadAllText(fileName);
            }
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(fileName, editor.Text);
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            editor.Text = string.Empty;
        }
    }
}