using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDepartmentRepo
{
    public class ClaimsReop
    {
        private List<ClaimContent> _listOfContent = new List<ClaimContent>();

        //Craeate
        public void AddContentToList(ClaimContent content)
        {
            _listOfContent.Add(content);
        }

        //read
        public List<ClaimContent> GetClaimContents()
        {
            return _listOfContent;
        }

        //update
        public bool UpdateExistingContent(int origianlClaimID, ClaimContent newContent)
        {
            //find the content 
            ClaimContent oldContent = GetClaimByClaimID(origianlClaimID);

            //update the content 
            if (oldContent != null)
            {
                oldContent.ClaimID = newContent.ClaimID;
                oldContent.TypeOfClaim = newContent.TypeOfClaim;
                oldContent.Description = newContent.Description;
                oldContent.ClaimAmount = newContent.ClaimAmount;
                oldContent.DateOfIncident = newContent.DateOfIncident;
                oldContent.DateOfClaim = newContent.DateOfClaim;
                oldContent.IsVaild = newContent.IsVaild;

                return true;
            }
            else
            {
                return false;
            }

        }



        //Delete
        public bool RemoveContentFromList(int claimID)
        {
            ClaimContent content = GetClaimByClaimID(claimID);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfContent.Count;
            _listOfContent.Remove(content);

            if (initialCount > _listOfContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper
        public ClaimContent GetClaimByClaimID(int claimID)
        {
            foreach (ClaimContent content in _listOfContent)
            {
                if (content.ClaimID == claimID)
                {
                    return content;
                }
            }

            return null;
        }
    }
}
