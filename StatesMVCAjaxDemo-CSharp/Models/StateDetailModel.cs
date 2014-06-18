using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace StatesMVCAjaxDemo_CSharp.Models
{
    public class StateDetailModel
    {

        public List<StateNameEntryModel> stateNames { get; set; }

        public State stateDetails {get; set;}
    }
}
