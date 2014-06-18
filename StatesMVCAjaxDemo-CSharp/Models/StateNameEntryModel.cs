using System;

namespace StatesMVCAjaxDemo_CSharp.Models
{
    public class StateNameEntryModel
    {
        public string stateName { get; set; }
        public string stateAbbr { get; set; }
        public Boolean isSelected { get; set; }

        public StateNameEntryModel()
	    {
            stateName = string.Empty;
            stateAbbr = string.Empty;
            isSelected = false;
	    }

        public StateNameEntryModel(string name, string abbr, bool selected)
        {
            stateName = name;
            stateAbbr = abbr;
            isSelected = selected;
        }
    }

}
