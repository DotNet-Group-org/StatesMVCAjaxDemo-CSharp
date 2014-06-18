using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatesMVCAjaxDemo_CSharp.Models
{
    public interface IRepository
    {
        List<StateNameEntryModel> GetAllStateNames();
        List<StateNameEntryModel> GetAllStateNames(string selectedStateAbbr);

        StateDetailModel GetStateDetails(string selectedStateAbbr);
        StateDetailModel GetStateDetails(string selectedStateAbbr, bool doImageFixup);


        void SaveStateDetails(State entry);
        void DeleteState(string stateAbbr);

        List<string> GetCounties(string stateAbbr);
    }
}
