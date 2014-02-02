using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventure;
using TextAdventure.Interfaces;


namespace TextAdventure.Classes
{
    public  class  CommandEngine
    {
        private  List<string> Actions = new List<string>() {"help","go","take","hit","attack","turn on","turn off","look","examine","put","open","unlock",
                "play","stop playing","get up","wake","sleep","use","search","inventory","load"}; 
        private  List<string> Directions = new List<string>(){"north","south","east","west","up","down"}; 
        private  List<string> Things = new List<string>(){"lockpick","door","clock","paper","gorn","bed","tv","key","piano","note","toilet"}; 
        private  List<string> Conjuncts = new List<string>(){"on","in","with","for"};
        private List<string> Time = new List<string>(){"hours","hour","minutes","days"};
        private List<string> Numbers = new List<string>(){"0","1","2","3","4","5","6","7","8","9"};

        private iView _view;

        public CommandEngine(iView view)
        {
            _view = view;

        }
        public  string parse(string cmd)
        {
            StringBuilder sRet = new StringBuilder();

            var cmdparts = cmd.Split(' ');
            foreach  (string word in cmdparts)
            {
                if (Actions.Contains(word))
                {
                    sRet.Append("A:" + word + " ");
                    
                }
                else if (Directions.Contains(word))
                {
                    sRet.Append("D:" + word + " ");
                }
                else if (_view.CurrentScene.Containers.Keys.Contains(word))
                {
                    sRet.Append("T:" + word + " ");
                }
                else if (Conjuncts.Contains(word))
                {
                    sRet.Append("AV:" + word + " ");
                }
                else if (!string.IsNullOrEmpty(_view.thePlayer.Searching) && 
                    _view.CurrentScene.Containers[_view.thePlayer.Searching].CItems.Keys.Contains(word))
                {
                    sRet.Append("I:" + word + " ");
                }
                else if (Time.Contains(word))
                {
                    sRet.Append("TIME:" + word + " ");
                }
                else if (Numbers.Contains(word))
                {
                    sRet.Append("N:" + word + " ");
                }
            }

           
            return sRet.ToString();
        }
        public  string doCommand(string cmd )
        {

            StringBuilder sRet = new StringBuilder();
            var words = cmd.Split(' ');
            string action = string.Empty;
            string direction = string.Empty;
            string thing1 = string.Empty;
            string thing2 = string.Empty;
            string adverb = string.Empty;
            string anItem = string.Empty;
            string time = string.Empty;
            string number = string.Empty;
            

            foreach (var word in words)
            {
                if (word.Contains("A:"))
                    action = word.Replace("A:", "");
                else if (word.Contains("D:"))
                    direction = word.Replace("D:", "");
                else if (word.Contains("T:") && string.IsNullOrEmpty(thing1))
                    thing1 = word.Replace("T:", "");
                else if (word.Contains("T:") && string.IsNullOrEmpty(thing2))
                    thing2 = word.Replace("T:", "");
                else if (word.Contains("AV:"))
                    adverb = word.Replace("AV:", "");
                else if (word.Contains("I:"))
                    anItem = word.Replace("I:", "");
                else if (word.Contains("TIME:"))
                    time = word.Replace("TIME:","");
                else if (word.Contains("N:"))
                    number = word.Replace("N:","");

            }

            if (action != "take")
                _view.thePlayer.Searching = string.Empty;

                switch (action)
                {
                    #region help
                    case "help":
                        sRet.Append("Try one of these actions: ");
                        foreach (string s in Actions)
                        {
                            sRet.Append( s + ":");
                        }
                        break;
                    #endregion

                    #region inventory
                    case "inventory":
                        sRet.Append("You are carying the following items:");
                        foreach (string item in _view.thePlayer.getInventory())
                        {
                            sRet.AppendFormat("     {0}:", item);
                        }
                        break;
                    #endregion
                    #region go
                    case "go":
                        _view.thePlayer.Searching = string.Empty;
                        if (_view.thePlayer.State == Player.PlayerStates.Active)
                        {

                            switch (direction)
                            {
                                case "north":
                                    if (_view.CurrentScene.North != null)
                                        _view.DisplayScene(_view.CurrentScene.North);
                                    else
                                        sRet.Append(Constants.CMD_CANT_GO + " North");
                                    break;
                                case "south":
                                    if (_view.CurrentScene.South != null)
                                        _view.DisplayScene(_view.CurrentScene.South);
                                    else
                                        sRet.Append(Constants.CMD_CANT_GO + " South");
                                    break;
                                case "east":
                                    if (_view.CurrentScene.East != null)
                                        _view.DisplayScene(_view.CurrentScene.East);
                                    else
                                        sRet.Append(Constants.CMD_CANT_GO + " East");
                                    break;
                                case "west":
                                    if (_view.CurrentScene.West != null)
                                        _view.DisplayScene(_view.CurrentScene.West);
                                    else
                                        sRet.Append(Constants.CMD_CANT_GO + " West");
                                    break;
                                case "up":
                                    if (_view.CurrentScene.Up != null)
                                        _view.DisplayScene(_view.CurrentScene.Up);
                                    else
                                        sRet.Append(Constants.CMD_CANT_GO + " Up");
                                    break;
                                case "down":
                                    if (_view.CurrentScene.Down != null)
                                        _view.DisplayScene(_view.CurrentScene.Down);
                                    else
                                        sRet.Append(Constants.CMD_CANT_GO + " Down");
                                    break;
                                default:
                                    sRet.Append(Constants.CMD_UNKNOWN_DIRECTION);
                                    break;

                            }
                        }
                        else
                            sRet.Append(Constants.CMD_YOU_ARE_SLEEPING);
                        break;
#endregion

                    #region take
                    case "take":

                        if (!string.IsNullOrEmpty(anItem) && _view.thePlayer.addToInventory(anItem))
                        {
                            sRet.Append("taking " + anItem);
                            _view.CurrentScene.Containers[_view.thePlayer.Searching].CItems.Remove(anItem);
                        }
                        else
                        {

                            sRet.Append(Constants.CMD_I_DONT_SEE_THAT);
                        }

                        break;
                    #endregion

                    #region look
                    case "look":
                        _view.thePlayer.Searching = string.Empty;
                        if (!string.IsNullOrEmpty(thing1))
                            sRet.Append(_view.CurrentScene.Containers[thing1].Description);
                        else
                        {
                            sRet.Append(Constants.CMD_I_DONT_SEE_THAT);
                        }

                        break;
                    #endregion

                    #region search
                    case "search":
                        if (!string.IsNullOrEmpty(thing1))
                        {
                            _view.thePlayer.Searching = thing1;
                            if (_view.CurrentScene.Containers[thing1].CItems.Count > 0)
                            {
                                sRet.Append("The " + thing1 + " contains the following items :");
                                foreach (string item in _view.CurrentScene.Containers[thing1].CItems.Keys)
                                {

                                    sRet.AppendFormat("      {0}:", item);
                                }
                            }
                            else
                            {
                                sRet.Append("There is nothing of interest in the " + thing1);
                            }
                        }
                        else
                        {
                            sRet.Append(Constants.CMD_I_DONT_SEE_THAT);
                        }
                        break;
                    #endregion

                    #region examine
                    case "examine":
                        if (!string.IsNullOrEmpty(thing1))
                        {
                            sRet.Append(thing1 + " contains: ");
                            foreach (string thing in Things)
                            {
                                sRet.Append(thing + " ");
                            }
                        }
                        else
                        {
                            sRet.Append(Constants.CMD_I_DONT_SEE_THAT);
                        }

                        break;
                    #endregion

                    #region put
                    case "put":
                        _view.thePlayer.Searching = string.Empty;
                        if (!string.IsNullOrEmpty(thing1) && !string.IsNullOrEmpty(thing2) && !string.IsNullOrEmpty(adverb))
                            sRet.Append("putting " + thing1 + " " + adverb + " " + thing2);
                        else
                        {
                            sRet.Append(Constants.CMD_CANT_DO_THAT);
                        }
                        break;
                    #endregion

                    #region wake
                    case "wake":
                        _view.thePlayer.Searching = string.Empty;
                        if (_view.thePlayer.State == Player.PlayerStates.Sleeping)
                            _view.thePlayer.State = Player.PlayerStates.Active;
                        sRet.Append(Constants.CMD_YOU_ARE_AWAKE);
                        _view.DisplayScene(_view.CurrentScene);
                        break;
                    #endregion

                    #region sleep
                    case "sleep":
                        if (_view.CurrentScene.Containers.Keys.Contains("bed"))
                        {
                            if (adverb == "for" && !string.IsNullOrEmpty(number) && !string.IsNullOrEmpty(time))
                            {
                                _view.thePlayer.State = Player.PlayerStates.Sleeping;
                                sRet.Append("You are sleeping for " + number + " " + time);
                            }
                            else
                                sRet.Append("How long do you want to sleep?");

                        }
                        else
                            sRet.Append("You need to find a bed to sleep in");
                        break;
                    #endregion

                    #region default
                    default:
                        _view.thePlayer.Searching = string.Empty;
                        sRet.Append( Constants.CMD_UNKNOWN);
                        break;
                    #endregion
                }

            return sRet.ToString();
        }

    }
}
