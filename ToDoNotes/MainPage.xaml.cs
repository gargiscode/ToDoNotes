using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoNotes.Models;
using Xamarin.Forms;

namespace ToDoNotes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //base.OnAppearing();

            var notes = new List<Note>();
            var files= Directory.EnumerateFiles(Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData), "*.notes.txt");

            foreach (var filename in files)
            {
                var note = new Note
                {
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename),
                    FileName = filename
                };
                notes.Add(note);

            }
        }

        private void NoteAddedClicked(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void OnNoteItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
