using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoNotes.Models;

namespace ToDoNotes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNotesPage : ContentPage
    {
        //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"notes.txt");
        public AddNotesPage()
        {
            InitializeComponent();
            //if (File.Exists(fileName))
            //{
            //    editor.Text = File.ReadAllText(fileName);
            //}
        }

        protected override void OnAppearing()
        {
            var note = (Note)BindingContext;
            if(!string.IsNullOrEmpty(note.FileName))
            {
                editor.Text = File.ReadAllText(note.FileName);
            }

        }
        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (string.IsNullOrEmpty(note.FileName))
            {
                note.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    $"{Path.GetRandomFileName()}.notes.txt");
            }
            File.WriteAllText(note.FileName, editor.Text);
            await Navigation.PopModalAsync();
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (File.Exists(note.FileName))
            {
                File.Delete(note.FileName);
            }
            editor.Text = string.Empty;
            await Navigation.PopModalAsync();

        }
    }
}