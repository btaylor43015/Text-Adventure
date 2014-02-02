using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextAdventure
{
    public partial class frmNewScene : Form
    {

        public Boolean NewScene;
        public Boolean Cancel;
        public Scene LinkScene;
        public String Direction;

        private Dictionary<string, Scene> scenes;


        public frmNewScene(Scene OpeningScene)
        {
            InitializeComponent();
            scenes = new Dictionary<string, Scene>();
            LoadScenes(OpeningScene);
            
        }

        private void frmNewScene_Load(object sender, EventArgs e)
        {
            cboDirection.Items.Add("North");
            cboDirection.Items.Add("South");
            cboDirection.Items.Add("East");
            cboDirection.Items.Add("West");
            cboDirection.Items.Add("Up");
            cboDirection.Items.Add("Down");

            cboDirection.SelectedIndex = 0;

        }

        private void LoadScenes(Scene scene)
        {
            scene.Serialized = true;
            cboLinkedScene.Items.Add(scene.Title);
            scenes.Add(scene.Title, scene);

            if (scene.East != null && !scene.East.Serialized)
            {

                LoadScenes(scene.East);
            }

            if (scene.West != null && !scene.West.Serialized)
            {
                LoadScenes(scene.West);
            }
            if (scene.Up != null && !scene.Up.Serialized)
            {
                LoadScenes(scene.Up);
            }
            if (scene.Down != null && !scene.Down.Serialized)
            {
                LoadScenes(scene.Down);
            }
            if (scene.North != null && !scene.North.Serialized)
            {
                LoadScenes(scene.North);
            }
            if (scene.South != null && !scene.South.Serialized)
            {
                LoadScenes(scene.South);
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Cancel = false;
            LinkScene = scenes[cboLinkedScene.SelectedItem.ToString()];
            Direction = cboDirection.SelectedItem.ToString();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel = true;
            this.Close();

        }
      
    }
}
