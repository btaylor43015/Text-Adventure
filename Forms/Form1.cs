using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TextAdventure.Interfaces;
using TextAdventure.Forms;
using TextAdventure.Classes;

namespace TextAdventure
{
    public partial class Form1 : Form,iView
    {
        
        private Player _player;
        private CommandEngine _commandEngine;        
        private MainFormModel _model;

        public Form1()
        {
            InitializeComponent();
            _model = new MainFormModel(this);
            _commandEngine = new CommandEngine(this);
            _model.InitializeForm();

        }

        #region Actions
        private void btnEast_Click(object sender, EventArgs e)
        {
            _model.editmodeEast();

        }
        private void btnWest_Click(object sender, EventArgs e)
        {
            _model.editmodeWest();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _model.currentSceneSave();
        }            
        private void btnToFile_Click(object sender, EventArgs e)
        {
            _model.saveToFile();
        }
        private void btnSouth_Click(object sender, EventArgs e)
        {
            _model.editmodeSouth();
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            _model.editmodeUp();
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            _model.editmodeDown();
        }
        private void btnNorth_Click(object sender, EventArgs e)
        {
            _model.editmodeNorth();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            _model.getFileAndLoadScenes();
        }
        private void chkEditMode_CheckedChanged(object sender, EventArgs e)
        {
            _model.toggleEditMode();
        }
        private void txtCmd_KeyPress(object sender, KeyPressEventArgs e)
        {
            _model.commandKeyPress(e, _commandEngine);
        }
        private void btnLink_Click(object sender, EventArgs e)
        {
            _model.LinkToScene();
        }
        private void btnContainers_Click(object sender, EventArgs e)
        {
            _model.editContainers();
        }
        #endregion

        #region properties
        public Player thePlayer
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
            }
        }
        public ListBox informationList
        {
            get
            {
                return lstInformation;
            }
            set
            {
                lstInformation = value;

            }
        }
        public TextBox sceneDescription
        {
            get
            {
                return txtSceneDescription;
            }
            set
            {
                txtSceneDescription = value;
            }
        }
        public TextBox title
        {
            get
            {
                return txtTitle;
            }
            set
            {
                txtTitle = value;
            }
        }
        public GroupBox editModeContainer
        {
            get
            {
                return grpEditMode;
            }
            set
            {
                grpEditMode = value;
            }
        }
        public CheckBox editMode
        {
            get
            {
                return chkEditMode;
            }
            set
            {
                chkEditMode = value;
            }
        }
        public TextBox command
        {
            get
            {
                return txtCmd;
            }
            set
            {
                txtCmd = value;
            }
        }
        #endregion

        #region passthroughMethods
        public Scene CurrentScene
        {
            get
            {
                return _model._currentScene;
            }
            set
            {
                _model._currentScene = value;
            }
        }
        public void DisplayScene(Scene scene)
        {
            _model.displayScene(scene);
        }
        #endregion
    }
}
