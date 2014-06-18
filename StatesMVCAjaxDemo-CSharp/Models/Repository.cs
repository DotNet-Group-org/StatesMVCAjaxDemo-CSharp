using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace StatesMVCAjaxDemo_CSharp.Models
{
    public class Repository : IRepository
    {

        StatesEntities entity = new StatesEntities();
        public System.Collections.Generic.List<StateNameEntryModel> GetAllStateNames()
        {
            return GetAllStateNames(string.Empty);
        }

        public System.Collections.Generic.List<StateNameEntryModel> GetAllStateNames(string selectedStateAbbr)
    	{
    		List<StateNameEntryModel> names = new List<StateNameEntryModel>();

	    	dynamic states = (from m in entity.States orderby m.stateName select m).ToList();

    		foreach (State s in states) {
	    		names.Add(new StateNameEntryModel(s.stateName, s.stateAbbr, (selectedStateAbbr == s.stateAbbr)));
		    }
		    return names;
	    }

        public StateDetailModel GetStateDetails(string selectedStateAbbr)
        {
            return GetStateDetails(selectedStateAbbr, true);
        }

        public StateDetailModel GetStateDetails(string selectedStateAbbr, bool doImageFixup)
	    {

    		StateDetailModel details = new StateDetailModel();

	    	details.stateNames = GetAllStateNames(selectedStateAbbr);
		    details.stateDetails = (from m in entity.States where m.stateAbbr == selectedStateAbbr select m).First();

		    // update the URIs for the state and seal images
    		if (doImageFixup) {
	    		if (!string.IsNullOrEmpty(details.stateDetails.stateImageFlag)) {
		    		details.stateDetails.stateImageFlag = System.IO.Path.Combine("~/Content", details.stateDetails.stateImageFlag).Replace("\\", "/");
			    }
    			if (!string.IsNullOrEmpty(details.stateDetails.stateImageSeal)) {
	    			details.stateDetails.stateImageSeal = System.IO.Path.Combine("~/Content", details.stateDetails.stateImageSeal).Replace("\\", "/");
		    	}
		    }

		    return details;
	    }

        public void SaveStateDetails(State entry)
    	{
	    	try {
		    	State s = default(State);

			    if (entry.stateID <= 0) {
				    // adding a new state
				    entity.AddToStates(entry);
			    } else {
				    // updating an existing state
				    s = (from m in entity.States where m.stateID == entry.stateID select m).First();
				    if (s != null) {
					    s.stateAbbr = entry.stateAbbr;
					    s.stateBird = entry.stateBird;
					    s.stateCapital = entry.stateCapital;
					    s.stateFlower = entry.stateFlower;
					    s.stateImageFlag = entry.stateImageFlag;
					    s.stateImageSeal = entry.stateImageSeal;
					    s.stateName = entry.stateName;
					    s.stateRegion = entry.stateRegion;
					    s.stateTree = entry.stateTree;
				    } else {
					    throw new KeyNotFoundException("State ID was not found: " + entry.stateID.ToString());
				    }
			    }

    			entity.SaveChanges();
	    	} catch (Exception ex) {
		    	throw ex;
		    }
	    }

        public void DeleteState(string stateAbbr)
	    {
		    if (!string.IsNullOrEmpty(stateAbbr)) {
			    State s = default(State);

    			s = (from m in entity.States where m.stateAbbr == stateAbbr select m).First();
	    		if (s != null) {
    				entity.States.DeleteObject(s);
	    			entity.SaveChanges();
		    	}
		    }   
	    }


        public List<string> GetCounties(String stateAbbr)
        {
            List<string> s;
            s = new List<string>();

            if (!String.IsNullOrEmpty(stateAbbr)) {
            try
                {

                int id;
                id = (from n in entity.States where n.stateAbbr == stateAbbr select n.stateID).First();
                s = (from m in entity.Counties where m.stateID == id select m.countyName).ToList();
             } catch (Exception ex)
                {
                }
            }
            return s;
        }
    }
}
