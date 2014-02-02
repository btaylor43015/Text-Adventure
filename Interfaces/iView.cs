using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventure;
using System.Windows.Forms;
using TextAdventure.Classes;

namespace TextAdventure.Interfaces
{
    public interface iView
    {
       
        Player thePlayer { get; set; }
        ListBox informationList { get; set; }
        TextBox sceneDescription { get; set; }
        TextBox title { get; set; }
        TextBox command { get; set; }

        GroupBox editModeContainer { get; set; }
        CheckBox editMode { get; set; }
        Scene CurrentScene { get; set; }
        void DisplayScene(Scene scene);
       
       
       

    }
}
