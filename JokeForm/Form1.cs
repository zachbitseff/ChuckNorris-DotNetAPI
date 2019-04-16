using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChuckNorrisAPI;

namespace JokeForm
{
    public partial class JokeForm : Form
    {
        public JokeForm()
        {
            InitializeComponent();
        }

        private async void GetJokeBtn_ClickAsync(object sender, EventArgs e)
        {
            Joke j = await ChuckNorrisClient.GetRandomJoke();

            /*
            string sel = categoriesComboBox.SelectedItem.ToString();
            //MessageBox.Show(sel, "test");
            string cat = j.Categories.ToString();

            if ( !(cat == sel) ) {

                while (!(cat == sel))
                {
                    j = await ChuckNorrisClient.GetRandomJoke();
                    cat = j.Categories.ToString();
                }

            }
            */

            String text = j.Id + " : " + j.JokeText;
            MessageBox.Show(text, "Joke Display");

        }

        private async void JokeForm_LoadAsync(object sender, EventArgs e)
        {
            IEnumerable<string> categories = await ChuckNorrisClient.GetCategories();
            categoriesComboBox.DataSource = categories;
        }
    }
}
