using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventure.Interfaces;
using System.IO;
using System.Windows.Forms;
using TextAdventure.Forms;

namespace TextAdventure.Classes
{
    class MainFormModel
    {
        private iView _view;
        private StreamWriter sw;
        private StreamReader sr;
        private string _lastSceneTitle;
        private string _filename;

        public int sceneNumber = 0;
        public Scene openingScene;
        public Scene _currentScene = null;
        public Dictionary<string, Scene> AllScenes;

        public MainFormModel(iView view)
        {
            _view = view;

        }
        public void InitializeForm()
        {
             
            openingScene  = new Scene(sceneNumber++);
            openingScene.Description = "This is the opening scene";

            AllScenes = new Dictionary<string, Scene>();
            _view.thePlayer = new Player();
            _view.thePlayer.State = Player.PlayerStates.Active;

            displayScene(openingScene);
        }
        public void displayInformation(string info)
        {
            var sInfo = info.Split(':');
            foreach (string s in sInfo)
            {
               _view.informationList.Items.Add(s);
            }

            _view.informationList.SelectedIndex = _view.informationList.Items.Count - 1;

        }
        public void displayScene(Scene scene)
        {
            StringBuilder Exits = new StringBuilder("Available Exits Are: ");
            string currentState = string.Empty;
            _view.informationList.Items.Clear();


            switch (_view.thePlayer.State)
            {
                case Player.PlayerStates.Active:

                    if (scene.East != null)
                        Exits.Append(" EAST");
                    if (scene.West != null)
                        Exits.Append(" WEST");
                    if (scene.South != null)
                        Exits.Append(" SOUTH");
                    if (scene.North != null)
                        Exits.Append(" NORTH");
                    if (scene.Up != null)
                        Exits.Append(" UP");
                    if (scene.Down != null)
                        Exits.Append(" DOWN");
                    break;
                case Player.PlayerStates.Sleeping:
                    currentState = Constants.CMD_ASLEEP;
                    break;


            }

            _view.sceneDescription.Text = scene.Description;
           _view.title.Text = scene.Title;

            if (!string.IsNullOrEmpty(Exits.ToString()))
               displayInformation(Exits.ToString());
            if (!string.IsNullOrEmpty(currentState))
                displayInformation(currentState);
            _view.CurrentScene = scene;

        }
        public void editmodeEast()
        {

           _view.CurrentScene.Description = _view.sceneDescription.Text;

           if (_view.CurrentScene.East == null)
            {
                _view.CurrentScene.East = new Scene(sceneNumber++);
                _view.CurrentScene.East.West = _view.CurrentScene;

            }
           displayScene(_view.CurrentScene.East);
        }
        public void editmodeWest()
        {
            _currentScene.Description = _view.sceneDescription.Text;

            if (_currentScene.West == null)
            {
                _currentScene.West = new Scene(sceneNumber++);
                _currentScene.West.East = _currentScene;

            }
            displayScene(_currentScene.West);
        }
        public void editmodeSouth()
        {
            _currentScene.Description = _view.sceneDescription.Text;

            if (_currentScene.South == null)
            {
                _currentScene.South = new Scene(sceneNumber++);
                _currentScene.South.North = _currentScene;

            }
            displayScene(_currentScene.South);
        }
        public void editmodeNorth()
        {
            _currentScene.Description = _view.sceneDescription.Text;

            if (_currentScene.North == null)
            {
                _currentScene.North = new Scene(sceneNumber++);
                _currentScene.North.South = _currentScene;

            }
            displayScene(_currentScene.North);
        }
        public void editmodeUp()
        {
            _currentScene.Description = _view.sceneDescription.Text;

            if (_currentScene.Up == null)
            {
                _currentScene.Up = new Scene(sceneNumber++);
                _currentScene.Up.Down = _currentScene;

            }
            displayScene(_currentScene.Up);
        }
        public void editmodeDown()
        {
            _currentScene.Description = _view.sceneDescription.Text;

            if (_currentScene.Down == null)
            {
                _currentScene.Down = new Scene(sceneNumber++);
                _currentScene.Down.Up = _currentScene;

            }
            displayScene(_currentScene.Down);
        }
        public void currentSceneSave()
        {
            _currentScene.Description = _view.sceneDescription.Text;
            _currentScene.Title = _view.title.Text;

        }
        public void UnserializeScene(Scene scene)
        {

            scene.PathCount--;

            if (scene.East != null && scene.East.PathCount > 0)
            {

                UnserializeScene(scene.East);
            }

            if (scene.West != null && scene.West.PathCount > 0)
            {
                UnserializeScene(scene.West);
            }
            if (scene.Up != null && scene.Up.PathCount > 0)
            {
                UnserializeScene(scene.Up);
            }
            if (scene.Down != null && scene.Down.PathCount > 0)
            {
                UnserializeScene(scene.Down);
            }
            if (scene.North != null && scene.North.PathCount > 0)
            {
                UnserializeScene(scene.North);
            }
            if (scene.South != null && scene.South.PathCount > 0)
            {
                UnserializeScene(scene.South);
            }



        }
        private void serializeScene(Scene scene)
        {
            sw.WriteLine("Dsc/" + scene.Description);
            sw.WriteLine("Title/" + scene.Title);
            sw.WriteLine("MaxCount/" + scene.MaxCount);

            StringBuilder sContainer = new StringBuilder();
            foreach (TextAdventure.Classes.Container cont in scene.Containers.Values)
            {
                sContainer.Append("Cont/" + cont.Key + ":" + cont.Description + ":");
                foreach (string item in cont.CItems.Keys)
                {
                    sContainer.Append(item + ":");
                }
                sw.WriteLine(sContainer);
                sContainer.Clear();
            }

            scene.PathCount++;

            if (scene.East != null && scene.East.PathCount < scene.East.MaxCount && scene.East.Title != _lastSceneTitle)
            {
                if (scene.East.PathCount == 0)
                    sw.WriteLine("Dir/EAST");
                else
                    sw.WriteLine("Lnk/EAST:" + scene.East.Title);

                _lastSceneTitle = scene.Title;
                serializeScene(scene.East);
            }

            if (scene.West != null && scene.West.PathCount < scene.West.MaxCount && scene.West.Title != _lastSceneTitle)
            {

                if (scene.West.PathCount == 0)
                    sw.WriteLine("Dir/WEST");
                else
                    sw.WriteLine("Lnk/WEST:" + scene.West.Title);
                _lastSceneTitle = scene.Title;
                serializeScene(scene.West);
            }
            if (scene.Up != null && scene.Up.PathCount < scene.Up.MaxCount && scene.Up.Title != _lastSceneTitle)
            {

                if (scene.Up.PathCount == 0)
                    sw.WriteLine("Dir/UP");
                else
                    sw.WriteLine("Lnk/UP:" + scene.Up.Title);
                _lastSceneTitle = scene.Title;
                serializeScene(scene.Up);
            }
            if (scene.Down != null && scene.Down.PathCount < scene.Down.MaxCount && scene.Down.Title != _lastSceneTitle)
            {

                if (scene.Down.PathCount == 0)
                    sw.WriteLine("Dir/DOWN");
                else
                    sw.WriteLine("Lnk/DOWN:" + scene.Down.Title);
                _lastSceneTitle = scene.Title;
                serializeScene(scene.Down);
            }
            if (scene.North != null && scene.North.PathCount < scene.North.MaxCount && scene.North.Title != _lastSceneTitle)
            {

                if (scene.North.PathCount == 0)
                    sw.WriteLine("Dir/NORTH");
                else
                    sw.WriteLine("Lnk/NORTH:" + scene.North.Title);
                _lastSceneTitle = scene.Title;
                serializeScene(scene.North);
            }
            if (scene.South != null && scene.South.PathCount < scene.South.MaxCount && scene.South.Title != _lastSceneTitle)
            {

                if (scene.South.PathCount == 0)
                    sw.WriteLine("Dir/SOUTH");
                else
                    sw.WriteLine("Lnk/SOUTH:" + scene.South.Title);
                _lastSceneTitle = scene.Title;
                serializeScene(scene.South);
            }
            sw.WriteLine("Dir/BACK");


        }
        public void saveToFile()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = _filename;
            dlg.ShowDialog();
            sw = File.CreateText(dlg.FileName);
            _filename = dlg.FileName;

            serializeScene(openingScene);
            sw.Close();
            UnserializeScene(openingScene);
            System.Windows.Forms.MessageBox.Show("Saved.");
        }
        public void loadScenes(string fileName)
        {
            _view.informationList.Items.Clear();
            AllScenes.Clear();

            if (File.Exists(fileName))
            {
                sceneNumber = 0;


                sr = new StreamReader(fileName);
                string str = sr.ReadLine();
                List<Scene> lastScene = new List<Scene>();

                while (str != null)
                {
                    if (str.Contains("Dsc/"))
                    {
                        // direction
                        if (sceneNumber == 0)
                        {
                            openingScene = new Scene(sceneNumber);
                            _currentScene = openingScene;
                            AllScenes.Add(openingScene.Title, openingScene);



                        }
                        _currentScene.Description = str.Replace("Dsc/", "");

                    }
                    else if (str.Contains("Title/"))
                    {
                        _currentScene.Title = str.Replace("Title/", "");
                    }
                    else if (str.Contains("MaxCount/"))
                    {
                        _currentScene.MaxCount = Convert.ToInt16(str.Replace("MaxCount/", ""));
                    }
                    else if (str.Contains("Cont/"))
                    {
                        var sContainer = str.Replace("Cont/", "").Split(':');

                        TextAdventure.Classes.Container cont = new Classes.Container(sContainer[0], sContainer[1]);

                        for (int x = 2; x < sContainer.Length - 1; x++)
                        {
                            cont.CItems.Add(sContainer[x], new ContainerItem(sContainer[x],""));
                        }
                        _currentScene.Containers.Add(sContainer[0], cont);


                    }
                    else if (str.Contains("Lnk/"))
                    {
                        var Link = str.Replace("Lnk/", "").Split(':');

                        switch (Link[0])
                        {
                            case "EAST":
                                lastScene.Add(_currentScene);
                                _currentScene.East = AllScenes[Link[1]];
                                _currentScene.East.West = _currentScene;
                                _currentScene = _currentScene.East;
                                break;
                            case "WEST":
                                lastScene.Add(_currentScene);
                                _currentScene.West = AllScenes[Link[1]];
                                _currentScene.West.East = _currentScene;
                                _currentScene = _currentScene.West;
                                break;
                            case "NORTH":
                                lastScene.Add(_currentScene);
                                _currentScene.North = AllScenes[Link[1]];
                                _currentScene.North.South = _currentScene;
                                _currentScene = _currentScene.North;
                                break;
                            case "SOUTH":
                                lastScene.Add(_currentScene);
                                _currentScene.South = AllScenes[Link[1]];
                                _currentScene.South.North = _currentScene;
                                _currentScene = _currentScene.South;
                                break;
                            case "UP":
                                lastScene.Add(_currentScene);
                                _currentScene.Up = AllScenes[Link[1]];
                                _currentScene.Up.Down = _currentScene;
                                _currentScene = _currentScene.Up;
                                break;
                            case "DOWN":
                                lastScene.Add(_currentScene);
                                _currentScene.Down = AllScenes[Link[1]];
                                _currentScene.Down.Up = _currentScene;
                                _currentScene = _currentScene.Down;
                                break;

                        }
                    }
                    else if (str.Contains("Dir/"))
                    {
                        switch (str.Replace("Dir/", ""))
                        {
                            case "EAST":
                                lastScene.Add(_currentScene);
                                _currentScene.East = new Scene(sceneNumber++);
                                _currentScene.East.West = _currentScene;
                                _currentScene = _currentScene.East;

                                break;

                            case "WEST":
                                lastScene.Add(_currentScene);
                                _currentScene.West = new Scene(sceneNumber++);
                                _currentScene.West.East = _currentScene;
                                _currentScene = _currentScene.West;

                                break;

                            case "UP":
                                lastScene.Add(_currentScene);
                                _currentScene.Up = new Scene(sceneNumber++);
                                _currentScene.Up.Down = _currentScene;
                                _currentScene = _currentScene.Up;

                                break;
                            case "DOWN":
                                lastScene.Add(_currentScene);
                                _currentScene.Down = new Scene(sceneNumber++);
                                _currentScene.Down.Up = _currentScene;
                                _currentScene = _currentScene.Down;

                                break;
                            case "SOUTH":

                                lastScene.Add(_currentScene);
                                _currentScene.South = new Scene(sceneNumber++);
                                _currentScene.South.North = _currentScene;
                                _currentScene = _currentScene.South;

                                break;
                            case "NORTH":
                                lastScene.Add(_currentScene);
                                _currentScene.North = new Scene(sceneNumber++);
                                _currentScene.North.South = _currentScene;
                                _currentScene = _currentScene.North;

                                break;
                            case "BACK":
                                if (lastScene.Count > 0)
                                {
                                    _currentScene = lastScene[lastScene.Count - 1];
                                    lastScene.RemoveAt(lastScene.Count - 1);
                                }
                                break;

                        }

                    }



                    str = sr.ReadLine();
                }
                sr.Close();

                displayScene(openingScene);

            }

        }
        public void getFileAndLoadScenes()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            if (!string.IsNullOrEmpty(dlg.FileName))
            {
                loadScenes(dlg.FileName);
                _filename = dlg.FileName;

            }
        }
        public void toggleEditMode()
        {
           _view.editModeContainer.Visible = _view.editMode.Checked;
           _view.sceneDescription.Enabled = _view.editMode.Checked;
        }
        public void commandKeyPress(KeyPressEventArgs e, CommandEngine ce)
        {
            if (e.KeyChar == 13)
            {
                string sResult;
                e.Handled = true;
                sResult = ce.doCommand(ce.parse(_view.command.Text.ToLower()));
                displayInformation(sResult);

                _view.command.Clear();

            }
        }
        public void LinkToScene()
        {
            frmNewScene ns = new frmNewScene(openingScene);
            ns.ShowDialog();

            if (!ns.Cancel)
            {
                ns.LinkScene.MaxCount++;

                switch (ns.Direction)
                {
                    case "North":
                        _currentScene.North = ns.LinkScene;
                        ns.LinkScene.South = _currentScene;
                        break;
                    case "South":
                        _currentScene.South = ns.LinkScene;
                        ns.LinkScene.North = _currentScene;
                        break;
                    case "East":
                        _currentScene.East = ns.LinkScene;
                        ns.LinkScene.West = _currentScene;
                        break;
                    case "West":
                        _currentScene.West = ns.LinkScene;
                        ns.LinkScene.East = _currentScene;
                        break;
                    case "Up":
                        _currentScene.Up = ns.LinkScene;
                        ns.LinkScene.Down = _currentScene;
                        break;
                    case "Down":
                        _currentScene.Down = ns.LinkScene;
                        ns.LinkScene.Up = _currentScene;
                        break;
                }
            }
            displayScene(_currentScene);
        }
        public void editContainers()
        {
            frmContainers fm = new frmContainers(ref _currentScene);
            fm.ShowDialog();
        }
    }
}
